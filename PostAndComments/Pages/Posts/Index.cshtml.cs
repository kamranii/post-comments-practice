using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PostAndComments.Models;

namespace PostAndComments.Pages.Posts
{
	public class PostsModel : PageModel
    {
        public List<Post> Posts { get; set; }

        public async Task OnGet()
        {
            using(var client = new HttpClient())
            {
                var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
                var responseString = await response.Content.ReadAsStringAsync();
                Posts = JsonConvert.DeserializeObject<List<Post>>(responseString);
            }
        }
    }
}
