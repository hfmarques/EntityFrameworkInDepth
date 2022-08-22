using Microsoft.AspNetCore.Mvc;
using PatternsApi.Data;

namespace PatternsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;

    public AuthorController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var authors = unitOfWork.Authors.GetAll();

        return Ok(authors);
    }
}