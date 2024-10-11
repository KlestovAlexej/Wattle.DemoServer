using System.IO;
using System.Runtime.CompilerServices;

namespace Acme.DemoServer.Common;

public static class PathHelpers
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetBasedPath(string basePath, string path)
    {
        var result = path;

        if (false == Path.IsPathRooted(path))
        {
            result = Path.GetFullPath(Path.Combine(basePath, path));
        }

        return (result);
    }
}