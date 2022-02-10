using PersonalBlog.Interfaces;
using PersonalBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalBlog.Logic
{
	public class StaticDataService : IDataService
	{
		public List<Post> currentList { get; set; }
		public Task Create(Post model)
		{
			if(currentList == null)
			{
				currentList = fewLists();
			}
			currentList.Add(model);
			return Task.FromResult(0);
		}

		public async Task<List<Post>> GetAll()
		{
			return fewLists();
		}

		List<Post> fewLists()
		{
			var lists = new List<Post>();
			for(int i = 0; i < 5; i++)
			{
				var post = new Post
				{
					Content = $"Content Number{i}",
					Title = $"Title Number{i}",
					PostDateTime = System.DateTime.Now
				};
				lists.Add(post);
			}
			return lists;
		}
	}
}
