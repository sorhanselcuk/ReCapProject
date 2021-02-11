using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Absract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetByCompanyName(string companyName);
        IDataResult<Customer> GetById(int customerId);
    }
}
