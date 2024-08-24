using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostAndComments.Models;

namespace PostAndComments.ViewComponents
{
	public class CommentViewComponent: ViewComponent
	{
		public CommentViewComponent()
		{
		}

		public async Task<IViewComponentResult> InvokeAsync(int postId)
		{
			using(var client = new HttpClient())
			{
				var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{postId}/comments");
                var responseString = await response.Content.ReadAsStringAsync();

				var comments = JsonConvert.DeserializeObject<List<Comment>>(responseString);

				return View(comments);
            }
		}
	}
}

