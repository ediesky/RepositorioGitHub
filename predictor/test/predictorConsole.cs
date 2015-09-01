using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using predictor;

namespace testPredictorConsole
{
    class predictorConsole
    {
        static void Main(string[] args)
        {
            string result = predictorLibrary.availableStreet("RTY-9551", "08/31/2015", "09:00");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
