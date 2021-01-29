using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Cryptography;
using System.IO.Compression;

namespace file_upload
{
    abstract public class SaveFileUtils
    {
        public static string SaveFile(Microsoft.AspNetCore.Http.IFormFile file)
        {
            Boolean knownExt = FileExtention.GetExtention(file) != null;

            try
            {
                file.CopyTo(new FileStream(FilepathUtils.GetPath(file, !knownExt), FileMode.Create));
            }
            catch (System.Exception)
            {
                if (knownExt)
                {
                    return FilepathUtils.GetPath(file, false).Substring(1);
                }
                else
                {
                    return (FilepathUtils.GetPath(file, false) + ".zip").Substring(1);
                }
                throw;
            }


            if (knownExt)
            {
                System.Console.WriteLine("Saved file with know ext");
                return FilepathUtils.GetPath(file, false).Substring(1);
            }
            else
            {
                ZipFileUtils.ZipIFormFile(FilepathUtils.GetPath(file, false), file);

                return (FilepathUtils.GetPath(file, false) + ".zip").Substring(1);
            }

        }
    }
}
