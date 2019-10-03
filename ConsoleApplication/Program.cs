using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAuthTwitterWrapper;

namespace ConsoleApplication
{
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var oAuthTwitterWrapper = new OAuthTwitterWrapper.OAuthTwitterWrapper();
			Console.Write("**** Time Line *****\n");
			Console.Write(oAuthTwitterWrapper.GetMyTimeline() + "\n\n");
			Console.Write("**** Search *****\n");
			Console.Write(oAuthTwitterWrapper.GetSearch() + "\n\n");
			//oAuthTwitterWrapper.TimeLineSettings = new TimeLineSettings {
            Console.ReadLine();
        }
    }
}
