using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Test.API.Tests
{
    public class TestDataDto
    {
        public int SrNo { get; set; }
        public int StatusCode { get; set; }    

        public string? TestCaseName { get; set; }
        public string? URL { get; set; }
        public string? MethodName { get; set; }
        public string? inputJson { get; set; }
        public string? OutputJson { get; set; }

    }
}