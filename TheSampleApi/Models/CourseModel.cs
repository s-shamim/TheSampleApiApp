namespace TheSampleApi.Models;

public class CourseModel
{
    public int Id { get; set; }
    public bool IsPreOrder { get; set; }
    public required string CourseUrl { get; set; }
    public required string CourseType { get; set; }
    public required string CourseName { get; set; }
    public int CourseLessonCount { get; set; }
    public double CourseLengthInHours { get; set; }
    public required string ShortDescription { get; set; }
    public required string CourseImage { get; set; }
    public int PriceInUsd { get; set; }
    public required string CoursePreviewLink { get; set; }
}

