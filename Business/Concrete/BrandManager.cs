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
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length < 2)
                return new ErrorResult("Brand name's length is must be greather than 2");
            _brandDal.Add(brand);
            return new SuccessResult("The Brand was successfully added");
        }
    }
}
