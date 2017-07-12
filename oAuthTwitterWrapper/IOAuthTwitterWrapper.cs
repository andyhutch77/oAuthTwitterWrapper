using System;
using System.Threading.Tasks;

namespace OAuthTwitterWrapper
{
	public interface IOAuthTwitterWrapper
	{
        [Obsolete("Use GetTimeline instead")]
        string GetMyTimeline();

        string GetTimeline();

	    Task<string> GetTimelineAsync();

        string GetSearch();
	}
}
