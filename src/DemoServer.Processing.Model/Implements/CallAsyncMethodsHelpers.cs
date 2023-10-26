using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Utils;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public static class CallAsyncMethodsHelpers
{
    private static readonly MethodInfo MethodInfoValueTaskFromResult = typeof(ValueTask).GetMethod(nameof(ValueTask.FromResult), BindingFlags.Public | BindingFlags.Static);
    private static readonly MethodInfo MethodInfoGetResultValueTask1 = typeof(CallAsyncMethodsHelpers).GetMethod(nameof(GetResultValueTask1), BindingFlags.NonPublic | BindingFlags.Static);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Invoke(
        object instance, 
        MethodInfo method, 
        object[] args,
        out object result,
        out object taskResult)
    {
        if (instance == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(instance));
        }
        if (method == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(instance));
        }
        if (args == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(instance));
        }

        result = method!.Invoke(instance, args);

        if (method.ReturnType.IsGenericType && (method.ReturnType.GetGenericTypeDefinition() == typeof(ValueTask<>)))
        {
            var returnTypes = method.ReturnType.GetGenericArguments();
            var methodInfoGetResultValueTask = MethodInfoGetResultValueTask1.MakeGenericMethod(returnTypes);
            var methodInfoValueTaskFromResult = MethodInfoValueTaskFromResult.MakeGenericMethod(returnTypes);

            taskResult = methodInfoGetResultValueTask.Invoke(null, new[] { result });
            result = methodInfoValueTaskFromResult.Invoke(null, new[] { taskResult });

            return true;
        }

        taskResult = null;

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T GetResultValueTask1<T>(ValueTask<T> task)
    {
        var result = task.SafeGetResult();

        return result;
    }
}