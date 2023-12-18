﻿// <auto-generated />
using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

#pragma warning disable 219, 612, 618
#nullable disable

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModelsOptimized
{
    internal partial class PdSystemLogEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels.PdSystemLog",
                typeof(PdSystemLog),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(long),
                propertyInfo: typeof(PdSystemLog).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PdSystemLog).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                sentinel: 0L);
            id.TypeMapping = LongTypeMapping.Default.Clone(
                comparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v),
                keyComparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v),
                providerValueComparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v));
            id.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            id.AddAnnotation("Relational:ColumnName", "id");

            var code = runtimeEntityType.AddProperty(
                "Code",
                typeof(int),
                propertyInfo: typeof(PdSystemLog).GetProperty("Code", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PdSystemLog).GetField("<Code>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0);
            code.TypeMapping = IntTypeMapping.Default.Clone(
                comparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                keyComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "integer"));
            code.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            code.AddAnnotation("Relational:ColumnName", "code");

            var createdate = runtimeEntityType.AddProperty(
                "Createdate",
                typeof(DateTime),
                propertyInfo: typeof(PdSystemLog).GetProperty("Createdate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PdSystemLog).GetField("<Createdate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            createdate.TypeMapping = NpgsqlTimestampTzTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                keyComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                providerValueComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v));
            createdate.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            createdate.AddAnnotation("Relational:ColumnName", "createdate");

            var data = runtimeEntityType.AddProperty(
                "Data",
                typeof(string),
                propertyInfo: typeof(PdSystemLog).GetProperty("Data", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PdSystemLog).GetField("<Data>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            data.TypeMapping = StringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    dbType: System.Data.DbType.String));
            data.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            data.AddAnnotation("Relational:ColumnName", "data");

            var message = runtimeEntityType.AddProperty(
                "Message",
                typeof(string),
                propertyInfo: typeof(PdSystemLog).GetProperty("Message", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PdSystemLog).GetField("<Message>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 1024);
            message.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "character varying(1024)",
                    size: 1024));
            message.TypeMapping = ((NpgsqlStringTypeMapping)message.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
        message.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        message.AddAnnotation("Relational:ColumnName", "message");

        var type = runtimeEntityType.AddProperty(
            "Type",
            typeof(int),
            propertyInfo: typeof(PdSystemLog).GetProperty("Type", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(PdSystemLog).GetField("<Type>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            sentinel: 0);
        type.TypeMapping = IntTypeMapping.Default.Clone(
            comparer: new ValueComparer<int>(
                (int v1, int v2) => v1 == v2,
                (int v) => v,
                (int v) => v),
            keyComparer: new ValueComparer<int>(
                (int v1, int v2) => v1 == v2,
                (int v) => v,
                (int v) => v),
            providerValueComparer: new ValueComparer<int>(
                (int v1, int v2) => v1 == v2,
                (int v) => v,
                (int v) => v),
            mappingInfo: new RelationalTypeMappingInfo(
                storeTypeName: "integer"));
        type.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        type.AddAnnotation("Relational:ColumnName", "type");

        var key = runtimeEntityType.AddKey(
            new[] { id });
        runtimeEntityType.SetPrimaryKey(key);

        return runtimeEntityType;
    }

    public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
    {
        runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
        runtimeEntityType.AddAnnotation("Relational:Schema", null);
        runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
        runtimeEntityType.AddAnnotation("Relational:TableName", "systemlog");
        runtimeEntityType.AddAnnotation("Relational:ViewName", null);
        runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

        Customize(runtimeEntityType);
    }

    static partial void Customize(RuntimeEntityType runtimeEntityType);
}
}
