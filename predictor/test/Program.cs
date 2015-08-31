using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using predictor;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = predictorLibrary.predictProcedure("GHB-7891","08/31/2015","10:00").ToString();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
