﻿namespace PatternsApi.Models;

#nullable disable
public class Tag
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Course> Courses { get; set; }
}