using Business.Absract;
using Business.BusinessAspects.Autofac.Security;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            var result = BusinessRules.Run(CheckIfColorNameExist(color.Name));
            if (!result.Success)
                return result;
            _colorDal.Add(color);
            return new SuccessResult(Messages.Success);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Color>> GetAll()
        {
            var data = _colorDal.GetAll();
            if (data.Count == 0)
                return new ErrorDataResult<List<Color>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<Color>>(data,Messages.Success);

        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            var result = BusinessRules.Run(CheckIfColorNameExist(color.Name));
            if (!result.Success)
                return result;
            _colorDal.Update(color);
            return new SuccessResult(Messages.Success);
        }

        private IResult CheckIfColorNameExist(string colorName)
        {
            var data = _colorDal.Get(c=>c.Name.ToLower() == colorName.ToLower());
            if (data is null)
                return new SuccessResult();
            return new ErrorResult(Messages.ColorAlreadyExists);
        }
    }
}
