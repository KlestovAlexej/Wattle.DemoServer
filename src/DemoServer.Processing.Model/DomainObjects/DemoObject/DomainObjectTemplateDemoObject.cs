using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable IDE0290

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObject;

public class DomainObjectTemplateDemoObject : IDomainObjectTemplate
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DomainObjectTemplateDemoObject(
        string name,
        bool enabled)
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

        return entryPoint!.NewAsync<IDomainObjectDemoObject>(this, cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IDomainObjectDemoObject New(ICustomEntryPoint entryPoint)
    {
        if (entryPoint == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(entryPoint));
        }

        return entryPoint!.New<IDomainObjectDemoObject>(this);
    }
}
