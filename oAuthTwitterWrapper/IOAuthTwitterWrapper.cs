using System;
namespace OAuthTwitterWrapper
{
	public interface IOAuthTwitterWrapper
	{
		string GetMyTimeline();
		string GetSearch();
	}
}
