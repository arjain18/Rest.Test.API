using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rest.Test.API.Helpers;

namespace Rest.Test.API.Helpers
{
    public class FrameworkHelper
    {


        public static void checkAssert(int expectedValue, int actualValue)
        {
            string str;
            try
            {
                Assert.AreEqual(expectedValue, actualValue);
                str = "Comparisson is passed";
                Report.print(str);
            }
            catch (Exception ex)
            {
                Report.print(ex.ToString());
                str = "Comparisson is failed";
                Assert.Fail(str);
            }
           
        }
    }
}
