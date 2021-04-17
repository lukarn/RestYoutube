using ESimMainTasks.DataEntities;
using FluentAssertions;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Net;
using TechTalk.SpecFlow;

namespace RestYoutube.Steps
{
    [Binding]
    public sealed class GetStartedRestApiStepDefinitions
    {
        RestClient client;
        RestRequest request;
        IRestResponse response;

        [Given(@"the client setup")]
        public void GivenTheClientSetup()
        {
            client = new RestClient("http://api.zippopotam.us");
        }

        [Given(@"the request setup")]
        public void GivenTheRequestSetup()
        {
            request = new RestRequest("us/12345", Method.GET);
            //  us/90210
            //  nl/3825
            //  us/12345
        }

        [When(@"send request")]
        public void WhenSendRequest()
        {
            response = client.Execute(request);
        }

        [Then(@"the response status code should be OK")]
        public void ThenTheResponseStatusCodeShouldBeOK()
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Then(@"the response type should be json")]
        public void ThenTheResponseTypeShouldBeJson()
        {
            response.ContentType.Should().Be("application/json");
        }

        [Then(@"the response location should be US")]
        public void ThenTheResponseLocationShouldBeUS()
        {
            (new JsonDeserializer().Deserialize<LocationResponse>(response)).CountryAbbreviation.Should().Be("US");
        }

        [Then(@"the response place should be ""(.*)""")]
        public void ThenTheResponsePlaceShouldBe(string expectedPlace)
        {
            (new JsonDeserializer().Deserialize<LocationResponse>(response)).Places[0].State.Should().Be(expectedPlace);
        }

    }
}
