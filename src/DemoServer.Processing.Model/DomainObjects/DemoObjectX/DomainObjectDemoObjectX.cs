using Microsoft.Extensions.Logging;
using ShtrihM.DemoServer.Processing.Api.Common;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
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

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

[DomainObjectDataMapper(WellknownMappersAsText.DemoObjectX, DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DomainObjectDataTarget.Delete)]
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class DomainObjectDemoObjectX : BaseDomainObjectMutable<DomainObjectDemoObjectX>, IDomainObjectDemoObjectX,
    IDomainObjectActivatorPostCreate
{
    #region Template

    public class Template : IDomainObjectTemplate
    {
        public Template(
            string name,
            bool enabled,
            Guid key1,
            string key2,
            long group)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Enabled = enabled;
            Key1 = key1;
            Key2 = key2 ?? throw new ArgumentNullException(nameof(key2));
            Group = group;
            Key2 = key2;
        }

        public readonly string Name;
        public readonly bool Enabled;
        public readonly Guid Key1;
        public readonly string Key2;
        public readonly long Group;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DemoObjectXIdentitiesService.AlternativeKey GetKey()
        {
            var result = new DemoObjectXIdentitiesService.AlternativeKey(Key1, Key2);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDomainObjectDemoObjectX New(ICustomEntryPoint entryPoint)
        {
            if (entryPoint == null)
            {
                ThrowsHelper.ThrowArgumentNullException(nameof(entryPoint));
            }

            return entryPoint!.CurrentUnitOfWork.New<IDomainObjectDemoObjectX>(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTask<IDomainObjectDemoObjectX> NewAsync(ICustomEntryPoint entryPoint, CancellationToken cancellationToken = default)
        {
            if (entryPoint == null)
            {
                ThrowsHelper.ThrowArgumentNullException(nameof(entryPoint));
            }

            return entryPoint!.CurrentUnitOfWork.NewAsync<IDomainObjectDemoObjectX>(this, cancellationToken);
        }
    }

    #endregion

    private readonly IDomainObjectUnitOfWorkLockService m_lockUpdate;

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DtoFiledName = nameof(DemoObjectXDtoChanged.Enabled))]
    private MutableField<bool> m_enabled;

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DtoFiledName = nameof(DemoObjectXDtoChanged.Name))]
    private MutableFieldStringLimitedEx m_name;

    // ReSharper disable once UnusedMember.Global
    public DomainObjectDemoObjectX(
        DemoObjectXDtoActual data,
        ICustomEntryPoint entryPoint,
        IDomainObjectUnitOfWorkLockService lockUpdate)
        : base(entryPoint, data)
    {
        m_lockUpdate = lockUpdate;
        CreateDate = data.CreateDate.SpecifyKindLocal();
        ModificationDate = data.ModificationDate.SpecifyKindLocal();
        m_name = new(FieldsConstants.DemoObjectXNameMaxLength, data.Name);
        m_enabled = new(data.Enabled);
        Key1 = data.Key1;
        Key2 = data.Key2;
        Group = data.Group;
    }

    // ReSharper disable once UnusedMember.Global
    public DomainObjectDemoObjectX(
        long identity,
        Template template,
        ICustomEntryPoint entryPoint,
        IDomainObjectUnitOfWorkLockService lockUpdate)
        : base(entryPoint, identity)
    {
        m_lockUpdate = lockUpdate;
        CreateDate = m_entryPoint.TimeService.NowDateTime;
        ModificationDate = CreateDate;
        m_name = new(FieldsConstants.DemoObjectXNameMaxLength, template.Name);
        m_enabled = new(template.Enabled);
        Key1 = template.Key1;
        Key2 = template.Key2;
        Group = template.Group;
    }

    public override Guid TypeId => WellknownDomainObjects.DemoObjectX;

    public bool Enabled
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_enabled.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            m_lockUpdate.Has(Identity);

            m_enabled.SetValue(value);
            if (m_enabled.Changed)
            {
                DoUpdate();
            }
        }
    }

    public string Name
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_name.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            m_lockUpdate.Has(Identity);

            m_name.SetValue(value);
            if (m_name.Changed)
            {
                DoUpdate();
            }
        }
    }

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update)]
    public DateTime CreateDate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update)]
    public Guid Key1
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update)]
    public string Key2
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update)]
    public long Group
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DemoObjectXIdentitiesService.AlternativeKey GetKey()
    {
        var result = new DemoObjectXIdentitiesService.AlternativeKey(Key1, Key2);

        return result;
    }

    public void Delete()
    {
        m_entryPoint.CurrentUnitOfWork.AddDelete(this);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PostCreate()
    {
        var unitOfWork = m_entryPoint.CurrentUnitOfWork;
        var domainBehaviour = unitOfWork.CreateDomainBehaviourWithСonfirmation();
        unitOfWork.AddBehaviour(domainBehaviour);

        var identity = Identity;

        domainBehaviour.SetFailAll(
            () =>
            {
                var logger = m_entryPoint.LoggerFactory.CreateLogger<DomainObjectDemoObjectX>();
                var messgae = $"Не удалось создать объект X с идентификатором '{identity}'.";
                logger.LogError(messgae);
                Console.WriteLine(messgae);
            });

        domainBehaviour.SetSuccessfulAll(
            () =>
            {
                var logger = m_entryPoint.LoggerFactory.CreateLogger<DomainObjectDemoObjectX>();
                var messgae = $"Создан объект X с идентификатором '{identity}'.";
                logger.LogError(messgae);
                Console.WriteLine(messgae);
            });
    }

    public ValueTask PostCreateAsync(CancellationToken cancellationToken)
    {
        PostCreate();

        return ValueTask.CompletedTask;
    }

    protected override void DoUpdate()
    {
        base.DoUpdate();

        ModificationDate = m_entryPoint.TimeService.NowDateTime;
    }

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update)]
    public static (DemoObjectXIdentitiesService.AlternativeKey, long) Decode(IDomainObjectDemoObjectX demoObject)
    {
        return (demoObject.GetKey(), demoObject.Group);
    }
}