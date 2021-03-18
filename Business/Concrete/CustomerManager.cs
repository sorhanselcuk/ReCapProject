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
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var data = _customerDal.GetAll();
            if (data is null)
                return new ErrorDataResult<List<Customer>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<Customer>>(data,Messages.Success);

        }

        public IDataResult<Customer> GetByCompanyName(string companyName)
        {
            var data = _customerDal.Get(c => c.CompanyName == companyName);
            if (data is null)
                return new ErrorDataResult<Customer>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<Customer>(data,Messages.Success);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            var data = _customerDal.Get(c => c.Id == customerId);
            if (data is null)
                return new ErrorDataResult<Customer>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<Customer>(data,Messages.Success);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Success);
        }
    }
}
