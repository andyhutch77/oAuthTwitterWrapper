using System;
namespace OAuthTwitterWrapper
{
	public interface ISearchSettings
	{
		string SearchFormat { get; set; }
		string SearchQuery { get; set; }
		string SearchUrl { get; }
	}
}
