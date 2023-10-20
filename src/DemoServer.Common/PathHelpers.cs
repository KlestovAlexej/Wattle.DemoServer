using ShtrihM.Wattle3.Primitives;
using System.IO;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Common;

public static class PathHelpers
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetBasedPath(string basePath, string path)
    {
        if (basePath == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(basePath));
        }

        if (path == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(path));
        }

        var result = path;

        if (!Path.IsPathRooted(path))
        {
            result = Path.GetFullPath(Path.Combine(basePath!, path!));
        }

        return (result);
    }
}