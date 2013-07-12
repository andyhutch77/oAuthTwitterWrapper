using System;
using OAuthTwitterWrapper.JsonTypes;
namespace OAuthTwitterWrapper
{
	public interface IAuthenticate
	{
		AuthResponse AuthenticateMe(IAuthenticateSettings authenticateSettings);
	}
}
