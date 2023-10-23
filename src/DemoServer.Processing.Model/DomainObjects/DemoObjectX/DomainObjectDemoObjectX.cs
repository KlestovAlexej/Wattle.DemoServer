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
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using ShtrihM.Wattle3.Primitives;

#pragma warning disable CA2254

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

[DomainObjectDataMapper(WellknownMappersAsText.DemoObjectX, DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DomainObjectDataTarget.Delete)]
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class DomainObjectDemoObjectX : DomainObjectMutable<DomainObjectDemoObjectX>, IDomainObjectDemoObjectX, IDomainObjectActivatorPostCreate
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
        public DemoObjectXAlternativeKey GetKey()
        {
            var result = new DemoObjectXAlternativeKey(Key1, Key2);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDomainObjectDemoObjectX New(ICustomEntryPoint entryPoint)
        {
            if (entryPoint == null)
            {
                ThrowsHelper.ThrowArgumentNullException(nameof(entryPoint));
            }

            return entryPoint!.New<IDomainObjectDemoObjectX>(this);
        }
    }

    #endregion

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DtoFiledName = nameof(DemoObjectXDtoChanged.Enabled))]
    private MutableField<bool> m_enabled;

    [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DtoFiledName = nameof(DemoObjectXDtoChanged.Name))]
    private MutableFieldStringLimitedEx m_name;

    // ReSharper disable once UnusedMember.Global
    public DomainObjectDemoObjectX(
        DemoObjectXDtoActual data,
        ICustomEntryPoint entryPoint)
        : base(entryPoint, data)
    {
        CreateDate = data.CreateDate.SpecifyKindLocal();
        ModificationDate = data.ModificationDate.SpecifyKindLocal();
        m_name = new MutableFieldStringLimitedEx(FieldsConstants.DemoObjectXNameMaxLength, data.Name);
        m_enabled = new MutableField<bool>(data.Enabled);
        Key1 = data.Key1;
        Key2 = data.Key2;
        Group = data.Group;
    }

    // ReSharper disable once UnusedMember.Global
    public DomainObjectDemoObjectX(
        long identity,
        Template template,
        ICustomEntryPoint entryPoint)
        : base(entryPoint, identity)
    {
        CreateDate = m_entryPoint.TimeService.NowDateTime;
        ModificationDate = CreateDate;
        m_name = new MutableFieldStringLimitedEx(FieldsConstants.DemoObjectXNameMaxLength, template.Name);
        m_enabled = new MutableField<bool>(template.Enabled);
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
    public DemoObjectXAlternativeKey GetKey()
    {
        var result = new DemoObjectXAlternativeKey(Key1, Key2);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Delete()
    {
        m_entryPoint.CurrentUnitOfWork.AddDelete(this);

        var register = (DomainObjectRegisterDemoObjectX)m_entryPoint.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
        var domainBehaviour = m_entryPoint.CreateDomainBehaviourWithСonfirmation();

        register.RemoveDomainObject(domainBehaviour, Identity, GetKey());
    }

    public void PostCreate()
    {
        DoPostCreate();

        var register = (DomainObjectRegisterDemoObjectX)m_entryPoint.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
        var domainBehaviour = m_entryPoint.CreateDomainBehaviourWithСonfirmation();

        register.AddDomainObject(domainBehaviour, Identity, GetKey(), Group);
    }

    public ValueTask PostCreateAsync(CancellationToken cancellationToken)
    {
        DoPostCreate();

        var register = (DomainObjectRegisterDemoObjectX)m_entryPoint.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
        var domainBehaviour = m_entryPoint.CreateDomainBehaviourWithСonfirmation();

        return register.AddDomainObjectAsync(domainBehaviour, Identity, GetKey(), Group, cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void DoPostCreate()
    {
        var domainBehaviour = m_entryPoint.CreateDomainBehaviourWithСonfirmation();

        m_entryPoint.UnitOfWorkProvider.Instance.AddBehaviour(domainBehaviour);

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

    protected override void DoUpdate()
    {
        base.DoUpdate();

        ModificationDate = m_entryPoint.TimeService.NowDateTime;
    }
}