﻿namespace MentallHealthSupport.Application.Models.Entities;

public class Spot
{
    public Guid Id { get; }

    public Guid PsychologistId { get; set; }

    public DateOnly Date { get; set; }

    public DateTime HourStart { get; set; }

    public DateTime HourEnd { get; set; }

    public string? Status { get; set; }
 }