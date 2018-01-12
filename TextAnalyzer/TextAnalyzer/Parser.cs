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
            List<XmlDocument> documentsToParse = new List<XmlDocument>();
            string path = @"C:\Projects\TextAnalyzer\TextAnalyzer\TextAnalyzer\bin\Debug\HTML Page\Analog Devices";
            foreach (string file in Directory.EnumerateFiles(path, "*.html", SearchOption.AllDirectories))
            {
                XmlDocument newDocument = new XmlDocument();
                newDocument.Load(file);
                documentsToParse.Add(newDocument);
            }

            List<XmlNode> nodeList = new List<XmlNode>();
            List<string> stringsToAnalyze = new List<string>();
            foreach (XmlDocument d in documentsToParse)
            {
                XmlNode node = d.SelectSingleNode("/html");
                string parsedXml = "";
                foreach (XmlNode field in node.ChildNodes)
                {
                    parsedXml += field.InnerText;
                }
                Console.WriteLine(parsedXml);
                Console.WriteLine("Parsed XML is " + parsedXml.Length + " characters long");
                stringsToAnalyze.Add(parsedXml);
            }



            Analyze();
            //GetScore();
            //Recommend();
        }
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
            //public IList<string> Recommend()
            //{
            //    Recommender recommender = Recommender(Phrases);
            //    return recommender.recommendations;
            //}
        }
    }
