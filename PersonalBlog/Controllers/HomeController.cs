using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalBlog.Interfaces;
using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IDataService _dataService;
		private readonly IHttpContextAccessor _httpContext;

		public HomeController(ILogger<HomeController> logger, IDataService dataService, IHttpContextAccessor httpContext)
		{
			_logger = logger;
			_dataService = dataService;
			_httpContext = httpContext;
		}

		public async Task<IActionResult> Index()
		{
			var posts = await _dataService.GetAll();
			_logger.Log(LogLevel.Information, $"{"Trail",5}, {"Trail 2", -50}, {"Trail 3", 12}");
			return View(posts);
		}

		[Route("Post")]
		[HttpGet]
		public async Task<IActionResult> CreatePost(Post model)
		{
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Post(Post model)
		{
			
			return RedirectToAction("Index");

		}
		public IActionResult Privacy()
		{
			return RedirectToAction("CreatePost");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
