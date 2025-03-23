using Microsoft.AspNetCore.Mvc;
using TheSampleApi.Data;

namespace TheSampleApi.Endpoints;

public static class CoursesEndpoints
{
    public static void AddCoursesEndpoints(this WebApplication app)
    {
        app.MapGet("/courses", LoadAllCourses);
        app.MapGet("/courses/{id:int}", LoadAllCoursesById);
    }

    private static IResult LoadAllCourses(
        CourseData data,
        string? courseType,
        string? searchTerm)
    {
        var output = data.Courses;

        if (!string.IsNullOrWhiteSpace(courseType))
        {
            output.RemoveAll(x => string.Compare(
                x.CourseType, 
                courseType, 
                StringComparison.OrdinalIgnoreCase) != 0);
        }

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            output.RemoveAll(x=> 
                !x.CourseName.Contains(searchTerm,StringComparison.OrdinalIgnoreCase) && 
                !x.ShortDescription.Contains(searchTerm,StringComparison.OrdinalIgnoreCase));
        }
        
        return Results.Ok(output);
    }

    private static IResult LoadAllCoursesById(CourseData data, int id)
    {
        var output = data.Courses.SingleOrDefault(x => x.Id == id);

        return output is null ? Results.NotFound() : Results.Ok(output);
    }
}