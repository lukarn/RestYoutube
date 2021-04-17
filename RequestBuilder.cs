using System;
using System.Collections.Generic;
using System.Text;

namespace RestYoutube
{
    sealed class RequestBuilder
    {
        private static string _endpoint;

        private string _endpointParameters;

        private static string _authParamethers;

        public RequestBuilder(string endpoint, string authParamethers)
        {
            _endpoint = endpoint;
            _authParamethers = authParamethers;
            _endpointParameters = "?";
        }

        public void AddEndpointParameter(string paramName, string paramValue)
        {
            _endpointParameters = _endpointParameters + paramName + "=" + paramValue + "&";
        }

        public string GetRequestBody()
        {
            string requestBody = _endpoint + _endpointParameters + _authParamethers;
            return requestBody;
        }


    }
}
