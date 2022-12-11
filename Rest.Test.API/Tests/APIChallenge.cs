
using Rest.Test.API.Helpers;
using RestSharp;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            //ToDO: config file for URLs
           // RestClient client = new RestClient("https://apichallenges.herokuapp.com/challenger");
            RestClient client = new RestClient("https://apichallenges.herokuapp.com/todos");
            request = new RestRequest("", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { title ="A" });

            response = await client.PostAsync(request);

             Report.print("Size of list-Count : " + response.ContentHeaders.Count);
             Report.print("Size of list : " + response.ContentHeaders);
             Report.print("Issuccessful : " + response.IsSuccessful);
             Report.print("Server : " + response.Server);
             Report.print("Content length : " + response.ContentLength);
             Report.print("Content Encoding : " + response.ContentEncoding);
             Report.print("version : " + response.Version);
             Report.print("Content : " + response.Content);

           // FrameworkHelper.checkAssert(201, (int)response.StatusCode);
            Report.print("TestCase Execution Completed");
        }


        [TestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public async Task TestCase(int SrNo, string TestCaseName, string URL, string MethodName, string inputJson, string OutputJson, int StatusCode)
        {
            JObject GetJson;
            Report.print("Serial No: " + SrNo.ToString());
            Report.print("TestCase No: " + StatusCode.ToString());
            Report.print("URL: "+ URL);
            Report.print("Method Name: " + MethodName);
            Report.print("InputJSON: " + inputJson);
            Report.print("Expected OutputJson " + OutputJson);
            
            RestClient client = new RestClient(URL);
            
            if(inputJson.EndsWith(".json"))
            {
                var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "TestData", inputJson));

                using (StreamReader file = File.OpenText(path))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    GetJson = (JObject)JToken.ReadFrom(reader);
                    Report.print("Executing POST Method");
                    var request = new RestRequest();

                    request.Method = Method.Post;
                    request.AddHeader("Accept", "application/json");
                    //request.Parameters.Clear();
                    request.AddParameter("application/json", GetJson, ParameterType.RequestBody);

                    // var response = client.ExecuteAsync(request);
                    response = await client.PostAsync(request);
                    //var content = response.Status;
                    // request = new RestRequest("", Method.Post);
                    //request.RequestFormat = DataFormat.Json;
                    //request.AddJsonBody( inputJson);
                    //request.AddHeader("Accept", "application/json");
                    // request.AddParameter("application/json", GetJson, ParameterType.RequestBody);
                    Console.WriteLine("GetJSON" + GetJson);  
                   // response = await client.PostAsync(request);
                    //Console.WriteLine("Content " + content);
                    Console.WriteLine("Response Body" + response.ToString());
                }

            }

            if (MethodName == "Get")
            {
                //ToDo: Move common method in helper file
                Report.print("Executing GET Method");
                request = new RestRequest("", Method.Get);
                response = await client.GetAsync(request);
            }
            if (MethodName == "Post1")
            {
                //ToDo: move common method in helper file
                Report.print("Executing POST Method");
                request = new RestRequest("", Method.Post);
                //request.RequestFormat = DataFormat.Json;
                //request.AddJsonBody( inputJson);
                request.AddHeader("Accept", "application/json");
                //request.Parameters.Clear();
               // request.AddParameter("application/json", GetJson.ToString(), ParameterType.RequestBody);

                //var response = client.Execute(request);
                //var content = response.Content; // raw content as string

                response = await client.PostAsync(request);
                //ToDo: POST CALL REQUEST, InputJSON
                // RestResponse restResponse = await client.PostAsync(request);
            }
            //Report.print(response.StatusCode.ToString());         

            //TODO: Assert output json
           // FrameworkHelper.checkAssert(StatusCode, (int)response.StatusCode);
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