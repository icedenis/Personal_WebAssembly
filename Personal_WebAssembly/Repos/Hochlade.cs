using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorInputFile;

using Personal_WebAssembly.Interfaces;

namespace Personal_WebAssembly.Repos
{
    //THis wont work on Webassmbly app cuz i cant have this on the Client side path to upload imgs
    //public class Hochlade : IHochladen
    //{
        //does not work in Webassembly 
    //    private readonly IWebHostEnvironment _env;
        
        
    //   public Hochlade(IWebHostEnvironment env)
    //    {
    //        _env = env;
    //    }



    //    public void RemoveFile(string picName)
    //    {
    //        var path = $"{_env.WebRootPath}\\hochladen\\{picName}";

    //        if (File.Exists(path) == true)
    //        {
    //            File.Delete(path);
    //        }
    //    }

    //    public async Task UploadFile(IFileListEntry file, string picName)
    //    {
    //        try
    //        {
    //            var ms = new MemoryStream();
    //            await file.Data.CopyToAsync(ms);

    //            var path = $"{_env.WebRootPath}\\hochladen\\{picName}";

    //            using (FileStream fs = new FileStream(path, FileMode.Create))
    //            {
    //                ms.WriteTo(fs);
    //            }

    //        }
    //        catch (Exception ex)
    //        {

    //            throw;
    //        }
    //    }

    //    public void UploadFile(IFileListEntry file, MemoryStream msFile, string picName)
    //    {
    //        try
    //        {
    //            var path = $"{_env.WebRootPath}\\hochladen\\{picName}";

    //            using (FileStream fs = new FileStream(path, FileMode.Create))
    //            {
    //                msFile.WriteTo(fs);
    //            }

    //        }
    //        catch (Exception ex)
    //        {

    //            throw;
    //        }
    //    }
    //}




}
