using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application.Interfaces
{
    public interface IFileManagerService
    {
        string UploadImage(string name, string extension, string image, string path = null);
        string GetPath(string path);

        bool DeleteFile(string path);
    }
}
