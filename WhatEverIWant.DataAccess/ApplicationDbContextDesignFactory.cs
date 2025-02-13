﻿using Microsoft.EntityFrameworkCore.Design;

namespace WhatEverIWant.DataAccess;

public class ApplicationDbContextDesignFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite("Data Source=test.db");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}