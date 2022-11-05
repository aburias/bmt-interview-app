using RestSharp;

namespace bmt.contact.web.Helpers
{
    public static class ApiHelpers 
    {
        public static async Task<TResult?> ExecuteApiAsync<TResult>(string baseUrl, string endpoint, Method method, Dictionary<string, string>? headers, object? body) where TResult : class, new()
        {
            using (var client = new RestClient(baseUrl))
            {
                var request = new RestRequest(endpoint, method);
                
                if(headers is not null && headers.Any())
                {
                    foreach (var header in headers)
                        request.AddHeader(header.Key, header.Value);
                }
                
                if(body is not null)
                    request.AddJsonBody(body);

                var response = await client.ExecuteAsync<TResult>(request);
                return response.IsSuccessful ? response.Data : null;
            }
        }
    }
}
