using System;
using System.Threading.Tasks;

namespace OAuthTwitterWrapper
{
	public interface IOAuthTwitterWrapper
	{
        [Obsolete("Use GetTimeline instead")]
        string GetMyTimeline();

        string GetTimeline();

        string GetTimeline(string screenName);

        Task<string> GetTimelineAsync();

        Task<string> GetTimelineAsync(string screenName);

        string GetSearch();
	}
}
