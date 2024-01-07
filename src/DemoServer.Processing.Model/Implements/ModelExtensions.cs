using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public static class ModelExtensions
{
    /// <summary>
    /// Найти доменный объект по идентитити.
    /// </summary>
    /// <typeparam name="TDomainObject">Интерфейс доменного объекта.</typeparam>
    /// <param name="entryPoint">Точка входа.</param>
    /// <param name="identity">Идентитити доменного объекта.</param>
    /// <param name="lockUpdateRegister">Выполнить регистрацию критической секции доменного объекта при его получении из реестра.</param>
    /// <param name="throwIfNotFound">Создать исключение <see cref="InternalException"/> если доменнный объект не найден.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <exception cref="InternalException">Если доменнный объект не найден.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<TDomainObject?> FindAsync<TDomainObject>(
        this ICustomEntryPoint entryPoint,
        long identity,
        bool lockUpdateRegister = false,
        bool throwIfNotFound = false,
        CancellationToken cancellationToken = default)
        where TDomainObject : IDomainObject
    {
        if (lockUpdateRegister)
        {
            var lockService = entryPoint.UnitOfWorkLocks.GetLockService<TDomainObject>();
            lockService.Register(identity);
        }

        var result = await entryPoint.UnitOfWorkProvider.Instance.FindAsync<TDomainObject>(identity, cancellationToken).ConfigureAwait(false);

        if ((result is null) && throwIfNotFound)
        {
            throw new InternalException($"Не найден доменный объект '{typeof(TDomainObject).AssemblyQualifiedName}' с идентити '{identity}'.");
        }

        return result;
    }

    /// <summary>
    /// Найти доменный объект по идентитити.
    /// </summary>
    /// <typeparam name="TDomainObject">Интерфейс доменного объекта.</typeparam>
    /// <param name="entryPoint">Точка входа.</param>
    /// <param name="identity">Идентитити доменного объекта.</param>
    /// <param name="lockUpdateRegister">Выполнить регистрацию критической секции доменного объекта при его получении из реестра.</param>
    /// <param name="throwIfNotFound">Создать исключение <see cref="InternalException"/> если доменнный объект не найден.</param>
    /// <exception cref="InternalException">Если доменнный объект не найден.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TDomainObject? Find<TDomainObject>(
        this ICustomEntryPoint entryPoint,
        long identity,
        bool lockUpdateRegister = false,
        bool throwIfNotFound = false)
        where TDomainObject : IDomainObject
    {
        if (lockUpdateRegister)
        {
            var lockService = entryPoint.UnitOfWorkLocks.GetLockService<TDomainObject>();
            lockService.Register(identity);
        }

        var result = entryPoint.UnitOfWorkProvider.Instance.Find<TDomainObject>(identity);

        if ((result is null) && throwIfNotFound)
        {
            throw new InternalException($"Не найден доменный объект '{typeof(TDomainObject).AssemblyQualifiedName}' с идентити '{identity}'.");
        }

        return result;
    }
}
