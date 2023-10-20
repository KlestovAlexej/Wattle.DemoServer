using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.Diagnostics;

namespace ShtrihM.MsBuild.Tasks
{
    /// <summary>
    /// Получение URL папки в SVN.
    /// </summary>
    public class GetSvnUrl : Task
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

                    if (line.StartsWith(@"URL: "))
                    {
                        var index = @"URL: ".Length;
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
