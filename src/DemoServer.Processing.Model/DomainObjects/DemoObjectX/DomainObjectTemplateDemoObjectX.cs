using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

public class DomainObjectTemplateDemoObjectX : IDomainObjectTemplate
{
    public DomainObjectTemplateDemoObjectX(
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
