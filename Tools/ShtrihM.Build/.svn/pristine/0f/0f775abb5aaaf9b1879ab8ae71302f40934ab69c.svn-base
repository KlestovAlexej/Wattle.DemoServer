using System.Diagnostics;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace ShtrihM.MsBuild.Tasks
{
    /// <summary>
    /// Получение ревизии папки в SVN.
    /// </summary>
    public class GetSvnRevision : Task
    {
        public override bool Execute()
        {
            Result = string.Empty;

            var proc = new Process();
            var startInfo =
                new ProcessStartInfo
                {
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(typeof(GetSvnUrl).Assembly.Location), @"svn\svn.exe"),
                    CreateNoWindow = true,
                    Arguments = $"info {Path}",
                    UseShellExecute = false,
                };

            proc.StartInfo = startInfo;

            Result = null;
            if (proc.Start())
            {
                while (true)
                {
                    var line = proc.StandardOutput.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    if (line.StartsWith(@"Revision: "))
                    {
                        var index = @"Revision: ".Length;
                        Result = line.Substring(index, line.Length - index);

                        break;
                    }
                }
                proc.WaitForExit();
            }

            if (Result == null)
            {
                return false;
            }

            return true;
        }

        [Required]
        public string Path { get; set; }

        [Output]
        public string Result { get; private set; }
    }
}