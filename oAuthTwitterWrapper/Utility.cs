using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OAuthTwitterWrapper
{
	internal class Utility
	{
        public async Task<string> RequstJsonAsync(string apiUrl, string tokenType, string accessToken)
        {
            var apiRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
            apiRequest.Headers.Add("Authorization", $"{tokenType} {accessToken}");
            apiRequest.Method = "Get";

            WebResponse responseObject = await Task<WebResponse>.Factory.FromAsync(apiRequest.BeginGetResponse, apiRequest.EndGetResponse, apiRequest);
            using (var responseStream = responseObject.GetResponseStream())
            {
                var sr = new StreamReader(responseStream, Encoding.UTF8);
                return await sr.ReadToEndAsync();
            }
        }

        public string RequstJson(string apiUrl, string tokenType, string accessToken)
		{
			string json;			
			HttpWebRequest apiRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
			var timelineHeaderFormat = "{0} {1}";
			apiRequest.Headers.Add("Authorization",
										string.Format(timelineHeaderFormat, tokenType,
													  accessToken));
			apiRequest.Method = "Get";
			WebResponse timeLineResponse = apiRequest.GetResponse();
						
			using (timeLineResponse)
			{
				using (var response = timeLineResponse.GetResponseStream())
				{
                    var reader = new StreamReader(response, Encoding.UTF8);
                    json = reader.ReadToEnd();
				}
			}
			return json;
		}
	}
}
