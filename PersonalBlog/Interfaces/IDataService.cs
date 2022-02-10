using PersonalBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalBlog.Interfaces
{
	public interface IDataService
	{
		public Task Create(Post model);
		public Task<List<Post>> GetAll();
	}
}
