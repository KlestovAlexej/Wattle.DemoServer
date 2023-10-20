using System;
using Unity;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public static class UnityContainerHelpers
{
    public static bool TryResolve<T>(this IUnityContainer container, out T result)
    {
        if (container == null)
        {
            throw new ArgumentNullException(nameof(container));
        }

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
        if (container == null)
        {
            throw new ArgumentNullException(nameof(container));
        }

        if (defaultValue == null)
        {
            throw new ArgumentNullException(nameof(defaultValue));
        }

        if (TryResolve<T>(container, out var result))
        {
            return result;
        }

        result = defaultValue();

        container.RegisterInstance(result, InstanceLifetime.External);

        return result;
    }

    public static T ResolveWithDefault<T>(this IUnityContainer container, string name, Func<T> defaultValue)
    {
        if (container == null)
        {
            throw new ArgumentNullException(nameof(container));
        }

        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (defaultValue == null)
        {
            throw new ArgumentNullException(nameof(defaultValue));
        }

        if (TryResolve<T>(container, name, out var result))
        {
            return result;
        }

        result = defaultValue();

        container.RegisterInstance(name, result, InstanceLifetime.External);

        return result;
    }

    private static bool TryResolve<T>(this IUnityContainer container, string name, out T result)
    {
        if (container == null)
        {
            throw new ArgumentNullException(nameof(container));
        }

        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (container.IsRegistered<T>(name))
        {
            result = container.Resolve<T>(name);

            return true;
        }

        result = default;

        return false;
    }
}