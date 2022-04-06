
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rest.Test.API.Helpers;
using RestSharp;
using System.Threading.Tasks;


namespace Rest.Test.API
{
    [TestClass]
    public class APIChallenges
    {
        [TestMethod]
        public async Task TestMethodPostAsync()
        {
            Report.print("TestCase Execution started");
            RestClient client = new RestClient("https://apichallenges.herokuapp.com/challenger");
            RestRequest request = new RestRequest("",Method.Post);
            RestResponse restResponse = await client.PostAsync(request);

           FrameworkHelper.checkAssert(201, (int)restResponse.StatusCode);

        }
    }
}