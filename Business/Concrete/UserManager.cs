using Business.Absract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("The user was successfully added !");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("The user was successfully deleted !");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByEMail(string eMail)
        {
            var user = _userDal.Get(u => u.EMail == eMail);
            if (user == null)
                return new ErrorDataResult<User>("There is not such the mail address ");
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<List<User>> GetByFirstName(string firstName)
        {
            return new DataResult<List<User>>(_userDal.GetAll(u => u.FirstName==firstName),true);
        }

        public IDataResult<List<User>> GetByLastName(string lastName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.FirstName == lastName));
        }

        public IDataResult<List<User>> GetByName(string name)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.FirstName +" "+ u.LastName == name));
        }

        public IDataResult<User> GetByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id==userId));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
