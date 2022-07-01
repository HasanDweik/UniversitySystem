using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Models;

namespace UniversitySystem.Interfaces;

public interface IUploadFileHelper
{
   public Boolean UploadImage(UploadImage uploadImage);
}