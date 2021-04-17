using Newtonsoft.Json;
using System.Collections.Generic;

namespace ESimMainTasks.DataEntities
{
    public class ResponseVideos
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("items")]
        public List<ResponseVideosItems> Items { get; set; }

        [JsonProperty("pageInfo")]
        public ResponseVideosPageInfo PageInfo { get; set; }

        [JsonProperty("snippet")]
        public ResponseVideosItemsSnippet Snippet { get; set; }

    }
}