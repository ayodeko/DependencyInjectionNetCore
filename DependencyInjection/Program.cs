using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var collection = new ServiceCollection();
            collection.AddScoped<IBusiness, Business2>();
            collection.AddScoped<IDataAccess, DataAccess>();
            collection.AddScoped<IUserInterface, UserInterface>();

            var provider = collection.BuildServiceProvider();

            /*
             * We dont need to call provider.GetService for IDataAccess and IBusiness 
             * since they are already injected through IUserinterface
            IDataAccess iDataAccess = provider.GetService<IDataAccess>();
            IBusiness iBusiness = provider.GetService<IBusiness>();
            */

            var userInterface = provider.GetService<IUserInterface>();
            userInterface.GetCredentials();
        }

        public class UserInterface : IUserInterface
        {
            private readonly IBusiness _business;
            public UserInterface(IBusiness business)
            {
                _business = business;
            }
            public void GetCredentials()
            {
                Console.WriteLine("Enter username..");
                var username = Console.ReadLine();
                Console.WriteLine("Enter Password..");
                var password = Console.ReadLine();

                _business.SignUp(username, password);
            }
        }

        public class Business : IBusiness
        {
            IDataAccess _dataAccess;
            public Business(IDataAccess dataAccess)
            {
                _dataAccess = dataAccess;  
            }
            public void SignUp(string username, string password)
            {
                /*
                 Some code for validating input
                 */
                Console.WriteLine("Inside Business");

                _dataAccess.Store(username, password);
            }
        }
        public class Business2 : IBusiness
        {
            IDataAccess _dataAccess;
            public Business2(IDataAccess dataAccess)
            {
                _dataAccess = dataAccess;  
            }
            public void SignUp(string username, string password)
            {
                /*
                 Some code for validating input
                 */
                _dataAccess.Store(username, password);
                Console.WriteLine("Inside Business 2");
            }
        }

        public class DataAccess : IDataAccess
        {
            public void Store(string username, string password)
            {
                Console.WriteLine("Inside DataAccess class");
            }
        }

        public interface IUserInterface
		{
            public void GetCredentials()
			{

			}
		}

        public interface IBusiness
        {
            public void SignUp(string username, string password);
        }

        public interface IDataAccess
        {
            public void Store(string username, string password);
        }
    }
}
