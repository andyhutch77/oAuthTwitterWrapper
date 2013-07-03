using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAuthTwitterTimeLine;
using OAuthTwitterSearch;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var oAuthTwitterTimeline = new OAuthTwitterTimeline();
            Console.Write(oAuthTwitterTimeline.GetMyTimeline());
			//var oAuthTwitterSearch = new OAuthTwitterSearch.OAuthTwitterSearch();
			//Console.Write(oAuthTwitterSearch.GetSearch());
            Console.ReadLine();
        }
    }
}
