using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS_Project.App.ViewModels.Base;
using ICS_Project.Bl.Factories;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Models;
using ICS_Project.Bl.Repositories;

namespace ICS_Project.App.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly UserRepository _userRepository = new UserRepository(new DbContextFactory());
        private readonly PostRepository _postRepository = new PostRepository(new DbContextFactory());
        private readonly CommentRepository _commentRepository = new CommentRepository(new DbContextFactory());
        private readonly IMessenger _messenger;
        public UserDetailModel User { get; set; }
        public ObservableCollection<PostDetailModel> Posts { get; set; }
        public ObservableCollection<CommentDetailModel> Comments { get; set; }

        public ProfileViewModel(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void Load(Guid id)
        {
            User = _userRepository.GetById(id);
            Posts = new ObservableCollection<PostDetailModel>(_postRepository.GetUserLastPosts(id, 3).ToList());
            Comments = new ObservableCollection<CommentDetailModel>(_commentRepository.GetUserLastComments(id, 3).ToList());
        }

        public void Save()
        {
            _userRepository.Update(User);
        }
    }
}
