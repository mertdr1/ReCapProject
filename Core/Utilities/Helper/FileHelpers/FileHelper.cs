using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.FileHelpers
{
    public  class FileHelper
    {
        public static string directory = Environment.CurrentDirectory + @"\wwwroot";
        public static string path = @"/images/";
        public static string Add(IFormFile formFile)
        {
            var sourcepath = Path.GetTempFileName();
            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            //var extension = Path.GetExtension(formFile.FileName);
            //var newFileName = Guid.NewGuid().ToString("N") + extension;
            var newFileName = CreateName(formFile);
            File.Move(sourcepath, directory + path + newFileName);
            return (path + newFileName).Replace("\\", "/");
        }
        public static string CreateName (IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var newName = Guid.NewGuid().ToString("N") + extension;
            return newName;
        }
        public static IResult Delete(string oldPath)
        {
            path = (directory + oldPath).Replace("/", "\\");
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }

        public static string Update(string sourcePath, IFormFile formFile)
        {
            //var extension = Path.GetExtension(formFile.FileName);
            //var newFileName = Guid.NewGuid().ToString("N") + extension;
            var newFileName = CreateName(formFile);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(directory + path + newFileName, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            File.Delete(directory + sourcePath);
            return (path + newFileName).Replace("\\", "/");
        }

    }

}

