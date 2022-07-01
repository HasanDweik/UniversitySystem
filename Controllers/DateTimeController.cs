using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Interfaces;

namespace UniversitySystem.Controllers;

[ApiController]
[Route("[controller]")]

public class DateTimeController : Controller
{
    private readonly IDateTimeHelper _dateTimeHelper;

    public DateTimeController(IDateTimeHelper dateTimeHelper)
    {
        _dateTimeHelper = dateTimeHelper;
    }

    [HttpGet("GetCurrentDateTime")]
    public string GetCurrentDateTime(string s)
    {
        return _dateTimeHelper.GetCurrentDateTime(s);
    }
  
}