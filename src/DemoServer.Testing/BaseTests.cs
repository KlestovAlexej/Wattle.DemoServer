using NUnit.Framework;
using ShtrihM.Wattle3.Testing;
using System.Globalization;
using System.Text;

namespace ShtrihM.DemoServer.Testing;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public class BaseTests : Wattle3.Testing.BaseTests
{
    public static readonly string Configuration =
#if RELEASE
            "Release"
#else
            "Debug"
#endif
        ;

    protected bool m_validateConfiguration;

    static BaseTests()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

        ProjectBasePath.Provider = new ProviderProjectBasePath();
    }

    [SetUp]
    public void BaseTests_SetUp()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

        BeforeSetUp();

        if (m_validateConfiguration)
        {
            Assert.AreEqual("Debug", Configuration);
        }
    }

    protected virtual void BeforeSetUp()
    {
        m_validateConfiguration = true;
    }
}