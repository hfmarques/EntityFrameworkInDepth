using PatternsApi.Models;

namespace PatternsApi.Data.Repository;

public interface ICourseRepository : IRepository<Course>
{
    IEnumerable<Course> GetTopSellingCourses(int count);
    IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
}