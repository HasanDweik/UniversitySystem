using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Interfaces;
using UniversitySystem.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace UniversitySystem.Helpers;


public class UploadFileHelper:IUploadFileHelper
{
    public UploadFileHelper(IHostingEnvironment environment)
    {
        Environment = environment;
    }

    private IHostingEnvironment Environment;
    
    public Boolean UploadImage(UploadImage uploadImage)
    {
        try
        {
            string path = Path.Combine(Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName = Path.GetFileName(uploadImage._formFile.FileName);
            FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            uploadImage._formFile.CopyTo(stream);
        
            stream.Close();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
  
    }
}