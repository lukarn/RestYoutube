using Newtonsoft.Json;

namespace ESimMainTasks.DataEntities
{
    public class ResponseVideosPageInfo
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("resultsPerPage")]
        public int ResultsPerPage { get; set; }

    }
}
