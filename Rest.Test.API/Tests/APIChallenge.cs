
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rest.Test.API.Helpers;
using RestSharp;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;


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
        
        [TestMethod]
        public void TestExcel()
        {
          FileInfo existingFile = new FileInfo($"C:\\Development\\Rest.Test.API\\Rest.Test.API\\TestData\\TestData.xlsx");
			using (ExcelPackage package = new ExcelPackage(existingFile))
			{
                // get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
               
           
            string valA1 = worksheet.Cells["A1"].Value.ToString();
            string valB1 = worksheet.Cells[1, 2].Value.ToString();

            Report.print(valA1);
            Report.print(valB1);
            
        }
        }
        
        [DataTestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"C:\\Development\\Rest.Test.API\\Rest.Test.API\\TestData\\Testdata.csv",
            "Testdata#csv",
            DataAccessMethod.Sequential)]
        public void Test_Multiply_DataSource_CSV()
        {
            Report.print(TestContext.DataRow["ar"]);

   
        }
    }
}