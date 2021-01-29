using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Cryptography;
using System.IO.Compression;

namespace file_upload
{
    abstract public class ZipFileUtils
    {
        public static void ZipIFormFile(string path, Microsoft.AspNetCore.Http.IFormFile File)
        {
            using (var archive = ZipFile.Open(path + ".zip", ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(FilepathUtils.GetPath(File, true), File.FileName);
            }
        }
    }
}
