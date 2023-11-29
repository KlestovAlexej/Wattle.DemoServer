using NUnit.Framework;
using ShtrihM.Wattle3.Testing.Databases.PostgreSql;
using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace ShtrihM.DemoServer.Testing;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public abstract class BaseDbTests : BaseSlimTests
{
    /*
    Если адрес, логин и пароль БД PostgreSQL не указаны явно то они берутся из реестра Windows.
    Файл с настройками реестра.
    src\DemoServer.Testing\WindowsRegisterTestingEnvirioment.reg
    */
    public static readonly string? PostgreSqlServerAdress = null;

    /*
    Если адрес, логин и пароль БД PostgreSQL не указаны явно то они берутся из реестра Windows.
    Файл с настройками реестра.
    src\DemoServer.Testing\WindowsRegisterTestingEnvirioment.reg
    */
    public static readonly (string UserName, string UserPassword)? PostgreSqlUserCredentials = null;

    protected string m_serverConnectionString;
    protected string m_dbName;
    protected string m_dbConnectionString;
    protected bool m_dropDb;
    protected bool m_addTags;

    [SetUp]
    public void BaseDbTests_SetUp()
    {
        m_dropDb = true;
        m_addTags = true;
        m_dbName = DoGetDbName() + "_" + DateTime.Now.ToString("yyyMMddhhmmss") + "_" + Guid.NewGuid().ToString("N");
        var sqlScript = DoGetSqlScript();

        /*
        Если адрес, логин и пароль БД PostgreSQL не указаны явно то они берутся из реестра Windows.
        Файл с настройками реестра.
        src\DemoServer.Testing\WindowsRegisterTestingEnvirioment.reg
        */
        m_serverConnectionString = PostgreSqlDbHelper.GetServerConnectionString(userCredentials: PostgreSqlUserCredentials, serverAdress: PostgreSqlServerAdress);

        /*
        Если адрес, логин и пароль БД PostgreSQL не указаны явно то они берутся из реестра Windows.
        Файл с настройками реестра.
        src\DemoServer.Testing\WindowsRegisterTestingEnvirioment.reg
        */
        m_dbConnectionString = PostgreSqlDbHelper.GetDatabaseConnectionString(m_dbName, userCredentials: PostgreSqlUserCredentials, serverAdress: PostgreSqlServerAdress);

        DoPreCreateDb();

        PostgreSqlDbHelper.CreateDb(
            m_dbName,
            tag: m_addTags ? TestContext.CurrentContext.Test.FullName : null,
            sqlScript: sqlScript,
            serverConnectionString: m_serverConnectionString,
            databaseConnectionString: m_dbConnectionString);

        DoPostCreateDb();
    }

    [TearDown]
    public void BaseTests_TearDown()
    {
        if (m_dropDb)
        {
            PostgreSqlDbHelper.DropDb(
                m_dbName,
                serverConnectionString: m_serverConnectionString);

            DoPostDropDb();
        }
    }

    protected abstract string DoGetDbName();
    protected abstract string DoGetSqlScript();

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual void DoPostDropDb()
    {
        /* NONE */
    }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual void DoPreCreateDb()
    {
        /* NONE */
    }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual void DoPostCreateDb()
    {
        /* NONE */
    }
}