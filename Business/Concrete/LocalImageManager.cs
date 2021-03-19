using Business.Absract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class LocalImageManager : IImageService
    {
        public IDataResult<string> Add(IFormFile file)
        {
            var result = GetAFileName(file);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if (file.Length > 0)
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                        file.CopyTo(stream);
                File.Move(sourcePath, result);
            }
            catch (Exception)
            {
                throw;
            }
            return new SuccessDataResult<string>(result,Messages.Success);
            
        }

        public IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception)
            {
                throw;
            }

            return new SuccessResult();
        }

        public IDataResult<string> Update(string oldPath, IFormFile newFile)
        {
            var result = GetAFileName(newFile);
            try
            {
                if (oldPath.Length > 0)
                {
                    using (var stream = new FileStream(result, FileMode.Create))
                    {
                        newFile.CopyTo(stream);
                    }
                }
                File.Delete(oldPath);
            }
            catch (Exception)
            {
                throw;
            }
            return new SuccessDataResult<string>(result,Messages.Success);
        }
        public string GetAFileName(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var newPath = Guid.NewGuid() + fileExtension;


            string path = Environment.CurrentDirectory + @"\wwwroot\Uploads\CarImages\";

            string result = $@"{path}\{newPath}";

            return  $"\\Uploads\\CarImages\\{newPath}";
        }
    }
}
