namespace OAuthTwitterWrapper
{
	public class SearchSettings : ISearchSettings
	{
		public string SearchFormat { get; set; }
		public string SearchQuery { get; set; }
		public string SearchUrl => string.Format(SearchFormat, SearchQuery);
	}
}
