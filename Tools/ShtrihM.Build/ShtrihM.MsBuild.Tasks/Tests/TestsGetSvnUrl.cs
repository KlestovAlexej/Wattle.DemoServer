using System;
using System.IO;
using NUnit.Framework;

namespace ShtrihM.MsBuild.Tasks.Tests
{
    [TestFixture]
    public class TestsGetSvnUrl
    {
        [Test]
        public void Test()
        {
            var task = 
                new GetSvnUrl
                {
                    Path = new DirectoryInfo(@"C:\Dev\Wattle3").FullName,
                };
            Assert.IsTrue(task.Execute());
            Console.WriteLine(task.Result);
        }
    }
}
