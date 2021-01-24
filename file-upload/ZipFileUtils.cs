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
            FileStream fileStream = new FileStream(path + ".zip", FileMode.Create);
            ZipArchive archive = new ZipArchive(fileStream, ZipArchiveMode.Create);
            var demoFile = archive.CreateEntry(FilepathUtils.GetPath(File, true));
            Console.WriteLine("maybve saved a file idk");
        }
    }
}
