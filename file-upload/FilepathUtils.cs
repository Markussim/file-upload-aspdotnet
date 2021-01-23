using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Cryptography;

namespace file_upload
{
    abstract public class FilepathUtils
    {
        public static String ComputeHash(Stream File)
        {
            SHA256 Sha256 = SHA256.Create();

            return BitConverter.ToString(Sha256.ComputeHash(File)).Replace("-", "");
        }

        public static String GetPath(Microsoft.AspNetCore.Http.IFormFile File) {

            String filePath = @"./uploads/" + ComputeHash(File.OpenReadStream()) + FileExtention.GetExtention(File);

            return filePath;
        }

        public static String GetFileExtention() {


            return "";
        }
    }
}
