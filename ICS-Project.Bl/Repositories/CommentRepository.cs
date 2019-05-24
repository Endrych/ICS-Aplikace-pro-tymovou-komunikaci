using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Models;

namespace ICS_Project.Bl.Repositories
{
    public class CommentRepository:IRepository<CommentDetailModel>
    {
        public CommentDetailModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public CommentDetailModel Insert(CommentDetailModel item)
        {
            throw new NotImplementedException();
        }

        public void Update(CommentDetailModel item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
