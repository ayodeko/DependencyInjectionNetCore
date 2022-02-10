using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalDependnecyInjection.Services
{
	internal class EuropeTax : ITaxService
	{
		ILogger _logger;

		EuropeTax(ILogger logger)
		{
			_logger = logger;
		}

		void ITaxService.Calculate()
		{
			_logger.LogInformation("Europe Tax");
		}
	}

	internal class AsiaTax : ITaxService
	{
		ILogger _logger;

		AsiaTax(ILogger logger)
		{
			_logger = logger;
		}

		void ITaxService.Calculate()
		{
			_logger.LogInformation("Asia Tax");
		}
	}
}
