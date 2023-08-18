using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataService.Entities;

public partial class TwilioAppContext : DbContext
{
    public TwilioAppContext()
    {
    }

    public TwilioAppContext(DbContextOptions<TwilioAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserDataTable> UserDataTables { get; set; }

    [DbFunction("TwilioAppContext", "GetDigitsFromPhoneNumber")]
    public static string GetDigitsFromPhoneNumber(string number)
    {
        try
        {
            string newstring = new string(number.Where(char.IsDigit).ToArray());
            var t = newstring.Substring(newstring.Length - 10, 10);
            return t;
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=TwilioApp;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDataTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserData__3214EC07A2DD25E9");

            entity.ToTable("UserDataTable");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Account)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.House)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ScheduleDate).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
