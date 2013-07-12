using System;
namespace OAuthTwitterWrapper
{
	public interface ITimeLineSettings
	{
		string Count { get; set; }
		string IncludeRts { get; set; }
		string ScreenName { get; set; }
		string TimelineFormat { get; set; }
		string TimelineUrl { get; }
	}
}
