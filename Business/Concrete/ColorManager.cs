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
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            var data = _colorDal.GetAll();
            if (data == null)
                return new ErrorDataResult<List<Color>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<Color>>(data,Messages.Success);

        }
    }
}
