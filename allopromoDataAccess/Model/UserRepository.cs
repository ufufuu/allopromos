using allopromoDataAccess.Abstract;
using allopromoDataAccess.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromoDataAccess.Model
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async void CreateUser(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
        }
        void IUserRepository.DeleteUser()
        {
            throw new NotImplementedException();
        }
        ApplicationUser IUserRepository.GetUser()
        {
            throw new NotImplementedException();
        }
        IEnumerable<ApplicationUser> IUserRepository.GetUsers()
        {
            throw new NotImplementedException();
        }
        void IUserRepository.UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
