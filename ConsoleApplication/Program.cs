using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAuthTwitterTimeLine;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var oAuthTwitterTimeline = new OAuthTwitterTimeline();
            Console.Write(oAuthTwitterTimeline.GetMyTimeline());
            Console.ReadLine();
        }
    }
}
