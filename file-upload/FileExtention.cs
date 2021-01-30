using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Cryptography;

namespace file_upload
{
    abstract public class FileExtention
    {
        private static String[,] mediaTypes = new String[,] { { "image/png", ".png" }, { "image/jpeg", ".jpg" }, { "application/zip", ".zip" } };

        public static String GetExtention(Microsoft.AspNetCore.Http.IFormFile file)
        {
            String mediaType = file.ContentType;

            String returnString = null;

            for (byte i = 0; i < mediaTypes.GetLength(0); i++)
            {
                if(mediaType == mediaTypes[i,0]) {
                    returnString = mediaTypes[i,1];
                    break;
                }
            }

            return returnString;
        }
    }
}
