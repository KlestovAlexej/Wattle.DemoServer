using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.Generated.Interface;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Mappers.Interfaces;
using ITrigger = Acme.Wattle.DomainObjects.Interfaces.ITrigger;

namespace Acme.DemoServer.Processing.Model.Implements;

public class PartitionsSponsor : BasePartitionsSponsor
{
    private readonly IMapperTablePartition m_mapperTablePartition;

    // ReSharper disable once ConvertToPrimaryConstructor
    public PartitionsSponsor(
        ICustomEntryPoint entryPoint,
        ITrigger trigger)
        : base(
            trigger,
            entryPoint.LoggerFactory,
            entryPoint.ExceptionPolicy,
            entryPoint.TimeService,
            entryPoint.Mappers,
            entryPoint.PartitionsDay,
            entryPoint.Tracer,
            entryPoint.SystemSettings.PartitionsSponsor.Value,
            WellknownDomainObjects.TablePartition)
    {
        m_mapperTablePartition = entryPoint.Mappers.GetMapper<IMapperTablePartition>();
    }

    protected override long GetNextId(IMappersSession session)
    {
        var result = m_mapperTablePartition.GetNextId(session);

        return result;
    }

    protected override void InsertPartitionInfo(IMappersSession session, TablePartitionEntry entry)
    {
        m_mapperTablePartition.New(
            session,
            new TablePartitionDtoNew
            {
                Id = entry.Id,
                Day = entry.Day,
                CreateDate = entry.CreateDate,
                MaxNotIncludeGroupId = entry.MaxNotIncludeGroupId,
                MaxNotIncludeId = entry.MaxNotIncludeId,
                MinGroupId = entry.MinGroupId,
                MinId = entry.MinId,
                PartitionName = entry.PartitionName,
                TableName = entry.TableName,
            });
    }
}