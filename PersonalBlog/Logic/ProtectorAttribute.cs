using Microsoft.AspNetCore.Mvc.Filters;
using PersonalBlog.Interfaces;
using System;

namespace PersonalBlog.Logic
{
	public class ProtectorAttribute : Attribute, IActionFilter
	{
		IAuthorizer _authorize;
		ProtectorAttribute(IAuthorizer authorizer)
		{
			_authorize = authorizer;
		}
		public void OnActionExecuted(ActionExecutedContext context)
		{
			if (!_authorize.IsAuthorized())
			{
				
			}
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			throw new NotImplementedException();
		}
	}
}
