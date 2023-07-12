﻿using CustomersExercise.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomersExercise.Infrastructure
{
    public class CustomersDbContext : DbContext
    {
        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
