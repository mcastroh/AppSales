﻿using System.Text;
using System.Text.Json;

namespace Sales.WEB.Repositories;

public class Repository : IRepository
{
    private readonly HttpClient _httpClient;

    private JsonSerializerOptions _jsonDefaultOptions => new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    };

    public Repository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseWrapper<T>> GetAsync<T>(string url)
    {
        var responseHttp = await _httpClient.GetAsync(url);

        if (responseHttp.IsSuccessStatusCode)
        {
            var response = await UnserializeAnswer<T>(responseHttp, _jsonDefaultOptions);
            return new HttpResponseWrapper<T>(response, false, responseHttp);
        }

        return new HttpResponseWrapper<T>(default, true, responseHttp);
    }

    public async Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model)
    {
        var mesageJSON = JsonSerializer.Serialize(model);
        var messageContet = new StringContent(mesageJSON, Encoding.UTF8, "application/json");
        var responseHttp = await _httpClient.PostAsync(url, messageContet);
        return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
    }

    public async Task<HttpResponseWrapper<TResponse>> PostAsync<T, TResponse>(string url, T model)
    {
        var messageJSON = JsonSerializer.Serialize(model);
        var messageContet = new StringContent(messageJSON, Encoding.UTF8, "application/json");
        var responseHttp = await _httpClient.PostAsync(url, messageContet);

        if (responseHttp.IsSuccessStatusCode)
        {
            var response = await UnserializeAnswer<TResponse>(responseHttp, _jsonDefaultOptions);
            return new HttpResponseWrapper<TResponse>(response, false, responseHttp);
        }

        return new HttpResponseWrapper<TResponse>(default, !responseHttp.IsSuccessStatusCode, responseHttp);
    }

    public async Task<HttpResponseWrapper<object>> PutAsync<T>(string url, T model)
    {
        var messageJSON = JsonSerializer.Serialize(model);
        var messageContent = new StringContent(messageJSON, Encoding.UTF8, "application/json");
        var responseHttp = await _httpClient.PutAsync(url, messageContent);
        return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
    }

    public async Task<HttpResponseWrapper<TResponse>> PutAsync<T, TResponse>(string url, T model)
    {
        var messageJSON = JsonSerializer.Serialize(model);
        var messageContent = new StringContent(messageJSON, Encoding.UTF8, "application/json");
        var responseHttp = await _httpClient.PutAsync(url, messageContent);
        if (responseHttp.IsSuccessStatusCode)
        {
            var response = await UnserializeAnswer<TResponse>(responseHttp, _jsonDefaultOptions);
            return new HttpResponseWrapper<TResponse>(response, false, responseHttp);
        }

        return new HttpResponseWrapper<TResponse>(default, !responseHttp.IsSuccessStatusCode, responseHttp);
    }

    public async Task<HttpResponseWrapper<object>> DeleteAsync(string url)
    {
        var responseHTTP = await _httpClient.DeleteAsync(url);
        return new HttpResponseWrapper<object>(null, !responseHTTP.IsSuccessStatusCode, responseHTTP);
    }

    private async Task<T> UnserializeAnswer<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
    {
        var respuestaString = await httpResponse.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(respuestaString, jsonSerializerOptions)!;
    }
}