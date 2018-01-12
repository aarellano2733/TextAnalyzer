using System;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace TextAnalyzer
{
    class Sentiment : Program
    {
        public Sentiment(IList<string> phraseList)
        {
            Console.WriteLine("\n\n####SENTIMENT SCORE####");
            ITextAnalyticsAPI client = Client();
            double? sentiment = new double?();
            SentimentBatchResult sentimentScore = client.Sentiment(
                new MultiLanguageBatchInput(
                    new List<MultiLanguageInput>()
                    {
                        new MultiLanguageInput("en", "1"),
                    }));
            foreach (var item in sentimentScore.Documents)
            {
                Console.WriteLine("Document ID: {0}", "Sentiment Score: {1:0.00}", item.Id);
                Console.WriteLine(item.Score);
                sentiment = item.Score;
            };
        }
    }
}
