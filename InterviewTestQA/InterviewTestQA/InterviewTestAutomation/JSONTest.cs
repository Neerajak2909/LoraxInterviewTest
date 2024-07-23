using InterviewTestQA.InterviewTestAutomation;
using Newtonsoft.Json;
using Xunit;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace InterviewTestQA
{
    public class JSONTest
    {
        [Fact]
        public void TestDeserialization()
        {
            // Read the Json file
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "InterviewTestAutomation/Data", "Cost Analysis.json");
            string json = File.ReadAllText(jsonFilePath);

            // Deserialize the Json into a list of Cost Analysis objects
            var costAnalysisList = JsonConvert.DeserializeObject<List<CostAnalysis>>(json);

            // Assert the number of items in the list
            Assert.Equal(53, costAnalysisList.Count);
        }
    }
}