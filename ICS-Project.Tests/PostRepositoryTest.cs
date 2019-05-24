using System;
using System.Collections.Generic;
using System.Linq;
using ICS_Project.Bl;
using ICS_Project.Bl.Factories;
using ICS_Project.Bl.Models;
using ICS_Project.Bl.Repositories;
using ICS_Project.Db;
using ICS_Project.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ICS_Project.Tests
{
    public class PostRepositoryTest
    {
        private readonly PostRepository _posRepository = new PostRepository(new InMemoryDbContextFactory());
        private readonly UserRepository _userRepository = new UserRepository(new InMemoryDbContextFactory());
        private readonly Search _search = new Search();

        [Fact]
        public void InsertAndRemoveTest()
        {
            var post = new PostDetailModel()
            {
                Title = "First post",
                Comments = new List<CommentDetailModel>(),
                Author = new UserDetailModel(),
                Timestamp = new DateTime(),
                Content = "Tak toto budem testovat"
            };

            var insertedPost = _posRepository.Insert(post);

            Assert.NotNull(insertedPost);
            Assert.Equal(post.Title, insertedPost.Title);
            Assert.Equal(post.Timestamp, insertedPost.Timestamp);
            Assert.Equal(post.Content, insertedPost.Content);

            var getById = _posRepository.GetById(insertedPost.Id);

            Assert.NotNull(getById);
            Assert.Equal(post.Title, getById.Title);
            Assert.Equal(post.Timestamp, getById.Timestamp);
            Assert.Equal(post.Content, getById.Content);

            _posRepository.Remove(insertedPost.Id);
            getById = _posRepository.GetById(insertedPost.Id);
            Assert.Null(getById);
        }

        [Fact]
        public void UpdateTest()
        {
            var author = new UserDetailModel();

            var dbAuthor = _userRepository.Insert(author);

            var post = new PostDetailModel()
            {
                Title = "First post",
                Comments = new List<CommentDetailModel>(),
                Author = dbAuthor,
                Timestamp = new DateTime(),
                Content = "Tak toto budem testovat"
            };

            var insertedPost = _posRepository.Insert(post);

            var updatedPost = new PostDetailModel()
            {
                Id = insertedPost.Id,
                Title = "Updated post",
                Comments = new List<CommentDetailModel>(),
                Author = dbAuthor,
                Timestamp = new DateTime(),
                Content = "Toto je ine"
            };

            _posRepository.Update(updatedPost);
            insertedPost = _posRepository.GetById(insertedPost.Id);

            Assert.NotNull(insertedPost);
            Assert.Equal(updatedPost.Title, insertedPost.Title);
            Assert.Equal(updatedPost.Timestamp, insertedPost.Timestamp);
            Assert.Equal(updatedPost.Content, insertedPost.Content);

            _posRepository.Remove(updatedPost.Id);
        }

        [Fact]
        public void SearchInPostsTest()
        {
            var author = new UserDetailModel();

            var dbAuthor = _userRepository.Insert(author);

            var post = new PostDetailModel()
            {
                Title = "First post",
                Comments = new List<CommentDetailModel>(),
                Author = dbAuthor,
                Timestamp = new DateTime(),
                Content = "Tak toto budem testovat"
            };

            var insertedPost = _posRepository.Insert(post);
            var postsSearchedList = _search.SearchInPosts(_posRepository.GetPostDetailModels(), "Toto");

            var dbPost = _posRepository.GetById(insertedPost.Id);
            Assert.NotEmpty(postsSearchedList);
            Assert.Single(postsSearchedList);

            var updatedPost = new PostDetailModel()
            {
                Id = insertedPost.Id,
                Title = "Updated post",
                Comments = new List<CommentDetailModel>(),
                Author = dbAuthor,
                Timestamp = new DateTime(),
                Content = "Nic a nikto"
            };

            _posRepository.Update(updatedPost);

            postsSearchedList = _search.SearchInPosts(_posRepository.GetPostDetailModels(), "a nikto");
            Assert.NotEmpty(postsSearchedList);
            Assert.Single(postsSearchedList);

            postsSearchedList = _search.SearchInPosts(_posRepository.GetPostDetailModels(), "Tu uz nenajdem");
            Assert.Empty(postsSearchedList);
            _posRepository.Remove(insertedPost.Id);
        }

        [Fact]
        public void GetUserLastPostTest()
        {
            var userRepository = new UserRepository(new InMemoryDbContextFactory());
            var author = new UserDetailModel();

            var dbAuthor = userRepository.Insert(author);

            var postFirst = new PostDetailModel()
            {
                Title = "First post",
                Comments = new List<CommentDetailModel>(),
                Author = author,
                Timestamp = new DateTime(2019, 4, 4),
                Content = "Tak toto budem testovat"
            };

            var postSecond = new PostDetailModel()
            {
                Title = "Second post",
                Comments = new List<CommentDetailModel>(),
                Author = author,
                Timestamp = new DateTime(2019, 4, 5),
                Content = "A toto taky budem testovat"
            };


            var postLast = new PostDetailModel()
            {
                Title = "Last post",
                Comments = new List<CommentDetailModel>(),
                Author = author,
                Timestamp = new DateTime(2019, 4, 6),
                Content = "Toto uz nebudem testovat"
            };

            var postFirstDb = _posRepository.Insert(postFirst);
            var postSecondDb = _posRepository.Insert(postSecond);
            var postDetail = _posRepository.Insert(postLast);

            var postsDatabase = _posRepository.GetUserLastPosts(author.Id, 2);
            Assert.Equal(2, postsDatabase.Count());
            Assert.Equal(postSecond.Title, postsDatabase.Last().Title);
            Assert.Equal(postSecond.Content, postsDatabase.Last().Content);
            Assert.Equal(postLast.Title, postsDatabase.First().Title);
            Assert.Equal(postLast.Content, postsDatabase.First().Content);

            _posRepository.Remove(postFirstDb.Id);
            _posRepository.Remove(postSecondDb.Id);
            _posRepository.Remove(postDetail.Id);
        }

    }
}
