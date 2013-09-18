using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper
{
	public class TimeLineSettings : ITimeLineSettings
	{
		public string ScreenName { get; set; }
		public string IncludeRts { get; set; }
		public string ExcludeReplies { get; set; }
		public int Count { get; set; }
		public string TimelineFormat { get; set; }
        public string Since_ID { get; set; }
		public string TimelineUrl
		{
			get
			{
                if (Since_ID != "0")
                {
                    return string.Format(TimelineFormat, ScreenName, IncludeRts, ExcludeReplies, Count);
                }
                else
                {
                    return string.Format(TimelineFormat + "&amp;since_id={4}", ScreenName, IncludeRts, ExcludeReplies, Count, Since_ID);
                }
				
			}
		}
	}
}
