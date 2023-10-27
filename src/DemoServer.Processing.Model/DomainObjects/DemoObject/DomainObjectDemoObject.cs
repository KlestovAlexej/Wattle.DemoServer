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
using ShtrihM.DemoServer.Processing.Model.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObject;

[DomainObjectDataMapper(WellknownMappersAsText.DemoObject, DomainObjectDataTarget.Create, DomainObjectDataTarget.Update)]
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class DomainObjectDemoObject : BaseDomainObjectMutable<DomainObjectDemoObject>, IDomainObjectDemoObject, IDomainObjectActivatorPostCreate
{
    #region Template

    public class Template : IDomainObjectTemplate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Template(
            string name,
            bool enabled)
            // ReSharper disable once ConvertToPrimaryConstructor
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Enabled = enabled;
        }

        public readonly string Name;
        public readonly bool Enabled;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTask<IDomainObjectDemoObject> NewAsync(
            ICustomEntryPoint entryPoint,
            CancellationToken cancellationToken = default)
        {
            if (entryPoint == null)
            {
                ThrowsHelper.ThrowArgumentNullException(nameof(entryPoint));
            }

            return entryPoint!.CurrentUnitOfWork.NewAsync<IDomainObjectDemoObject>(this, cancellationToken);
        }
    }

    #endregion

    private readonly IDomainObjectUnitOfWorkLockService m_lockUpdate;

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DtoFiledName = nameof(DemoObjectDtoChanged.Enabled))]
    private MutableField<bool> m_enabled;

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DtoFiledName = nameof(DemoObjectDtoChanged.Name))]
    private MutableFieldStringLimitedEx m_name;

    // ReSharper disable once UnusedMember.Global
    public DomainObjectDemoObject(
        DemoObjectDtoActual data,
        ICustomEntryPoint entryPoint,
        IDomainObjectUnitOfWorkLockService lockUpdate)
        : base(entryPoint, data)
    {
        m_lockUpdate = lockUpdate;
        CreateDate = data.CreateDate.SpecifyKindLocal();
        ModificationDate = data.ModificationDate.SpecifyKindLocal();
        m_name = new(FieldsConstants.DemoObjectNameMaxLength, data.Name);
        m_enabled = new(data.Enabled);
    }

    // ReSharper disable once UnusedMember.Global
    public DomainObjectDemoObject(
        long identity,
        Template template,
        ICustomEntryPoint entryPoint,
        IDomainObjectUnitOfWorkLockService lockUpdate)
        : base(entryPoint, identity)
    {
        m_lockUpdate = lockUpdate;
        CreateDate = m_entryPoint.TimeService.NowDateTime;
        ModificationDate = CreateDate;
        m_name = new(FieldsConstants.DemoObjectNameMaxLength, template.Name);
        m_enabled = new(template.Enabled);
    }

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

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update)]
    public DateTime CreateDate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update)]
    public DateTime ModificationDate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private set;
    }

    public ValueTask UpdateAsync(DemoObjectUpdate parameters, CancellationToken cancellationToken)
    {
        if (parameters == null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

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
            DoUpdate();
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

    public void PostCreate()
    {
        var identity = Identity;
        var domainBehaviour = m_entryPoint.CreateDomainBehaviourWithСonfirmation<IMapperDemoObject>(identity);

        m_entryPoint.CurrentUnitOfWork.AddBehaviour(domainBehaviour);

        domainBehaviour.SetFailAll(
            () =>
            {
                var logger = m_entryPoint.LoggerFactory.CreateLogger<DomainObjectDemoObject>();
                var messgae = $"Не удалось создать объект с идентификатором '{identity}'.";
                logger.LogError(messgae);
                Console.WriteLine(messgae);
            });

        domainBehaviour.SetSuccessfulAll(
            () =>
            {
                var logger = m_entryPoint.LoggerFactory.CreateLogger<DomainObjectDemoObject>();
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

    protected override void DoUpdate()
    {
        base.DoUpdate();

        ModificationDate = m_entryPoint.TimeService.NowDateTime;
    }
}