using ICS_Project.Bl.Models;
using ICS_Project.Bl.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ICS_Project.Tests
{
    public class CommentRepositoryTest
    {
        [Fact]
        public void GetByIdTest()
        {
            var commentRepository = new CommentRepository(new InMemoryDbContextFactory());
            var userRepository = new UserRepository(new InMemoryDbContextFactory());

            var author = new UserDetailModel();

            var dbAuthor = userRepository.Insert(author);

            var comment = new CommentDetailModel()
            {
                Timestamp = DateTime.Now,
                Author = dbAuthor,
                Content = "Dneska som mala na obed kuraci steak",
            };

            var commentDetail = commentRepository.Insert(comment);

            var commentDatabase = commentRepository.GetById(commentDetail.Id);
            Assert.NotNull(commentDatabase);
            Assert.Equal(comment.Timestamp, commentDatabase.Timestamp);
            Assert.NotNull(commentDatabase.Author);
            Assert.Equal(comment.Content, commentDatabase.Content);
            commentRepository.Remove(commentDatabase.Id);
        }

        [Fact]
        public void InsertTest()
        {
            var commentRepository = new CommentRepository(new InMemoryDbContextFactory());

            var comment = new CommentDetailModel()
            {
                Timestamp = DateTime.Now,
                Author = new UserDetailModel(),
                Content = "Pockaj, kym mi doperie pracka",
            };

            var commentDetail = commentRepository.Insert(comment);
            var commentId = commentRepository.GetById(commentDetail.Id);

            Assert.NotNull(commentId);
            commentRepository.Remove(commentId.Id);
        }

        [Fact]
        public void UpdateTest()
        {
            var commentRepository = new CommentRepository(new InMemoryDbContextFactory());
            var userRepository = new UserRepository(new InMemoryDbContextFactory());
            var author = new UserDetailModel();
            var dbAuthor = userRepository.Insert(author);

            var commentOld = new CommentDetailModel()
            {
                Timestamp = DateTime.Now,
                Author = dbAuthor,
                Content = "Mamka mi zjedla rezen.",
            };

            var commentNew = new CommentDetailModel()
            {
                Timestamp = DateTime.Now,
                Content = "Ocko mi zjedol rezen nakoniec.",
                Author = dbAuthor
            };

            var commentDetail = commentRepository.Insert(commentNew);
            commentRepository.Update(commentNew);

            var commentDatabase = commentRepository.GetById(commentDetail.Id);
            Assert.NotNull(commentDatabase);
            Assert.Equal(commentNew.Timestamp, commentDatabase.Timestamp);
            Assert.Equal(commentNew.Content, commentDatabase.Content);

            commentRepository.Remove(commentDatabase.Id);
        }

        [Fact]
        public void RemoveTest()
        {
            var commentRepository = new CommentRepository(new InMemoryDbContextFactory());

            var comment = new CommentDetailModel()
            {
                Timestamp = DateTime.Now,
                Author = new UserDetailModel(),
                Content = "Pracka mi konecne doprala.",
            };

            var commentDetail = commentRepository.Insert(comment);
            commentRepository.Remove(commentDetail.Id);

            var commentDatabase = commentRepository.GetById(commentDetail.Id);
            Assert.Null(commentDatabase);
        }

        [Fact]
        public void GetUserLastCommentTest()
        {
            var commentRepository = new CommentRepository(new InMemoryDbContextFactory());
            var userRepository = new UserRepository(new InMemoryDbContextFactory());
            var author = new UserDetailModel();

            var dbAuthor = userRepository.Insert(author);

            var commentFirst = new CommentDetailModel()
            {
                Timestamp = DateTime.Now,
                Author = dbAuthor,
                Content = "Ta podlaha v kuchyni je spinava.",
            };

            var commentSecond = new CommentDetailModel()
            {
                Timestamp = DateTime.Now,
                Author = dbAuthor,
                Content = "Mam chut ju umyt.",
            };

            var commentLast = new CommentDetailModel()
            {
                Timestamp = DateTime.Now,
                Author = dbAuthor,
                Content = "Ok, idem ju fakt umyt.",
            };

            var commentFirstDb = commentRepository.Insert(commentFirst);
            var commentSecondDb = commentRepository.Insert(commentSecond);
            var commentDetail = commentRepository.Insert(commentLast);

            var commentsDatabase = commentRepository.GetUserLastComments(dbAuthor.Id,2);
            Assert.Equal(2,commentsDatabase.Count());
            Assert.Equal(commentSecond.Timestamp, commentsDatabase.Last().Timestamp);
            Assert.Equal(commentSecond.Content, commentsDatabase.Last().Content);
            Assert.Equal(commentLast.Timestamp, commentsDatabase.First().Timestamp);
            Assert.Equal(commentLast.Content, commentsDatabase.First().Content);

            commentRepository.Remove(commentFirstDb.Id);
            commentRepository.Remove(commentSecondDb.Id);
            commentRepository.Remove(commentDetail.Id);
        }
    }
}
