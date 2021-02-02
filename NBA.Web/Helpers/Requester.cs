using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NBA.Web.Models.Api;
using Newtonsoft.Json;

namespace NBA.Web.Helpers
{
    public class Requester : IRequester
    {
        private readonly string baseAddress;
        private readonly HttpClient client;
        private readonly Encoding encoding;

        public Requester()
        {
            baseAddress = ConfigurationManager.AppSettings["ApiBaseAddress"];
            client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
            encoding = AppConst.Encoding;
        }

        private static string BuildQuerystring(object data)
        {
            var stringBuilder = new StringBuilder().Append("?");
            var properties = data.GetType().GetProperties();
            for (var i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                if (!property.CanRead || !property.CanWrite || property.GetIndexParameters().Length > 0)
                    continue;
                var value = property.GetValue(data);
                if (value == null)
                    continue;
                stringBuilder.Append(property.Name).Append("=").Append(value);
                if (i != properties.Length - 1)
                    stringBuilder.Append("&");
            }
            return stringBuilder.ToString();
        }

        private async Task<Result<string>> SendPrivate(RequestInfo requestInfo)
        {
            var url = requestInfo.Url;
            url = url.StartsWith("/") ? url : $"/{url}";
            url = $"{baseAddress}{url}";

            var method = requestInfo.HttpMethod;
            HttpContent httpContent = null;

            var data = requestInfo.Data;
            if (data != null)
            {
                if (method == HttpMethod.Get || method == HttpMethod.Delete)
                    url += BuildQuerystring(data);
                else if (method == HttpMethod.Post || method == HttpMethod.Put)
                    httpContent = new StringContent(JsonConvert.SerializeObject(data), encoding, "application/json");
            }

            var request = new HttpRequestMessage(method, url);

            if (httpContent != null)
                request.Content = httpContent;

            var headers = requestInfo.Headers;
            if (headers != null && headers.Count > 0)
                foreach (var item in headers)
                    request.Headers.Add(item.Key, item.Value);

            var responseMessage = await client.SendAsync(request);
            if (!responseMessage.IsSuccessStatusCode)
                return Result<string>.NewFailure($"Api call failed with status code: {responseMessage.StatusCode}");

            var responseJsonString = await responseMessage.Content.ReadAsStringAsync();
            return Result<string>.NewSuccess(responseJsonString);
        }

        public async Task<Result> Send(RequestInfo requestInfo)
        {
            try
            {
                var result = await SendPrivate(requestInfo);
                if (result.Failed)
                    return Result.NewFailure(result.Message);

                var responseData = string.IsNullOrEmpty(result.Data)
                    ? new ApiResult { succeeded = true }
                    : JsonConvert.DeserializeObject<ApiResult>(result.Data);

                return new Result
                {
                    Failed = !responseData.succeeded,
                    Code = responseData.error == null ? default : responseData.error.code,
                    Message = responseData.error?.message
                };
            }
            catch (Exception ex)
            {
                return Result.NewException(ex);
            }
        }

        public async Task<Result<TResponse>> Send<TResponse>(RequestInfo requestInfo)
        {
            try
            {
                var result = await SendPrivate(requestInfo);
                if (result.Failed)
                    return Result<TResponse>.NewFailure(result.Message);

                var responseData = string.IsNullOrEmpty(result.Data)
                    ? new ApiResult<TResponse> { succeeded = true }
                    : JsonConvert.DeserializeObject<ApiResult<TResponse>>(result.Data);

                return new Result<TResponse>
                {
                    Failed = !responseData.succeeded,
                    Code = responseData.error == null ? default : responseData.error.code,
                    Message = responseData.error?.message,
                    Data = responseData.data
                };
            }
            catch (Exception ex)
            {
                return Result<TResponse>.NewException(ex);
            }
        }
    }
}