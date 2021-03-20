using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace RestYoutube.Steps
{
    [Binding]
    public sealed class YouTubeRESTapiStepDefinitions
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
            request = new RestRequest("nl/3825", Method.GET);
        }

        [When(@"send request")]
        public void WhenSendRequest()
        {
            response = client.Execute(request);
        }

        [Then(@"the response status code should be OK")]
        public void ThenTheResponseStatusCodeShouldBeOK()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }


    }
}
