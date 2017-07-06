using System.Threading.Tasks;

namespace OAuthTwitterWrapper
{
	public interface IOAuthTwitterWrapper
	{
		string GetMyTimeline();

	    Task<string> GetMyTimelineAsync();

        string GetSearch();
	}
}
