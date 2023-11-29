using RestSharp;
using RestSharp.Serializers;
using RestSharp.Serializers.NewtonsoftJson;
using ShtrihM.DemoServer.Processing.Api.Common;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.Common.Interfaces;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Utils;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace ShtrihM.DemoServer.Processing.Api.Clients;

public sealed class ProcessingClient : IProcessingClient
{
    private IRestClient m_restClient;
    private readonly bool m_disposeRestClient;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once MemberCanBePrivate.Global
    public ProcessingClient(
        IRestClient restClient,
        bool disposeRestClient = false)
        // ReSharper disable once ConvertToPrimaryConstructor
    {
        m_restClient = restClient;
        m_disposeRestClient = disposeRestClient;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ProcessingClient(
        HttpClient httpClient,
        bool disposeHttpClient = false)
        : this(
            new RestClient(
                httpClient,
                disposeHttpClient: disposeHttpClient,
                configureSerialization: s => UpdateSerializerConfig(s)),
            true)
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public async ValueTask<MetaServerDescription> GetDescriptionAsync(
        CancellationToken cancellationToken = default)
    {
        var request = new RestRequest(ServerControllerConstants.MethodDescription.UrlSuffix);
        var response = await m_restClient.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
        var result = ReadResponse<MetaServerDescription>(response);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public async ValueTask<DemoObjectInfo> DemoObjectReadAsync(
        long id,
        CancellationToken cancellationToken = default)
    {
        var request =
            new RestRequest(DemoObjectControllerConstants.MethodRead.UrlSuffix)
                .AddQueryParameter(DemoObjectControllerConstants.MethodRead.Arguments.Id, id.ToString(CultureInfo.InvariantCulture));
        var response = await m_restClient.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
        var result = ReadResponse<DemoObjectInfo>(response);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public async ValueTask<DemoObjectInfo> DemoObjectCreateAsync(
        DemoObjectCreate parameters,
        CancellationToken cancellationToken = default)
    {
        var request =
            new RestRequest(DemoObjectControllerConstants.MethodCreate.UrlSuffix, Method.Post)
                .AddJsonBody(parameters);
        var response = await m_restClient.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
        var result = ReadResponse<DemoObjectInfo>(response);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public async ValueTask<DemoObjectInfo> DemoObjectUpdateAsync(
        DemoObjectUpdate parameters,
        CancellationToken cancellationToken = default)
    {
        var request =
            new RestRequest(DemoObjectControllerConstants.MethodUpdate.UrlSuffix, Method.Post)
                .AddJsonBody(parameters);
        var response = await m_restClient.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
        var result = ReadResponse<DemoObjectInfo>(response);

        return result;
    }

    #region Helpers

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once UnusedMethodReturnValue.Global
    public static SerializerConfig UpdateSerializerConfig(SerializerConfig config)
    {
        config.UseNewtonsoftJson(JsonExtensions.CreateSettings());

        return config;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private T ReadResponse<T>(RestResponse response)
    {
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var result = m_restClient.Serializers.DeserializeContent<T>(response);

            if (result == null)
            {
                ThrowsHelper.ThrowInvalidOperationException("Не удалось прочитать ответ.");
            }

            return result!;
        }

        if (response.StatusCode == HttpStatusCode.Conflict)
        {
            var workflowExceptionData = m_restClient.Serializers.DeserializeContent<WorkflowExceptionData>(response);

            if (workflowExceptionData == null)
            {
                ThrowsHelper.ThrowInvalidOperationException("Не удалось прочитать ошибку в ответе.");
            }

            workflowExceptionData!.Throw();
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            ThrowsHelper.ThrowInvalidOperationException($@"Ошибка '{response.StatusCode}'
{response.Content}");
        }

        response.ThrowIfError();

        ThrowsHelper.ThrowInvalidOperationException($"Ошибка '{response.StatusCode}'.");

        return default!;
    }

    #endregion

    public void Dispose()
    {
        if (m_disposeRestClient)
        {
            CommonWattleExtensions.SilentDisposeAndFree(ref m_restClient);
        }
    }
}