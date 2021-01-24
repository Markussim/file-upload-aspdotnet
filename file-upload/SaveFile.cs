using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Cryptography;
using System.IO.Compression;

namespace file_upload
{
    abstract public class SaveFileUtils
    {
        public static void SaveFile(Microsoft.AspNetCore.Http.IFormFile file)
        {
            Boolean knownExt = FileExtention.GetExtention(file) != null;

            file.CopyTo(new FileStream(FilepathUtils.GetPath(file, !knownExt), FileMode.Create));

            if (knownExt)
            {
                System.Console.WriteLine("Saved file with know ext");
                return;
            }
            else
            {
                ZipFileUtils.ZipIFormFile(FilepathUtils.GetPath(file, false), file);
            }

        }
    }
}
