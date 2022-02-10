using Amazon.DynamoDBv2.DataModel;
using PersonalBlog.Interfaces;
using PersonalBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalBlog.Logic
{
	public class DynamoDBDataService : IDataService
	{
		private readonly IDynamoDBContext _dynamoDBContext;
		public DynamoDBDataService(IDynamoDBContext dynamoDBContext)
		{
			_dynamoDBContext = dynamoDBContext;
		}
		public async Task Create(Post model)
		{
			await _dynamoDBContext.SaveAsync<Post>(model);
		}

		public Task<List<Post>> GetAll()
		{
			throw new System.NotImplementedException();
		}
	}
}
