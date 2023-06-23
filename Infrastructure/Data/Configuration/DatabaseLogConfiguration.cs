﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class DatabaseLogConfiguration : IEntityTypeConfiguration<DatabaseLog>
{
    public void Configure(EntityTypeBuilder<DatabaseLog> builder)
    {

        builder.ToTable("DatabaseLog", tb => tb.HasComment("Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog."));

        builder.Property(e => e.Id)
            .HasComment("Primary key for DatabaseLog records.")
            .HasColumnName("Id");
        builder.Property(e => e.DatabaseUser)
            .HasMaxLength(128)
            .HasComment("The user who implemented the DDL change.");
        builder.Property(e => e.Event)
            .HasMaxLength(128)
            .HasComment("The type of DDL statement that was executed.");
        builder.Property(e => e.Object)
            .HasMaxLength(128)
            .HasComment("The object that was changed by the DDL statment.");
        builder.Property(e => e.PostTime)
            .HasComment("The date and time the DDL change occurred.")
            .HasColumnType("datetime");
        builder.Property(e => e.Schema)
            .HasMaxLength(128)
            .HasComment("The schema to which the changed object belongs.");
        builder.Property(e => e.Tsql)
            .HasComment("The exact Transact-SQL statement that was executed.")
            .HasColumnName("TSQL");
        builder.Property(e => e.XmlEvent)
            .HasComment("The raw XML data generated by database trigger.")
            .HasColumnType("xml");
    }
}
