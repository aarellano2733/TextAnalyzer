using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace TextAnalyzer
{
    class Program
    {
        public static ITextAnalyticsAPI Client()
        {
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Westeurope;
            client.SubscriptionKey = "c73f4ffebd444e1189a3e41aecc2c159";
            return client;
        }
        static void Main(string[] args)
        {
            Parser pObj = new Parser();

            Console.WriteLine("The score is: {0}", pObj.Score);
            Console.ReadLine();
        }
    }
}