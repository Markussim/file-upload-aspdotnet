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

            String path = null;

            try
            {
                file.CopyTo(new FileStream(FilepathUtils.GetPath(file, !knownExt), FileMode.Create));

                if (knownExt)
                {
                    path = FilepathUtils.GetPath(file, false).Substring(1);
                }
                else
                {
                    ZipFileUtils.ZipIFormFile(FilepathUtils.GetPath(file, false), file);

                    File.Delete(FilepathUtils.GetPath(file, true));

                    path = (FilepathUtils.GetPath(file, false) + ".zip").Substring(1);
                }
            }
            catch (System.Exception)
            {

                if (knownExt)
                {
                    path = FilepathUtils.GetPath(file, false).Substring(1);
                }
                else
                {
                    path = (FilepathUtils.GetPath(file, false) + ".zip").Substring(1);
                }


                throw;
            }

            System.Console.WriteLine(path);
            return path;



        }
    }
}
