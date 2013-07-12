#oAuthTwitterWrapper
This provides a really simple solution to authenticating and wrapping twitter's API calls using the 1.1 API and OAuth.

[MVC Demos] (http://www.oauthtwitterwrappermvc.com.gridhosted.co.uk/)

##Quick installation instructions:

Run the following nuget command from your project to install the [package] (http://nuget.org/packages/oAuthTwitterWrapper/):

`Install-Package oAuthTwitterWrapper`

Amend the appsettings to add your consumer key, secret and screen name. [Generate your key and secret here] (https://dev.twitter.com/apps/new)

Add the following code to return the raw json:

            var twit = new OAuthTwitterWrapper.OAuthTwitterWrapper();
            twit.GetMyTimeline();

If you would prefer to use serialiazed C# pocos use the following:

           var twit = new OAuthTwitterWrapper.OAuthTwitterWrapper();
	       var json = _oAuthTwitterWrapper.GetMyTimeline();
           var result = JsonConvert.DeserializeObject<List<TimeLine>>(json);

#Notes
Currently it exposes timeline (twitter feed) and search calls, returned as raw json (which can be serialzied into c# pocos, examples in the github project).

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
(todo: tested just need to add to project)
