using ShtrihM.Wattle3.Mappers.Interfaces;
using System;
using System.Collections.Generic;

namespace ShtrihM.DemoServer.Processing.DataAccess.Interface;

public interface ICustomMappers : IMappers
{
    IDictionary<Guid, string> GetSystemSettings(IMappersSession session);
}