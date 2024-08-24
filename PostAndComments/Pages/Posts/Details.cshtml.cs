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
	public class DetailsModel : PageModel
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }


        public async Task OnGet(int id)
        {
            using(var client = new HttpClient())
            {
                var postResponse = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
                var responseString = await postResponse.Content.ReadAsStringAsync();

                Post = JsonConvert.DeserializeObject<Post>(responseString);


            }
        }
    }
}
