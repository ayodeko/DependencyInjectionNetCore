using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ScopedVSTransientServices
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var services = new ServiceCollection();
			services.AddScoped<ScopedClass>();
			services.AddTransient<TransientClass>();
			var provider = services.BuildServiceProvider();

			Console.Clear();
			Parallel.For(1, 10, i =>
			{
				Console.WriteLine($"Scoped Class ID: {provider.GetService<ScopedClass>().GetHashCode().ToString()}");
				Console.WriteLine($"Transient Class ID: { provider.GetService<TransientClass>().GetHashCode()}");
			});
			Console.ReadKey();
		}

		class ScopedClass
		{

		}

		class TransientClass
		{

		}
	}
}
