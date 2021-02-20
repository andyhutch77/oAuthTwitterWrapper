namespace OAuthTwitterWrapper
{
	public class TimeLineSettings : ITimeLineSettings
	{
		public string ScreenName { get; set; }
		public string IncludeRts { get; set; }
		public string ExcludeReplies { get; set; }
		public int Count { get; set; }
		public string TimelineFormat { get; set; }
		public string TimelineUrl => string.Format(TimelineFormat, ScreenName, IncludeRts, ExcludeReplies, Count);
	}
}
