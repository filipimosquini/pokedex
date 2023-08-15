﻿namespace Backend.Domain.Bases.Models;

public abstract class BaseModel
{
    public BaseModel()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

}