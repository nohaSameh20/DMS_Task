using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
   public class FileManagerConfiguration : IFileManagerConfiguration
    {
        public string Container { get; set; }
        public string HostingPath { set; get; }
        public string ServerUrl { set; get; }
    }
}
