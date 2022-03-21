
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Threading.Tasks;
using static Rest.Test.API.Helpers.FrameworkHelper;

namespace Rest.Test.API
{
    [TestClass]
    public class APIChallenges
    {
        [TestMethod]
        public async Task TestMethodPostAsync()
        {
            RestClient client = new RestClient("https://apichallenges.herokuapp.com/challenger");
            RestRequest request = new RestRequest("",Method.Post);
            RestResponse restResponse = await client.PostAsync(request);

           checkAssert(201, (int)restResponse.StatusCode);

        }
    }
}