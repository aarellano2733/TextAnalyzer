using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace TextAnalyzer
{
    class Parser
    {
        private string parsedXml;
        private string _parsedXml { get; set; }
        public List<double?> Score { get; set; }
        public IList<string> Phrases { get; set; }
        public Parser()
        {
            //Needs to Add Schema Validation
            XmlDocument shelf = new XmlDocument();
            shelf.Load(Path.Combine(Environment.CurrentDirectory, "books.xml"));
            XmlNode book = shelf.SelectSingleNode("/html");
            List<string> fields = new List<string>();
            foreach (XmlNode field in book.ChildNodes)
            {
                fields.Add(field.InnerText);
            }
            string parsedXml = string.Join("", fields.ToArray());
            Console.WriteLine(parsedXml);
            Analize();
            GetScore();
            
        }
        public IList<string> Analize()
        {
            Analyzer analyzer = new Analyzer(parsedXml);
            return analyzer.phrases;
        }
        public List<double?> GetScore()
        {
            Sentiment sentiment = new Sentiment(Phrases);
            return sentiment.score;
        }
    }
}