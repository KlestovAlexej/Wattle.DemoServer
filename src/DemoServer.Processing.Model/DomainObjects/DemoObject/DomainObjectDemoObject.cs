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
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using ShtrihM.Wattle3.Primitives;

#pragma warning disable CA2254
#pragma warning disable IDE0052

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObject;

[DomainObjectDataMapper(WellknownMappersAsText.DemoObject, DomainObjectDataTarget.Create, DomainObjectDataTarget.Update)]
public sealed class DomainObjectDemoObject : DomainObjectMutable<DomainObjectDemoObject>, IDomainObjectDemoObject, IDomainObjectActivatorPostCreate
{
    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DtoFiledName = nameof(DemoObjectDtoChanged.Enabled))]
    private MutableField<bool> m_enabled;

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DtoFiledName = nameof(DemoObjectDtoChanged.Name))]
    private MutableFieldStringLimitedEx m_name;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DomainObjectDemoObject(
        ICustomEntryPoint entryPoint,
        DemoObjectDtoActual data)
        : base(entryPoint, data)
    {
        CreateDate = data.CreateDate.SpecifyKindLocal();
        ModificationDate = data.ModificationDate.SpecifyKindLocal();
        m_name = new MutableFieldStringLimitedEx(FieldsConstants.DemoObjectNameMaxLength, data.Name);
        m_enabled = new MutableField<bool>(data.Enabled);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DomainObjectDemoObject(
        ICustomEntryPoint entryPoint,
        long identity,
        DomainObjectTemplateDemoObject template)
        : base(entryPoint, identity)
    {
        CreateDate = m_entryPoint.TimeService.NowDateTime;
        ModificationDate = CreateDate;
        m_name = new MutableFieldStringLimitedEx(FieldsConstants.DemoObjectNameMaxLength, template.Name);
        m_enabled = new MutableField<bool>(template.Enabled);
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

        m_entryPoint.UnitOfWorkLocks.DemoObject.Has(Identity);

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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