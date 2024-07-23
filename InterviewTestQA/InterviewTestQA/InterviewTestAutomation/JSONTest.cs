using InterviewTestQA.InterviewTestAutomation;
using Newtonsoft.Json;
using Xunit;
using System.Collections.Generic;
using System.IO;
using Xunit;
using System.Xml.Linq;
using System.Collections;
using Xunit.Abstractions;
using ThirdParty.Json.LitJson;
using System.Transactions;

namespace InterviewTestQA
{
    public class JSONTest
    {
        private readonly ITestOutputHelper output;

        public JSONTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestDeserialization()
        {
            // Read the Json file
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "InterviewTestAutomation", "Data", "Cost Analysis.json");
            string json = File.ReadAllText(jsonFilePath);

            // Deserialize the Json into a variable containing list of Json Objects
            var costAnalysisList = JsonConvert.DeserializeObject<List<CostAnalysis>>(json);

            // Assert the number of items in the list
            int expectedCount = 53;
            Assert.Equal(expectedCount, costAnalysisList.Count);
            output.WriteLine($"Total Number of items in the list: {costAnalysisList.Count}");
            
            // Fetch the top item for  from the list and sort Cost in descending order
            var topItem = costAnalysisList.OrderByDescending(item => item.Cost).FirstOrDefault();

            // Assert the top item exists
            Assert.NotNull(topItem);
            output.WriteLine($"Top Item in the list which is maximum cost : {topItem.Cost}");

            // Assert the Country ID of the top item
            int expectedCountryId = 0;
            Assert.Equal(expectedCountryId, topItem.CountryId);
            output.WriteLine($"Top Country in the list: {topItem.CountryId}");
            
            // Calculate Sum of cost for the Year 2016
            var sumOfCost = costAnalysisList.Where(item => item.YearId.Equals("2016")).Sum(item  => item.Cost);

            // Assert the Total Sum of cost for Year 2016
            double expectedSumOfCost = 77911.374456100006;
            Assert.Equal(expectedSumOfCost, sumOfCost);
            output.WriteLine($"Total Sum of Costs for Year ID 2016 is : {sumOfCost}");
        }
    }
}
