using Microsoft.AspNetCore.Mvc;
using PatternsApi.Data;

namespace PatternsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;

    public CourseController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var courses = unitOfWork.Courses.GetAll();

        return Ok(courses);
    }

    [HttpGet("GetById/id/{id:int}")]
    public IActionResult GetById(int id)
    {
        var course = unitOfWork.Courses.Get(id);

        if (course == null)
            return NotFound();

        return Ok(course);
    }


    [HttpGet("GetTopSellingCourses/count/{count:int}")]
    public IActionResult GetTopSellingCourses(int count)
    {
        var courses = unitOfWork.Courses.GetTopSellingCourses(count);

        return Ok(courses);
    }

    [HttpGet("GetCoursesWithAuthors/pageIndex/{pageIndex:int}/pageSize/{pageSize:int}")]
    public IActionResult GetCoursesWithAuthors(int pageIndex, int pageSize)
    {
        var courses = unitOfWork.Courses.GetCoursesWithAuthors(pageIndex, pageSize);

        return Ok(courses);
    }
}