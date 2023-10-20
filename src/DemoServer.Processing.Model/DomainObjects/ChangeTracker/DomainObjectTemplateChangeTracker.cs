using ShtrihM.Wattle3.DomainObjects.Interfaces;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.ChangeTracker;

public class DomainObjectTemplateChangeTracker : IDomainObjectTemplate
{
    private DomainObjectTemplateChangeTracker()
    {
        /* NONE */
    }

    public static readonly DomainObjectTemplateChangeTracker Instance = new();
}