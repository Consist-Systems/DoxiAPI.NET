using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doxi.APIClient;

namespace SimpleDotNetFramwork
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var doxiClient = new DoxiClient(
                "",
                "",
                "");
            var result = doxiClient.GetAllFlows().Result;
        }
    }
}
