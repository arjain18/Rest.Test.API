using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Test.API.Helpers
{
    public class FrameworkHelper
    {
        public static void print(string abc)
        {
            Console.WriteLine(abc);
        }

        public static void checkAssert(int expectedValue, int actualValue)
        {
            string str;
            try
            {
                Assert.AreEqual(expectedValue, actualValue);
                str = "Comparisson is passed";
                print(str);
            }
            catch (Exception ex)
            {
                print(ex.ToString());
                str = "Comparisson is failed";
                Assert.Fail(str);
            }
           
        }
    }
}
