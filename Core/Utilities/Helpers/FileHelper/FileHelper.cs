using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + @"\wwwroot\";
        public static string Upload(IFormFile file)
        {

            if (file.Length > 0)
            {
                if (!Directory.Exists(_currentDirectory))
                {
                    Directory.CreateDirectory(_currentDirectory);
                }

                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid().ToString();
                string path = String.Concat(guid, extension);
                using (FileStream fileStream = File.Create(_currentDirectory + path))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return path;
                }

            }
            return null;
        }


        public static void Delete(string imagePath)
        {
            string newPath = _currentDirectory + imagePath;
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }

        }

        public static string Update(IFormFile file, string filePath)
        {
            Delete(_currentDirectory + filePath);
            return Upload(file);
        }
    }
}
