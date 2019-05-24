using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using ICS_Project.Bl.Factories;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Models;
using ICS_Project.Bl.Repositories;

namespace ICS_Project.Bl
{
    public class Authentication: IAuthentication
    {
        private const int SaltLengthLimit = 32;
        private readonly RNGCryptoServiceProvider _rngCryptoServiceProvider = new RNGCryptoServiceProvider();
        private readonly SHA1CryptoServiceProvider _sha1CryptoServiceProvider = new SHA1CryptoServiceProvider();
        private readonly UserRepository _userRepository;
        private readonly ASCIIEncoding _encoding = new ASCIIEncoding();
        private readonly IDbContextFactory _dbContextFactory;

        public Authentication(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _userRepository = new UserRepository(dbContextFactory);
            _sha1CryptoServiceProvider.Initialize();
        }

        public UserDetailModel Registration(UserDetailModel model)
        {
            var salt = GetSalt();
            var hash = GetHashString(model.Password, salt);

            model.Salt = salt;
            model.Password = hash;
            
            return _userRepository.Insert(model);
        }

        public UserDetailModel Login(UserLoginModel model)
        {
            var user = _userRepository.GetUserByEmail(model.Email);

            if (user == null)
            {
                return null;
            }

            var hash = GetHashString(model.Password, user.Salt);

            return hash == user.Password ? user : null;
        }

        private string GetHashString(string password, string salt)
        {
            var data = Encoding.ASCII.GetBytes(String.Concat(salt, password));
            var hash = _sha1CryptoServiceProvider.ComputeHash(data);
            return _encoding.GetString(hash);
        }
        
        private string GetSalt()
        {
            return Convert.ToBase64String(GetSalt(SaltLengthLimit));
        }

        private byte[] GetSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            _rngCryptoServiceProvider.GetNonZeroBytes(salt);

            return salt;
        }
    }
}
