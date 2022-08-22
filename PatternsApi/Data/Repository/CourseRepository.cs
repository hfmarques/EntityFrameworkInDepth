using Microsoft.EntityFrameworkCore;
using PatternsApi.Models;

namespace PatternsApi.Data.Repository;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    private PlutoContext PlutoContext => (Context as PlutoContext)!;

    public CourseRepository(DbContext context) : base(context)
    {
    }

    public IEnumerable<Course> GetTopSellingCourses(int count)
    {
        return PlutoContext.Courses.OrderByDescending(x => x.FullPrice).Take(count).ToList();
    }

    public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize)
    {
        return PlutoContext.Courses
            .Include(x => x.Author)
            .OrderBy(x => x.Name)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
}