﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System.Diagnostics;
using FilteredInclude.Classes;
using FilteredInclude.Models;
using Microsoft.Extensions.Logging;

#nullable disable


namespace FilteredInclude.Data;

public partial class NorthWindContext : DbContext
{
    private readonly ConnectionOption _express;
    private bool _sensitiveLogging;

    public NorthWindContext()
    {
    }
    /// <summary>
    /// Custom instantiation
    /// </summary>
    /// <param name="sensitiveLogging">enable or disable logging</param>
    /// <param name="option">use localDb or SqlExpress</param>
    public NorthWindContext(bool sensitiveLogging, ConnectionOption option = ConnectionOption.mssqllocaldb)
    {
        _sensitiveLogging = sensitiveLogging;
        _express = option;
    }
    public NorthWindContext(DbContextOptions<NorthWindContext> options) : base(options)
    {
    }

    public virtual DbSet<Customers> Customers { get; set; }
    public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    public virtual DbSet<Orders> Orders { get; set; }
    public virtual DbSet<Products> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // typically we do not store connection information here
        if (!optionsBuilder.IsConfigured)
        {
               
            if ( _express is ConnectionOption.SqlExpress )
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWindAzure3;Integrated Security=True;Encrypt=False").EnableSensitiveDataLogging()
                    .LogTo(new DbContextToFileLogger().Log,
                        new[]
                        {
                            DbLoggerCategory.Database.Command.Name
                        },
                        LogLevel.Information);
            }
            else
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NorthWindAzure3;Trusted_Connection=True;").EnableSensitiveDataLogging()
                    .LogTo(new DbContextToFileLogger().Log,
                        new[]
                        {
                            DbLoggerCategory.Database.Command.Name
                        },
                        LogLevel.Information);
            }

            if (_sensitiveLogging)
            {
                optionsBuilder.EnableSensitiveDataLogging().LogTo(message => Debug.WriteLine(message));
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.ApplyConfiguration(new Configurations.CustomersConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.OrderDetailsConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.OrdersConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ProductsConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}