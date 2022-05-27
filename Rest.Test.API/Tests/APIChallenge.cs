
using Rest.Test.API.Helpers;
using RestSharp;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;


namespace Rest.Test.API.Tests
{
    [TestClass]
    public class APIChallenges
    {
        
        [TestMethod]
        public async Task TestMethodPostAsync()
        {
            Report.print("TestCase Execution started");
            RestClient client = new RestClient("https://apichallenges.herokuapp.com/challenger");
            RestRequest request = new RestRequest("", Method.Post);
            RestResponse restResponse = await client.PostAsync(request);

            FrameworkHelper.checkAssert(201, (int)restResponse.StatusCode);


        }


        [TestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void TestAddAJ(int SrNo, string TestCaseName, string URL, string Method, string inputJson, string OutputJson, int StatusCode)
        {
            Console.WriteLine(SrNo + StatusCode); 
            //Assert.AreEqual(expected, actual);
        }
        public static IEnumerable<object[]> GetTestData()
        {
            IEnumerable<TestDataDto> data = ReadCsv();
           
                foreach(var item in data)
                {
                   
                    yield return new object[]
                    {
                        item.SrNo, item.TestCaseName, item.URL, item.Method, item.inputJson, item.OutputJson, item.StatusCode
                    };
                
                }
        }
        public static IEnumerable<TestDataDto> ReadCsv()
        {
            StreamReader? reader = new StreamReader("TestData\\Testdata.csv");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture, false);
            return csv.GetRecords<TestDataDto>();
        }
    }
}