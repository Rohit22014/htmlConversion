using System;
using System.IO;
using HtmlAgilityPack;      // Uisng HtmlAgilityPack for parsing HTML (<table>)
using System.Linq;          // Using the Linq (Language Integrated Query) package later
using System.Text;          // Using this package to get Environment.NewLine

public class Program
{
    public static void Main(string[] args)
    {
        HtmlDocument doc = new HtmlDocument();
        string tableString = @"./rohit.html";
        doc.Load(tableString, Encoding.UTF8);
        using( StreamWriter tw = File.CreateText("./test.json"))
        {
        tw.WriteLine("[");
        foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
        {
            foreach (HtmlNode row in table.SelectNodes("tr"))
            {
                tw.WriteLine("{");
                foreach (HtmlNode cell2 in row.SelectNodes("td|th"))
                {
                    // Console.WriteLine(a);
                    // tw.WriteLine("cell: " + "'" + cell.InnerText + "'");
                    tw.WriteLine("'" + cell2.InnerText + "'");
                }
                }
                tw.WriteLine("}");
            }
            tw.WriteLine("]");
        }
    }
}