using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace TextAnalyzer
{
    class Parser : Program
    {
        private string parsedXml;
        private string _parsedXml { get; set; }
        public List<string> Phrases { get; set; }
        public List<double?> Score { get; set; }
        public List<string> Recommended { get; set; }
        public Parser()
        {
            XmlDocument shelf = new XmlDocument();
            shelf.Load(Path.Combine(Environment.CurrentDirectory, "books.xml"));
            XmlNode book = shelf.SelectSingleNode("/catalog");
            List<string> fields = new List<string>();
            foreach (XmlNode field in book.ChildNodes)
            {
                fields.Add(field.InnerText);
            }
            string parsedXml = string.Join("", fields.ToArray());
            Console.WriteLine(parsedXml);
            Analyze();
            //GetScore();
            Recommend();
            public IList<string> Analyze()
            {
                Analyzer analyzer = new Analyzer(parsedXml);
                return analyzer.phrases;
            }
            //public List<double?> GetScore()
            //{
            //    Sentiment sentiment = new Sentiment();
            //    return sentiment.score;
            //}
            public IList<string> Recommend()
            {
                Recommender recommender = Recommender(Phrases);
                return recommender.recommendations;
            }
        }
    }
}