using Business.Absract;
using Business.BusinessAspects.Autofac.Security;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Success);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var data = _brandDal.GetAll();
            if (data.Count == 0)
                return new ErrorDataResult<List<Brand>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<Brand>>(data,Messages.Success);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var data = _brandDal.Get(b => b.Id == id);
            if (data is null)
                return new ErrorDataResult<Brand>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<Brand>(data,Messages.Success);
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.Success);
        }
    }
}
