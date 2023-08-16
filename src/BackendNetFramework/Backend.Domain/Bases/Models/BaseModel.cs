﻿using System;

namespace Backend.Domain.Bases.Models;

public abstract class BaseModel
{
    public BaseModel()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }

}