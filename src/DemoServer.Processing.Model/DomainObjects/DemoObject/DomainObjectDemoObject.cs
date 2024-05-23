using Microsoft.Extensions.Logging;
using ShtrihM.DemoServer.Processing.Api.Common;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers.Primitives.MutableFields;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;
using ShtrihM.Wattle3.DomainObjects.DomainObjects.BaseDomainObjects;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObject;

[DomainObjectDataMapper]
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class DomainObjectDemoObject : BaseDomainObjectMutableWithUpdateLock<DomainObjectDemoObject, IEntryPointContext<ICustomEntryPoint>>, IDomainObjectDemoObject, IDomainObjectActivatorPostCreate
{
    #region Template - шаблон создания объекта

    /// <summary>
    /// Шаблон создания объекта <see cref="DomainObjectDemoObject"/>.
    /// </summary>
    public class Template : IDomainObjectTemplate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // ReSharper disable once ConvertToPrimaryConstructor
        public Template(
            string name,
            bool enabled)
        {
            Name = name;
            Enabled = enabled;
        }

        public readonly string Name;
        public readonly bool Enabled;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTask<IDomainObjectDemoObject> NewAsync(
            ICustomEntryPoint entryPoint,
            CancellationToken cancellationToken = default)
        {
            return entryPoint.CurrentUnitOfWork.NewAsync<IDomainObjectDemoObject>(this, cancellationToken);
        }
    }

    #endregion

    #region Изменяемы поля

    [DomainObjectFieldValue]
    private readonly MutableField<bool> m_enabled;

    [DomainObjectFieldValue]
    private readonly MutableFieldStringLimitedEx m_name;

    #endregion

    #region Конструкторы

    // ReSharper disable once UnusedMember.Global
    public DomainObjectDemoObject(
        DemoObjectDtoActual data,
        IEntryPointContext<ICustomEntryPoint> entryPointContext,
        IDomainObjectUnitOfWorkLockService lockUpdate)
        : base(entryPointContext, data, lockUpdate)
    {
        CreateDate = data.CreateDate.SpecifyKindLocal();
        ModificationDate = data.ModificationDate.SpecifyKindLocal();
        m_name = new MutableFieldStringLimitedEx(FieldsConstants.DemoObjectNameMaxLength, data.Name);
        m_enabled = new MutableField<bool>(data.Enabled);
    }

    // ReSharper disable once UnusedMember.Global
    public DomainObjectDemoObject(
        long identity,
        Template template,
        IEntryPointContext<ICustomEntryPoint> entryPointContext,
        IDomainObjectUnitOfWorkLockService lockUpdate)
        : base(entryPointContext, identity, lockUpdate)
    {
        CreateDate = m_entryPointContext.TimeService.NowDateTime;
        ModificationDate = CreateDate;
        m_name = new MutableFieldStringLimitedEx(FieldsConstants.DemoObjectNameMaxLength, template.Name);
        m_enabled = new MutableField<bool>(template.Enabled);
    }

    #endregion

    public override Guid TypeId => WellknownDomainObjects.DemoObject;

    public bool Enabled
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_enabled.Value;
    }

    public string Name
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_name.Value;
    }

    [DomainObjectFieldValue]
    public DateTime CreateDate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue]
    public DateTime ModificationDate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private set;
    }

    public ValueTask UpdateAsync(DemoObjectUpdate parameters, CancellationToken cancellationToken)
    {
        m_lockUpdate.Has(Identity);

        var changed = false;
        foreach (var field in parameters.Fields)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (field is DemoObjectUpdateFieldValueOfName fieldValueOfName)
            {
                m_name.SetValue(fieldValueOfName.Name);
                if (m_name.Changed)
                {
                    changed = true;
                }

                continue;
            }

            if (field is DemoObjectUpdateFieldValueOfEnabled fieldValueOfEnabled)
            {
                m_enabled.SetValue(fieldValueOfEnabled.Enabled);
                if (m_enabled.Changed)
                {
                    changed = true;
                }

                continue;
            }

            throw new InternalException($"Неизвестный тип поля '{field.GetType().AssemblyQualifiedName}'.");
        }

        if (changed)
        {
            return DoUpdateAsync(cancellationToken);
        }

        return ValueTask.CompletedTask;
    }

    public DemoObjectInfo GetInfo()
    {
        var result =
            new DemoObjectInfo
            {
                Id = Identity,
                Name = Name,
                Enabled = Enabled,
            };

        return result;
    }

    protected override ValueTask DoUpdateAsync(CancellationToken cancellationToken = default)
    {
        ModificationDate = m_entryPointContext.TimeService.NowDateTime;

        return base.DoUpdateAsync(cancellationToken);
    }

    #region Аспект создания

    public void PostCreate()
    {
        var identity = Identity;
        var unitOfWork = m_entryPointContext.EntryPoint.CurrentUnitOfWork;
        var domainBehaviour = unitOfWork.CreateDomainBehaviourWithСonfirmation();
        unitOfWork.AddBehaviour(domainBehaviour);

        domainBehaviour.SetFailAll(
            () =>
            {
                var logger = m_entryPointContext.EntryPoint.LoggerFactory.CreateLogger<DomainObjectDemoObject>();
                var messgae = $"Не удалось создать объект с идентификатором '{identity}'.";
                logger.LogError(messgae);
                Console.WriteLine(messgae);
            });

        domainBehaviour.SetSuccessfulAll(
            () =>
            {
                var logger = m_entryPointContext.EntryPoint.LoggerFactory.CreateLogger<DomainObjectDemoObject>();
                var messgae = $"Создан объект с идентификатором '{identity}'.";
                logger.LogError(messgae);
                Console.WriteLine(messgae);
            });
    }

    public ValueTask PostCreateAsync(CancellationToken cancellationToken = default)
    {
        PostCreate();

        return ValueTask.CompletedTask;
    }

    #endregion
}