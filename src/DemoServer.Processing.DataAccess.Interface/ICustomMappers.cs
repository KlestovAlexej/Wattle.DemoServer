using Acme.Wattle.Mappers.Interfaces;
using System;
using System.Collections.Generic;

namespace Acme.DemoServer.Processing.DataAccess.Interface;

public interface ICustomMappers : IMappers
{
    IDictionary<Guid, string> GetSystemSettings(IMappersSession session);
}