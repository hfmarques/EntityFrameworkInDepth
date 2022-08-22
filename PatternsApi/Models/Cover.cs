﻿namespace PatternsApi.Models;

#nullable disable
public class Cover
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public virtual Course Course { get; set; }
}