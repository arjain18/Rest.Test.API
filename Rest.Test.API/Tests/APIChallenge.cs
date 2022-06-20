
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
        RestRequest request;
        RestResponse response;
        [TestMethod]
        public async Task TestMethodPostAsync()
        {
            Report.print("TestCase Execution started");
            RestClient client = new RestClient("https://apichallenges.herokuapp.com/challenger");
            request = new RestRequest("", Method.Post);
            response = await client.PostAsync(request);
            FrameworkHelper.checkAssert(201, (int)response.StatusCode);
            Report.print("TestCase Execution Completed");
        }


        [TestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public async Task TestCase(int SrNo, string TestCaseName, string URL, string MethodName, string inputJson, string OutputJson, int StatusCode)
        {
            Report.print("Serial No: " + SrNo.ToString());
            Report.print("TestCase No: " + StatusCode.ToString());
            Report.print("URL: "+ URL);
            Report.print("Method Name: " + MethodName);
            Report.print("InputJSON: " + inputJson);
            Report.print("Expected OutputJson " + OutputJson);
            //TODO: Check with blank input and output
            
            RestClient client = new RestClient(URL);
            
            if (MethodName == "Get")
            {
                Report.print("Executing GET Method");
                request = new RestRequest("", Method.Get);
                response = await client.GetAsync(request);
            }
            if (MethodName == "Post")
            {
                Report.print("Executing POST Method");
                request = new RestRequest("", Method.Post);
                response = await client.PostAsync(request);
                //ToDo: POST CALL REQUEST, InputJSON
                // RestResponse restResponse = await client.PostAsync(request);
            }
            Report.print(response.StatusCode.ToString());         

            //TODO: Asser output json
            FrameworkHelper.checkAssert(StatusCode, (int)response.StatusCode);
            Report.print("TestCase Execution Completed");

            //Assert.AreEqual(expected, actual);
        }
        public static IEnumerable<object[]> GetTestData()
        {
            IEnumerable<TestDataDto> data = ReadCsv();
           
                foreach(var item in data)
                {
                   
                    yield return new object[]
                    {
                        item.SrNo, item.TestCaseName, item.URL, item.MethodName, item.inputJson, item.OutputJson, item.StatusCode
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