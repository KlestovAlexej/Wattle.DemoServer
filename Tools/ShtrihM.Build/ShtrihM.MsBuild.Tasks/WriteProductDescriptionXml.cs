using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.Xml.Linq;

namespace ShtrihM.MsBuild.Tasks
{
    /// <summary>
    /// Записать файл с описанием продукта.
    /// </summary>
    public class WriteProductDescriptionXml : Task
    {
        public override bool Execute()
        {
            var text = @"<Product>
   <Version>@Version@</Version>
   <FileVersion>@FileVersion@</FileVersion>
   <IsReleased>@IsReleased@</IsReleased>
   <BuildDate>@BuildDate@</BuildDate>
   <SvnURL>@SvnURL@</SvnURL>
   <Comment>@Comment@</Comment>
</Product>";

            text = text.Replace("@Version@", AssemblyVersion);
            text = text.Replace("@FileVersion@", AssemblyFileVersion);
            text = text.Replace("@IsReleased@", IsReleased.ToString());
            text = text.Replace("@BuildDate@", BuildDate);
            text = text.Replace("@SvnURL@", SvnUrl);
            text = text.Replace("@Comment@", Comment);

            System.IO.File.WriteAllText(Path, text, Encoding.GetEncoding(1251));

            return true;
        }

        [Required]
        public string AssemblyVersion { get; set; }

        [Required]
        public string AssemblyFileVersion { get; set; }

        [Required]
        public bool IsReleased { get; set; }

        [Required]
        public string BuildDate { get; set; }

        [Required]
        public string SvnUrl { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}