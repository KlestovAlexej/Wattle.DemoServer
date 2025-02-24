using NUnit.Framework;
using Acme.DemoServer.Common;
using Acme.DemoServer.Processing.DataAccess.PostgreSql;
using Acme.Wattle.Testing.Databases.PostgreSql;
using System.Diagnostics.CodeAnalysis;
using Acme.DemoServer.Testing;

// ReSharper disable once CheckNamespace
namespace Acme.DemoServer.Processing.Generated.Tests;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public abstract partial class BaseAutoTestsMapper
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected string m_serverConnectionString;
    protected string m_dbName;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected bool m_dropDb;
    protected bool m_addTags;

    partial void DoBase_BeginSetUp()
    {
        m_dropDb = true;
        m_dbName = $"test_{Constants.ProductTag.ToLower()}_" + BaseDbTests.UniqueMark();
        var sqlScript = Deploy.GetSqlScript();

        DoPreCreateDb();

        /*
        Если адрес, логин и пароль БД PostgreSQL не указаны явно то они берутся из реестра Windows.
        Файл с настройками реестра.
        src\DemoServer.Testing\WindowsRegisterTestingEnvirioment.reg
        */
        m_serverConnectionString = PostgreSqlDbHelper.GetServerConnectionString(userCredentials: BaseDbTests.PostgreSqlUserCredentials, serverAdress: BaseDbTests.PostgreSqlServerAdress);

        /*
        Если адрес, логин и пароль БД PostgreSQL не указаны явно то они берутся из реестра Windows.
        Файл с настройками реестра.
        src\DemoServer.Testing\WindowsRegisterTestingEnvirioment.reg
        */
        m_dbConnectionString = PostgreSqlDbHelper.GetDatabaseConnectionString(m_dbName, userCredentials: BaseDbTests.PostgreSqlUserCredentials, serverAdress: BaseDbTests.PostgreSqlServerAdress);

        PostgreSqlDbHelper.CreateDb(
            m_dbName,
            tag: m_addTags ? TestContext.CurrentContext.Test.FullName : null,
            sqlScript: sqlScript,
            serverConnectionString: m_serverConnectionString,
            databaseConnectionString: m_dbConnectionString,
            lcCollate: null,
            lcType: null);
    }

    partial void DoBase_TearDown()
    {
        if (m_dropDb)
        {
            PostgreSqlDbHelper.DropDb(
                m_dbName,
                serverConnectionString: m_serverConnectionString);
        }
    }

    protected virtual void DoPreCreateDb()
    {
        /* NONE */
    }
}