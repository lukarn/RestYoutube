using Newtonsoft.Json;

namespace ESimMainTasks.DataEntities
{
    public class ResponseVideosItems
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("snippet")]
        public ResponseVideosItemsSnippet Snippet { get; set; }






    }
}
