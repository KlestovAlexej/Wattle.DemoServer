using System;
using System.IO;
using ShtrihM.Wattle3.Testing;

#pragma warning disable CS1591

namespace ShtrihM.DemoServer.Testing
{
    [ProjectBasePath.ProviderProjectBasePath]
    // ReSharper disable once ClassNeverInstantiated.Global
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class ProviderProjectBasePath : ProjectBasePath.IProviderProjectBasePath
    {
        public string Path => ProjectPath;

        // ReSharper disable once MemberCanBePrivate.Global
        public static readonly string ProjectPath = @"C:\Dev\Wattle3.DemoServer\";

        public static void Register()
        {
            ProjectBasePath.Provider = new ProviderProjectBasePath();
        }

        public static string GetFullPath(string path, bool validatePath = true)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            var tempPath = System.IO.Path.Combine(ProjectPath, path);

            if (validatePath && (false == Directory.Exists(tempPath)))
            {
                throw new InvalidOperationException($"Путь '{tempPath}' не существует.");
            }

            var result = new DirectoryInfo(tempPath).FullName;

            return (result);
        }

        public static string GetFullPath(string path, string fileName, bool validatePath = true)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            var tempPath = System.IO.Path.Combine(ProjectPath, path);

            if (validatePath && (false == Directory.Exists(tempPath)))
            {
                throw new InvalidOperationException($"Путь '{tempPath}' не существует.");
            }

            var result = new DirectoryInfo(tempPath).FullName;

            tempPath = System.IO.Path.Combine(result, fileName);

            if (validatePath && (false == File.Exists(tempPath)))
            {
                throw new InvalidOperationException($"Файл '{tempPath}' не существует.");
            }

            result = new DirectoryInfo(System.IO.Path.Combine(result, fileName)).FullName;

            return (result);
        }
    }
}
