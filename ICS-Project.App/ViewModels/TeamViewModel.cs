using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using ICS_Project.App.Commands;
using ICS_Project.App.ViewModels.Base;
using ICS_Project.Bl;
using ICS_Project.Bl.Factories;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Mappers;
using ICS_Project.Bl.Models;
using ICS_Project.Bl.Repositories;

namespace ICS_Project.App.ViewModels
{
    public class TeamViewModel : ViewModelBase
    {
        private readonly Mappers _mappers = new Mappers();
        private readonly TeamRepository _teamRepository = new TeamRepository(new DbContextFactory());
        private readonly UserRepository _userRepository = new UserRepository(new DbContextFactory());
        private readonly PostRepository _postRepository = new PostRepository(new DbContextFactory());
        private readonly CommentRepository _commentRepository = new CommentRepository(new DbContextFactory());
        private readonly IMessenger _messenger;
        private readonly Search _search = new Search();
        private TeamDetailModel _team;
        private UserDetailModel _selectedUserToRemove;
        private UserDetailModel _user;
        private string _searchText = "";
        private bool _isAdmin;
        private PostDetailModel _newPost = new PostDetailModel();
        public ICommand AddNewPostCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                if (value == _isAdmin) return;
                _isAdmin = value;
                OnPropertyChanged();
            }
        }

        public TeamDetailModel Team
        {
            get => _team;
            set
            {
                if (Equals(value, _team)) return;
                _team = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (value == _searchText) return;
                _searchText = value;
                OnPropertyChanged();
            }
        }

        public List<UserListModel> AllUsers { get; set; }
        public ObservableCollection<UserListModel> UsersToInvite { get; set; }
        public ObservableCollection<UserDetailModel> TeamUsers { get; set; }
        public ObservableCollection<PostDetailModel> Posts { get; set; } = new ObservableCollection<PostDetailModel>();

        public PostDetailModel NewPost
        {
            get => _newPost;
            set
            {
                if (Equals(value, _newPost)) return;
                _newPost = value;
                OnPropertyChanged();
            }
        }

        public CommentDetailModel NewComment { get; set; } = new CommentDetailModel();

        public UserDetailModel User
        {
            get => _user;
            set
            {
                if (Equals(value, _user)) return;
                _user = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddUserCommand { get; set; }
        public ICommand RemoveUserCommand { get; set; }
        public ICommand AddCommentCommand { get; set; }
        public UserListModel SelectedUserToInvite { get; set; }
        public UserDetailModel SelectedUserToRemove
        {
            get => _selectedUserToRemove;
            set
            {
                if (Equals(value, _selectedUserToRemove)) return;
                _selectedUserToRemove = value;
                OnPropertyChanged();
            }
        }

        public TeamViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            AddUserCommand = new RelayCommand(AddUser);
            RemoveUserCommand = new RelayCommand(RemoveUser);
            AddNewPostCommand = new RelayCommand(AddNewPost);
            SearchCommand = new RelayCommand(SearchInPosts);
            RefreshCommand = new RelayCommand(Refresh);
            AddCommentCommand = new RelayCommand(AddComment);
        }

        public void Load(Guid userId, Guid teamId)
        {
            User = _userRepository.GetById(userId);
            Team = _teamRepository.GetById(teamId);
            SearchInPosts();
            AllUsers = _userRepository.GetUserListModels().ToList();
            TeamUsers = new ObservableCollection<UserDetailModel>(Team.Users);
            UsersToInvite = FilterUsers(AllUsers, Team);
            IsAdmin = Team.Admin.Id == User.Id;
            SortPosts(Team.Posts);
        }

        private void SortPosts(ICollection<PostDetailModel> posts)
        {
            Posts.Clear();

            var x = posts.AsEnumerable().OrderByDescending(p =>
            {
                if (p.Comments.Count > 0)
                {
                    return p.Comments.Last().Timestamp;
                }
                else
                {
                    return p.Timestamp;
                }
            }).ToList();

            foreach (var model in x)
            {
                Posts.Add(model);
            }
        }

        private ObservableCollection<UserListModel> FilterUsers(List<UserListModel> allUsers, TeamDetailModel team)
        {
            var users = new ObservableCollection<UserListModel>();
            foreach (var user in allUsers)
            {
                if (team.Users.All(u => u.Id != user.Id) && team.Admin.Id != user.Id)
                {
                    users.Add(user);
                }
            }

            return users;
        }

        private void SearchInPosts()
        {
            SortPosts(_search.SearchInPosts(Team.Posts, SearchText));
        }

        public void Save()
        {
            _teamRepository.Update(Team);
        }

        public void AddNewPost()
        {
            NewPost.Id = Guid.NewGuid();
            NewPost.Timestamp = DateTime.Now;
            NewPost.Comments = new List<CommentDetailModel>();
            NewPost.Author = User;
            var post = _postRepository.Insert(NewPost);
            Team.Posts.Add(post);
            Save();
            NewPost = new PostDetailModel();
            Refresh();
        }

        public void AddComment(object obj)
        {
            var id = (Guid)obj;
            var post = Team.Posts.FirstOrDefault(t => t.Id == id);
            if(post == null) return;
            post.NewComment.Author = User;
            post.NewComment.Timestamp = DateTime.Now;
            var comment = _commentRepository.Insert(post.NewComment);
            post.NewComment.Id = comment.Id;
            post.Comments.Add(post.NewComment);
            _postRepository.Update(post);
            post.NewComment = new CommentDetailModel();
            Refresh();
        }

        private void AddUser()
        {
            var user = SelectedUserToInvite;
            if (user == null) return;
            var userDetail = _userRepository.GetById(user.Id);
            Team.Users.Add(userDetail);
            TeamUsers.Add(userDetail);
            UsersToInvite.Remove(UsersToInvite.FirstOrDefault(u => u.Id == user.Id));
            _teamRepository.Update(Team);
        }

        private void RemoveUser()
        {
            var user = SelectedUserToRemove;
            if (user == null) return;
            Team.Users.Remove(Team.Users.FirstOrDefault(u=> u.Id == user.Id));
            TeamUsers.Remove(user);
            UsersToInvite.Add(_mappers.UserMapper.MapDetailToListModel(user));
            _teamRepository.Update(Team);
        }

        private void Refresh()
        {
            Team = _teamRepository.GetById(Team.Id);
            SortPosts(Team.Posts);
        }
    }
}
