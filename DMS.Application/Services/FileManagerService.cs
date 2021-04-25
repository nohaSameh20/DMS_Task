using Application.Interfaces;
using DMS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DMS.Application.Services
{
    public class FileManagerService : IFileManagerService
    {
        private IFileManagerConfiguration configuration;
        public FileManagerService(IFileManagerConfiguration config)
        {
            this.configuration = config;
        }
        public string UploadImage(string name, string extension, string image, string path = null)
        {
            StringBuilder fullName = new StringBuilder(200);
            if (!string.IsNullOrWhiteSpace(path))
                fullName.Append($"{path}/");

            string newPath = fullName.Append($"{name}.{extension}").ToString();
            File.WriteAllBytes(configuration.Container + newPath, Convert.FromBase64String(image));

            return newPath;
        }

        public string GetPath(string path)
        {
            string res = null;

            if (!string.IsNullOrWhiteSpace(path))
                res = configuration.HostingPath + configuration.Container + path;

            return res;
        }
        public bool DeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                    File.Delete(configuration.Container + path);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
