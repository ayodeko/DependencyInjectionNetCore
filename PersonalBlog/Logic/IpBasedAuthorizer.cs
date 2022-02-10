using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PersonalBlog.Interfaces;

namespace PersonalBlog.Logic
{
	public class IpBasedAuthorizer : IAuthorizer
	{
		IHttpContextAccessor _httpContext;
		IConfiguration _config;

		public IpBasedAuthorizer(IHttpContextAccessor httpContext, IConfiguration config)
		{
			_httpContext = httpContext;
			_config = config;
		}
		public bool IsAuthorized()
		{
			var remoteIP = _httpContext.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
			var configIP = _config.GetSection("Security").GetValue<string>("AdminRemoteIP");

			return string.Compare(remoteIP, configIP) == 0;
		}
	}
}
