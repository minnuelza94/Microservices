﻿// <auto-generated />
using System;
using BankMangementMicroservice.Data.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankMangementMicroservice.Data.Migrations
{
    [DbContext(typeof(CustomerDbContext))]
    partial class CustomerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankMangementMicroservice.Data.Entity.CustomerDetail", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ContactNo")
                        .HasColumnType("bigint");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId")
                        .HasName("PK_CustomerId");

                    b.ToTable("CustomerDetail");
                });

            modelBuilder.Entity("BankMangementMicroservice.Data.Entity.LoanDetail", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DurationofLoan")
                        .HasColumnType("int");

                    b.Property<double>("LoanAmount")
                        .HasColumnType("float");

                    b.Property<string>("LoanType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("RateofInterest")
                        .HasColumnType("real");

                    b.Property<DateTime?>("UpdatedOnUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("LoanId")
                        .HasName("PK_LoanId");

                    b.HasIndex("CustomerId");

                    b.ToTable("LoanDetail");
                });

            modelBuilder.Entity("BankMangementMicroservice.Data.Entity.LoanDetail", b =>
                {
                    b.HasOne("BankMangementMicroservice.Data.Entity.CustomerDetail", "CustomerDetail")
                        .WithMany("LoanDeatils")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("Fk_LoanDeatil_CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerDetail");
                });

            modelBuilder.Entity("BankMangementMicroservice.Data.Entity.CustomerDetail", b =>
                {
                    b.Navigation("LoanDeatils");
                });
#pragma warning restore 612, 618
        }
    }
}