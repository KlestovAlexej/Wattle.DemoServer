using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Primitives;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

public static class UnitOfWorkExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask<T> FindAsync<T>(
        this ICustomEntryPoint entryPoint,
        long id,
        CancellationToken cancellationToken = default)
        where T : IDomainObject
    {
        if (entryPoint == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(entryPoint));
        }

        return entryPoint!.UnitOfWorkProvider.Instance.FindAsync<T>(id, cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Find<T>(
        this ICustomEntryPoint entryPoint,
        long id)
        where T : IDomainObject
    {
        if (entryPoint == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(entryPoint));
        }

        var result = entryPoint!.UnitOfWorkProvider.Instance.Find<T>(id);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask<T> NewAsync<T>(
        this ICustomEntryPoint entryPoint,
        IDomainObjectTemplate template,
        CancellationToken cancellationToken = default)
        where T : IDomainObject
    {
        if (entryPoint == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(entryPoint));
        }

        if (template == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(template));
        }

        return entryPoint!.UnitOfWorkProvider.Instance.NewAsync<T>(template, cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T New<T>(
        this ICustomEntryPoint entryPoint,
        IDomainObjectTemplate template)
        where T : IDomainObject
    {
        if (entryPoint == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(entryPoint));
        }

        if (template == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(template));
        }

        return entryPoint!.UnitOfWorkProvider.Instance.New<T>(template);
    }
}