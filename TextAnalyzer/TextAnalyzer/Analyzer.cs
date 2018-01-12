using System;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace TextAnalyzer
{
    class Analyzer : Program
    {
        private IList<string> _phrases;
        public IList<string> phrases
        {
            get { return _phrases; }
            set { phrases = _phrases; }
        }
        public Analyzer(string xml)
        {
            ITextAnalyticsAPI client = Client();
            string xmlString = xml;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n\n####TEXT ANALYSIS####");
            KeyPhraseBatchResult analysis = client.KeyPhrases(
                new MultiLanguageBatchInput(
                    new List<MultiLanguageInput>()
                    {
                        new MultiLanguageInput("en", "1", xmlString),
                    }));
            foreach (var item in analysis.Documents)
            {
                Console.WriteLine("Document ID: {0}", item.Id);
                Console.WriteLine("\t Key phrases");
                foreach (string keyphrase in item.KeyPhrases)
                {
                    Console.WriteLine(keyphrase);
                    phrases = item.KeyPhrases;
                }
            }
        }
    }
}
