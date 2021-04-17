using ESimMainTasks.DataEntities;
using FluentAssertions;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace RestYoutube.Steps
{
    [Binding]
    public sealed class YouTubeRestApiTestStepDefinitions
    {
        private static readonly string accessTocken = "key=AIzaSyCvVbrmB15PnnZsqofG1W-8aSSkVun4894";

        RestClient client;
        RestRequest request;
        IRestResponse response;

        RequestBuilder requestBuilder;

        [Given(@"Launch Rest client ""(.*)""")]
        public void GivenLaunchRestClient(string serviceUrl)
        {
            client = new RestClient(serviceUrl);
        }

        [Given(@"Build request select endpoint ""(.*)"" and auth")]
        public void GivenBuildRequestSelectEndpointAndAuth(string endpoint)
        {
            requestBuilder = new RequestBuilder(endpoint, accessTocken);
        }

        [Given(@"Build request add param ""(.*)"" with value ""(.*)""")]
        public void GivenBuildRequestAddParamWithValue(string parameterName, string parameterValue)
        {
            requestBuilder.AddEndpointParameter(parameterName, parameterValue);
        }

        [Given(@"Build get request from steps above")]
        public void GivenBuildGetRequestFromStepsAbove()
        {
            request = new RestRequest(requestBuilder.GetRequestBody(), Method.GET);
        }

        [When(@"I send request")]
        public void WhenISendRequest()
        {
            Console.WriteLine("===========================");
            Console.WriteLine(requestBuilder.GetRequestBody());
            Console.WriteLine("===========================");
            response = client.Execute(request);
        }

        [Then(@"Response status code should be OK")]
        public void ThenResponseStatusCodeShouldBeOK()
        {
            Console.WriteLine("===========================");
            Console.WriteLine(response.Content);
            Console.WriteLine("===========================");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Then(@"Check if response contains ""(.*)""")]
        public void ThenCheckIfResponseContains(string text)
        {
            (new JsonDeserializer().Deserialize<ResponseVideos>(response).Items[0].Snippet.Title).Should().Be(text);
        }

    }
}
