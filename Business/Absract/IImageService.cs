using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Absract
{
    public interface IImageService
    {
        IDataResult<string> Add(IFormFile file);
        IDataResult<string> Update(string oldPath, IFormFile newFile);
        IResult Delete(string path);
    }
}
