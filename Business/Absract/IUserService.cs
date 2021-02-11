using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Text;

namespace Business.Absract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int userId);
        IDataResult<List<User>> GetByName(string name);
        IDataResult<List<User>> GetByFirstName(string firstName);
        IDataResult<List<User>> GetByLastName(string lastName);
        IDataResult<User> GetByEMail(string eMail);
    }
}
