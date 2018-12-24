using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        bool Add(User model);
        bool Delete(int id);
        bool Update(User model);
        User Get(int id);
    }

    public class UserService : IUserService
    {
        private readonly UserDbContext _userDbContext;

        public UserService(
            UserDbContext userDbContext
        )
        {
            _userDbContext = userDbContext;
        }

        public IEnumerable<User> GetAll()
        {
            var result = new List<User>();

            try
            {
                result = _userDbContext.User.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public User Get(int id)
        {
            var result = new User();

            try
            {
                result = _userDbContext.User.Single(x => x.UserId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(User model)
        {
            try
            {
                _userDbContext.Add(model);
                _userDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(User model)
        {
            try
            {
                var originalModel = _userDbContext.User.Single(x =>
                    x.UserId == model.UserId
                );

                originalModel.Name = model.Name;
                originalModel.Email = model.Email;
                originalModel.Password = model.Password;

                _userDbContext.Update(originalModel);
                _userDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _userDbContext.Entry(new User { UserId = id }).State = EntityState.Deleted; ;
                _userDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
