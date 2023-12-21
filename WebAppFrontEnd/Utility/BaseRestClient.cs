using RestSharp;

namespace WebAppFrontEnd.Utility
{
    public class BaseRestClient
    {
        private readonly ILogger<BaseRestClient> _logger;
        private RestClient _restClient;
        public BaseRestClient(RestClient restClient)
        {
            this._restClient = restClient;

        }



        private void RequestTimeoutCheck(RestRequest request, RestResponse response)
        {
            if (response.StatusCode == 0)
            {
                // log te response and request details
            }
        }

        public async Task<RestResponse> Execute(RestRequest request)
        {

            var response = await this._restClient.ExecuteAsync(request);
            RequestTimeoutCheck(request, response);

            //if ((int)response.StatusCode >= 400)
            // throw new ExternalSystemException(response.Content, response.StatusCode, String.Empty);

            return response;
        }
        public async Task<RestResponse<T>> Execute<T>(RestRequest request, CancellationToken cancellationToken = default)
        {
            var response = await this._restClient.ExecuteAsync<T>(request, cancellationToken);
            RequestTimeoutCheck(request, response);

            //if ((int)response.StatusCode >= 400)
            //throw new ExternalSystemException(response.Content, response.StatusCode, String.Empty);

            return response;
        }

        public T Get<T>(RestRequest request) where T : new()
        {
            try
            {
                var response = Execute<T>(request).Result;


                if ((int)response.StatusCode >= 400)
                    throw new Exception();

                return response.Data;
            }

            catch (Exception exe)
            {

                throw exe;
            }
        }


        public RestResponse Get(RestRequest request)
        {
            var response = Execute(request).Result;
            return response;
        }

        public List<T> GetList<T>(RestRequest request) where T : new()
        {
            var response = Execute<List<T>>(request).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                return default(List<T>);
            }
        }
    }
}
