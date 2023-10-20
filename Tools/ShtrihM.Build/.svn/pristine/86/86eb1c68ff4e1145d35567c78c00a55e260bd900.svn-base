using System;
using System.IO;
using NUnit.Framework;

namespace ShtrihM.MsBuild.Tasks.Tests
{
    [TestFixture]
    public class TestsGetSvnRevision
    {
        [Test]
        public void Test()
        {
            var task =
                new GetSvnRevision
                {
                    Path = new DirectoryInfo(@"C:\Dev\Wattle3").FullName,
                };
            Assert.IsTrue(task.Execute());
            Console.WriteLine(task.Result);
        }
    }
}