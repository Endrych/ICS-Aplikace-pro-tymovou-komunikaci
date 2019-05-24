using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICS_Project.Bl.Models;

namespace ICS_Project.Bl
{
    public class Search
    {

        public ICollection<PostDetailModel> SearchInPosts(IEnumerable<PostDetailModel> posts , string searchText)
        {
            var lowerSearchText = searchText.ToLower();
            return posts.Where(p => (p.Title != null && p.Title.ToLower().Contains(lowerSearchText)) || (p.Content != null && p.Content.ToLower().Contains(lowerSearchText)) || p.Comments.AsEnumerable().Any(c => (c.Content != null && c.Content.ToLower().Contains(lowerSearchText)))).ToList();
        }
    }
}
