using System;
using System.Runtime.CompilerServices;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public static class ModelExtensions
{
    /// <summary>
    /// Получить сервисы лок-объекта доменного объекта по интерфейсу доменного объекта с аттрибутом <see cref="DomainObjectInterfaceAttribute"/>.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IDomainObjectUnitOfWorkLockService GetLock<TDomainObject>(this ICustomEntryPoint entryPoint)
        where TDomainObject : IDomainObject
    {
        var domainObjectTypeId = GetDomainObjectTypeId<TDomainObject>();
        var result = entryPoint.UnitOfWorkLocks.GetLock(domainObjectTypeId);

        return result;
    }

    /// <summary>
    /// Регистрация критической секции доменного объекта при его получении из реестра.
    /// Интерфейс доменного объекта <typeparamref name="TDomainObject"/> должен иметь аттрибут <see cref="DomainObjectInterfaceAttribute"/>.
    /// <example>К примеру <seealso cref="IDomainObjectRegister.Find(long)" />.</example>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ICustomEntryPoint LockRegister<TDomainObject>(this ICustomEntryPoint entryPoint, long identity)
        where TDomainObject : IDomainObject
    {
        var domainObjectTypeId = GetDomainObjectTypeId<TDomainObject>();
        var lockService = entryPoint.UnitOfWorkLocks.GetLock(domainObjectTypeId);
        lockService.Register(identity);

        return entryPoint;
    }

    /// <summary>
    /// Регистрация критической секции доменного объекта при его получении из реестра.
    /// <example>К примеру <seealso cref="IDomainObjectRegister.Find(long)" />.</example>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TDomainObjectRegister LockRegister<TDomainObjectRegister>(this TDomainObjectRegister register, long identity)
        where TDomainObjectRegister : IDomainObjectRegister
    {
        var lockService = register.EntryPoint().UnitOfWorkLocks.GetLock(register.TypeId);
        lockService.Register(identity);

        return register;
    }

    /// <summary>
    /// Получить локальный для <see cref="IUnitOfWork"/> реест доменных объектов по интерфейсу доменного объекта с аттрибутом <see cref="DomainObjectInterfaceAttribute"/>.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IDomainObjectRegister GetRegister<TDomainObject>(this ICustomEntryPoint entryPoint)
        where TDomainObject : IDomainObject
    {
        var domainObjectTypeId = GetDomainObjectTypeId<TDomainObject>();
        var result = entryPoint.UnitOfWorkProvider.Instance.Registers.GetRegister(domainObjectTypeId);

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ICustomEntryPoint EntryPoint(this IDomainObjectRegister register)
    {
        var result = (ICustomEntryPoint)((UnitOfWork)register.UnitOfWorkProvider.Instance).EntryPoint;

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Guid GetDomainObjectTypeId<TDomainObject>()
        where TDomainObject : IDomainObject
    {
        if (false == typeof(TDomainObject).IsDefined(typeof(DomainObjectInterfaceAttribute), false))
        {
            WattleThrowsHelper.ThrowInternalException(
                $"Для интерфейса доменного объекта '{typeof(TDomainObject).AssemblyQualifiedName}' не определён аттрибут '{typeof(DomainObjectInterfaceAttribute).AssemblyQualifiedName}'.");
        }
        var customAttribute = (DomainObjectInterfaceAttribute)typeof(TDomainObject).GetCustomAttributes(typeof(DomainObjectInterfaceAttribute), false)[0];
        var result = customAttribute.DomainObjectTypeId;

        return result;
    }
}
