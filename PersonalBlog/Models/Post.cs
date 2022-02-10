using Amazon.DynamoDBv2.DataModel;
using System;

namespace PersonalBlog.Models
{
	[DynamoDBTable(tableName: "post")]
	public class Post
	{
		public Post()
		{
			Id = Guid.NewGuid().ToString();
		}

		[DynamoDBHashKey]
		public string Id { get; set; }
		public DateTime PostDateTime { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
	}
}
