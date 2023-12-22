using System;
using Unity;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public static class UnityContainerHelpers
{
    public static bool TryResolve<T>(this IUnityContainer container, out T? result)
    {
        if (container.IsRegistered<T>())
        {
            result = container.Resolve<T>();

            return true;
        }

        result = default;

        return false;
    }

    public static T ResolveWithDefault<T>(this IUnityContainer container, Func<T> defaultValue)
    {
        if (TryResolve<T>(container, out var result))
        {
            return result!;
        }

        result = defaultValue();

        container.RegisterInstance(result, InstanceLifetime.External);

        return result;
    }
}