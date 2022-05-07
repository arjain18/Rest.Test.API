
using Rest.Test.API.Helpers;
using RestSharp;
using System.Threading.Tasks;
using OfficeOpenXml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


namespace Rest.Test.API
{
    [TestClass]
    public class APIChallenges
    {
private TestContext testContextInstance;
public TestContext TestContextInstance
{
   get { return testContextInstance; }
   set { testContextInstance = value; }
}
        [TestMethod]
        public async Task TestMethodPostAsync()
        {
            Report.print("TestCase Execution started");
            RestClient client = new RestClient("https://apichallenges.herokuapp.com/challenger");
            RestRequest request = new RestRequest("",Method.Post);
            RestResponse restResponse = await client.PostAsync(request);

           FrameworkHelper.checkAssert(201, (int)restResponse.StatusCode);
            

        }
        

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
         @"|DataDirectory|\TestData\TestData.csv", "Test1#csv",
         DataAccessMethod.Sequential)]
        public void Verify_ReadCSV()
        {
            string _firstName = testContextInstance.DataRow[0].ToString();
          //  string _lastName = TestContext.DataRow[1].ToString();
         //   string _name = TestContext.DataRow[2].ToString();

        }
    }
}