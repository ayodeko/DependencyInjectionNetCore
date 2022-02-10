using ConditionalDependnecyInjection;
using ConditionalDependnecyInjection.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConditionalDependnecyInjection
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			ServiceCollection services = new ServiceCollection();
			services.AddScoped<EuropeTax>();
			services.AddScoped<AsiaTax>();
			services.AddScoped<Func<string, ITaxService>>(serviceProvider => key =>
			{
				if (key == "Europe")
				{
					return serviceProvider.GetService<EuropeTax>();
				}
				if(key == "Asia")
				{
					return serviceProvider.GetService<AsiaTax>();
				}
				return serviceProvider.GetService<AsiaTax>();
			});
			services.AddScoped<ExecuteClass>();
			var hlder = services.BuildServiceProvider();
			var execute = hlder.GetService<ExecuteClass>();

			execute.Execute();
			}
		}
	}

public class ExecuteClass
{
	Func<string, ITaxService> _accessor;
	IConfiguration _config;
	public ExecuteClass(Func<string, ITaxService> accessor)
	{
		_accessor = accessor;
	}
	public void Execute()
	{
		var tax = _accessor("Asia");
		tax.Calculate();
	}

}
