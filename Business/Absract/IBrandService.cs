using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Absract
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
    }
}
