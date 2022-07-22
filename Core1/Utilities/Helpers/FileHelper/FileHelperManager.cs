using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core1.Utilities.Helpers.FileHelper
{
    using Core1.Utilities.Helpers.GuidHelper;
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string flePath, string root)
        {
            throw new NotImplementedException();
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
            }

            string extension = Path.GetExtension(file.FileName);
            string guid = GuidHelper.CreateGuid();
            string filePath = guid + extension;

            using (FileStream fileStream = File.Create(root + filePath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                return filePath;
            }
            return null;
        }
    }
}
