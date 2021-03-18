using Business.Absract;
using Business.Constants;
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
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<User>> GetAll()
        {
            var data = _userDal.GetAll();
            if (data is null)
                return new ErrorDataResult<List<User>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<User>>(data,Messages.Success);
        }

        public IDataResult<User> GetByEMail(string eMail)
        {
            var user = _userDal.Get(u => u.EMail == eMail);
            if (user == null)
                return new ErrorDataResult<User>(Messages.ThereIsNoSuchEMail);
            return new SuccessDataResult<User>(user,Messages.Success);
        }

        public IDataResult<List<User>> GetByFirstName(string firstName)
        {
            var data = _userDal.GetAll(u => u.FirstName == firstName);
            if (data is null)
                return new ErrorDataResult<List<User>>(Messages.ThereIsNoSuchData);
            return new DataResult<List<User>>(data,true,Messages.Success);
        }

        public IDataResult<List<User>> GetByLastName(string lastName)
        {
            var data = _userDal.GetAll(u => u.LastName == lastName);
            if (data is null)
                return new ErrorDataResult<List<User>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<User>>(data,Messages.Success);
        }

        public IDataResult<List<User>> GetByName(string name)
        {
            var data = _userDal.GetAll(u => u.FirstName + " " + u.LastName == name);
            if (data is null)
                return new ErrorDataResult<List<User>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<User>>(data,Messages.Success);
        }

        public IDataResult<User> GetByUserId(int userId)
        {
            var data = _userDal.Get(u => u.Id == userId);
            if (data is null)
                return new ErrorDataResult<User>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<User>(data,Messages.Success);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Success);
        }
    }
}
