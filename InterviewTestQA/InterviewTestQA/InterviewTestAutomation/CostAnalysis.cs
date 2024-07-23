using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestQA.InterviewTestAutomation
{
    internal class CostAnalysis
    {
        [JsonProperty("YearId")]
        public string YearId { get; set; }

        [JsonProperty("GeoRegionId")]
        public int GeoRegionId { get; set; }

        [JsonProperty("CountryId")]
        public int CountryId { get; set; }

        [JsonProperty("RegionId")]
        public int RegionId { get; set; }

        [JsonProperty("SchemeId")]
        public int SchemeId { get; set; }

        [JsonProperty("SchmTypeId")]
        public int SchmTypeId { get; set; }

        [JsonProperty("Cost")]
        public double Cost { get; set; }
    }
}
