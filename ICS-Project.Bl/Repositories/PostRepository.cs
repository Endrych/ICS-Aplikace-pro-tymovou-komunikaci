using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Models;

namespace ICS_Project.Bl.Repositories
{
    public class PostRepository: IRepository<PostDetailModel>
    {
        public PostDetailModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public PostDetailModel Insert(PostDetailModel item)
        {
            throw new NotImplementedException();
        }

        public void Update(PostDetailModel item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
