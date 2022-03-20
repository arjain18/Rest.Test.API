
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Rest.Test.API
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            RestClient client = new RestClient("https://apichallenges.herokuapp.com/challenger");
            RestRequest request = new RestRequest("",Method.Post);
            RestResponse restResponse = await client.PostAsync(request);
            Console.WriteLine(restResponse.StatusCode);
           Console.WriteLine(restResponse.StatusDescription);
           
        }
    }
}