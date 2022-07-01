using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Interfaces;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

[ApiController]
[Route("[controller]")]


public class UploadFileController : Controller
{

    private readonly IUploadFileHelper _uploadFileHelper;

    public UploadFileController(IUploadFileHelper uploadFileHelper)
    {
        _uploadFileHelper = uploadFileHelper;
    }

    [HttpPost("UploadImage")]
    public IActionResult UploadImage([FromQuery]UploadImage uploadImage)
    {
        if (_uploadFileHelper.UploadImage(uploadImage))
        {
            return Ok();
        }

        return BadRequest();

    }
}
