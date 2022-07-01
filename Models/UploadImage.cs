namespace UniversitySystem.Models;
using UniversitySystem.Validations;
public class UploadImage
{
    [AllowedExtensions(new string[] { ".jpg", ".png" })]
    public IFormFile _formFile { get; set; }
}