#oAuthTwitterWrapper
This provides a really simple solution to authenticating and wrapping twitter's API calls using the 1.1 API and OAuth.

##Quick installation instructions:

Run the following nuget command from your project to install the [package] (http://nuget.org/packages/oAuthTwitterWrapper/):

`Install-Package oAuthTwitterWrapper`

Amend the appsettings to add your consumer key, secret and screen name. [Generate your key and secret here] (https://dev.twitter.com/apps/new)

Add the following code to return the raw json:

            var twit = new OAuthTwitterWrapper.OAuthTwitterWrapper();
            twit.GetMyTimeline();

If you would prefer to use serialiazed C# pocos use the following:

           var twit = new OAuthTwitterWrapper.OAuthTwitterWrapper();
           var json = twit.GetMyTimeline();
           var tweets = JsonConvert.DeserializeObject<List<TimeLine>>(json); // Deserialize with Json.NET

#Notes
Currently it exposes timeline (twitter feed) and search calls, returned as raw json (which can be serialized into c# pocos, examples in the github project).

Screen shot below (please note there is no styling applied you have full control over how it is rendered in your application).

![Demo MVC Web App output](./ScreenShot.PNG "Demo MVC Web App output")

The idea stems from the following Stackoverflow question:

[http://stackoverflow.com/questions/17067996/authenticate-and-request-a-users-timeline-with-twitter-api-1-1-oauth](http://stackoverflow.com/questions/17067996/authenticate-and-request-a-users-timeline-with-twitter-api-1-1-oauth)

## Demo projects in GitHub

### Console
This is the simplest form of use, it just makes the call and prints to the console window.

### Web application 
This uses a page WebMethod to make the api call and an Ajax json request to display the tweets.
It could however be exposed in any kind of web service.
It makes use of jQuery and this great library [twitter-text] (https://github.com/twitter/twitter-text-js).

### Mvc application 
This uses a controller action that returns the json and uses the same method to display them as above.
Again this uses jQuery and twitter-text. * Please note that I created this in VS2010 and you need MVC4 installed, I will update this to VS2012 soon.
There are also de-serialized versions of the c# pocos, please [view the controller actions] (https://github.com/andyhutch77/oAuthTwitterWrapper/blob/master/MvcApplication/Controllers/HomeController.cs) to see how this is done.

### Umbraco razor solution 
Here is a temporary solution, I plan to complete some further work on this in the future.

Run the following nuget command from your umbraco project to install the [package] (http://nuget.org/packages/oAuthTwitterWrapper/):

`Install-Package oAuthTwitterWrapper`

Amend the appsettings to add your consumer key, secret and screen name. [Generate your key and secret here] (https://dev.twitter.com/apps/new)

Create a macro script with the following code that outputs the json inline to the page:

          @using System
          @{
           var twit = new OAuthTwitterWrapper.OAuthTwitterWrapper();
           var json = twit.GetMyTimeline();
           }

           <div id="results"></div>
           <script type="text/javascript">
           var json = @Html.Raw(json);
           </script>
           
Add a reference to jQuery and twitter-text, then add some javascript to parse the json (The code here is just used for example purposes and not best practice):

                for (var i = 0; i < json.length; i++) {
                    $("#results").append('<p><strong> - ' + json[i].created_at.substring(0, 16) + '</strong><br/>' + twttr.txt.autoLink(json[i].text) + '</p>');
                    try {
                        for (var j = 0; j < json[i].entities.media.length; j++) {
                            $("#results").append('<a href="' + json[i].entities.media[j].media_url + '" ><img src="' + json[i].entities.media[j].media_url + ':thumb" /></a>');
                        }

                    } catch(e) {
                    }
                }
               
Add the macro to the template or content within Umbraco.
           
