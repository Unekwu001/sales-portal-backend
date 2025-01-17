﻿// <auto-generated />
using System;
using Data.ipNXContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(IpNxDbContext))]
    [Migration("20240604170210_smeAndResidentialupdate4")]
    partial class smeAndResidentialupdate4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Models.AgentModel.Agent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("Data.Models.CoverageModels.CoverageLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CoverageName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Lga")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("CoverageLocations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("247708b7-354c-4ad6-ae51-b2ec02e112fb"),
                            CoverageName = "Parkview Coverage Gap",
                            Latitude = 6.4499999999999993,
                            Lga = "Ikoyi",
                            Longitude = 3.4333330000000002,
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("f01ca0cf-0cac-4c52-979b-605e334f0bde"),
                            CoverageName = "victoria garden city",
                            Latitude = 6.464587400000001,
                            Lga = "Ajah",
                            Longitude = 3.5725243999999998,
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("b0f05a57-19ca-420f-b0ef-4c9e07198f2e"),
                            CoverageName = "Oral Estate",
                            Latitude = 6.4466677000000008,
                            Lga = "Lekki",
                            Longitude = 3.5465458000000001,
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("6125d7d0-176f-4dc8-9248-1b10c552e170"),
                            CoverageName = "Northern Foreshore",
                            Latitude = 6.4582094999999997,
                            Lga = "lekki",
                            Longitude = 3.5218280000000002,
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("dcfd09b7-3007-4194-9631-2d137526ec7b"),
                            CoverageName = "Ikota GRA",
                            Latitude = 6.4460404999999996,
                            Lga = "lekki",
                            Longitude = 3.5577774,
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("68975c6a-123b-40d1-a3fd-1dfdec13e5bb"),
                            CoverageName = "Lekki Phase 1",
                            Latitude = 6.4478092999999994,
                            Lga = "lekki",
                            Longitude = 3.4723495,
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("8be0ccb6-edd8-4cfa-87fd-7174a3f946cf"),
                            CoverageName = "Ammsco Platinum",
                            Latitude = 8.9982132000000004,
                            Lga = "Galadimawa",
                            Longitude = 7.4244746999999993,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("fe8351bf-6164-4c45-99ad-f2ae2e5cf468"),
                            CoverageName = "Fafu Estate",
                            Latitude = 8.9786175000000004,
                            Lga = "Lokogoma",
                            Longitude = 7.4581913999999996,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("48ddac57-23c6-4c6e-9d8f-fc3c07704b27"),
                            CoverageName = "Wonderland Estate",
                            Latitude = 9.017571199999999,
                            Lga = "Kukwaba",
                            Longitude = 7.4339159000000006,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("f49bb045-683e-42fc-97eb-062599500d2f"),
                            CoverageName = "Aminas Court",
                            Latitude = 8.9775469999999995,
                            Lga = "Apo-Dutse",
                            Longitude = 7.4790486999999999,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("3d0ca759-a6df-4ef9-8231-ff14e3607686"),
                            CoverageName = "Sticks and Stones",
                            Latitude = 8.9775469999999995,
                            Lga = "Apo-Dutse",
                            Longitude = 7.4790486999999999,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("0dfb3a18-aea4-4333-93a8-41d089b5f8a3"),
                            CoverageName = "Pleasant Places",
                            Latitude = 8.9775469999999995,
                            Lga = "Apo-Dutse",
                            Longitude = 7.4790486999999999,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("99898088-8190-462c-900d-e47d544bbae2"),
                            CoverageName = "Standard Estate",
                            Latitude = 8.9737823999999993,
                            Lga = "Galadimawa",
                            Longitude = 7.4202883999999987,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("42a2f1d3-7b3b-4d18-9d5f-56aa1a530f4a"),
                            CoverageName = "Trademoore",
                            Latitude = 8.9775469999999995,
                            Lga = "Apo-Dutse",
                            Longitude = 7.4790486999999999,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("ad9a769b-b4c8-4f95-a7d5-d358af55ccf8"),
                            CoverageName = "Jubilation Comfort(Yoruba Estate)",
                            Latitude = 8.9610229999999991,
                            Lga = "Lokogoma",
                            Longitude = 7.4405290000000006,
                            State = "Abuja"
                        });
                });

            modelBuilder.Entity("Data.Models.CoverageModels.GcpGeoCodingApiKey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.ToTable("GcpGeoCodingApiKeys");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9717c441-69b0-4e25-9fcf-bc2cdeb4169c"),
                            Key = "AIzaSyDdN2yR9ooX0Glo7oMHFmBZGVYniVl71Bk"
                        });
                });

            modelBuilder.Entity("Data.Models.CustomerRequestsModels.RequestCallBack", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("CallBackRequests");
                });

            modelBuilder.Entity("Data.Models.CustomerRequestsModels.RequestForInstallation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("InstallationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("InstallationRequests");
                });

            modelBuilder.Entity("Data.Models.DiscountModel.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("numeric");

                    b.Property<Guid>("PlanTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Data.Models.EmailModels.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("SmtpHost")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("SmtpPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("SmtpPort")
                        .HasColumnType("integer");

                    b.Property<string>("SmtpUsername")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("EmailSettings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e25c29df-fc27-47e4-b7d8-c7934d2e00d6"),
                            SmtpHost = "smtp-mail.outlook.com",
                            SmtpPassword = "Otusegwa360@",
                            SmtpPort = 587,
                            SmtpUsername = "unekwutheophilus@outlook.com"
                        });
                });

            modelBuilder.Entity("Data.Models.FileUploadModel.FileUpload", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("FileUploads");
                });

            modelBuilder.Entity("Data.Models.OrderModels.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlanTypeId")
                        .HasColumnType("uuid");

                    b.Property<int>("StatusEnum")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Data.Models.OtpModel.UserOtp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Otp")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("UserOtps");
                });

            modelBuilder.Entity("Data.Models.PlanModels.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PlanName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("Data.Models.PlanModels.PlanType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BandSpeedUnit")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("BandSpeedValue")
                        .HasColumnType("integer");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("KeyFeature1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KeyFeature2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KeyFeature3")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentCycle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid");

                    b.Property<string>("PlanTypeName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SetUpCharge")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.ToTable("PlanTypes");
                });

            modelBuilder.Entity("Data.Models.PlanModels.Residential", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AlternativePhoneNumber")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("City")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("EstateName")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("FlatNumber")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("GovernmentId")
                        .HasColumnType("text");

                    b.Property<string>("HouseNumber")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("IsBillingAddressSameAsResidentialAddress")
                        .IsRequired()
                        .HasColumnType("character varying(1)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nationality")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Occupation")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("PassportPhotograph")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("PlanTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("State")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("StreetName")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("TypeOfBuilding")
                        .HasColumnType("text");

                    b.Property<string>("UtilityBill")
                        .HasColumnType("text");

                    b.Property<string>("networkCoverageAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Residentials");
                });

            modelBuilder.Entity("Data.Models.PlanModels.ResidentialBillingDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("ResidentialId")
                        .HasColumnType("uuid");

                    b.Property<string>("State")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("StreetName")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("ResidentialId")
                        .IsUnique();

                    b.ToTable("ResidentialBillingDetails");
                });

            modelBuilder.Entity("Data.Models.PlanModels.Sme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CertificateOfIncorporation")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("City")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("CompanyStreetName")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("ContactPersonAlternativePhoneNumber")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("ContactPersonEmail")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("ContactPersonFirstName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("ContactPersonLastName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("ContactPersonPhoneNumber")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GovernmentId")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("IsBillingAddressSameAsResidentialAddress")
                        .IsRequired()
                        .HasColumnType("character varying(1)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LetterOfIntroduction")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("PassportPhotograph")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("PlanTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("State")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("TypeOfBuilding")
                        .HasColumnType("text");

                    b.Property<string>("TypeOfBusiness")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("UtilityBill")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("networkCoverageAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Smes");
                });

            modelBuilder.Entity("Data.Models.PlanModels.SmeBillingDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("CompanyStreetName")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("ContactPersonEmail")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("ContactPersonFirstName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("ContactPersonLastName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("ContactPersonPhoneNumber")
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("SmeId")
                        .HasColumnType("uuid");

                    b.Property<string>("State")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("SmeId")
                        .IsUnique();

                    b.ToTable("SmeBillingDetails");
                });

            modelBuilder.Entity("Data.Models.UserModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Models.WebsiteVisitModel.WebsiteVisit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("WebsiteVisits");
                });

            modelBuilder.Entity("Data.Models.PlanModels.PlanType", b =>
                {
                    b.HasOne("Data.Models.PlanModels.Plan", "Plan")
                        .WithMany("PlanTypes")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Data.Models.PlanModels.ResidentialBillingDetail", b =>
                {
                    b.HasOne("Data.Models.PlanModels.Residential", null)
                        .WithOne("ResidentialBillingDetails")
                        .HasForeignKey("Data.Models.PlanModels.ResidentialBillingDetail", "ResidentialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.PlanModels.SmeBillingDetail", b =>
                {
                    b.HasOne("Data.Models.PlanModels.Sme", null)
                        .WithOne("SmeBillingDetails")
                        .HasForeignKey("Data.Models.PlanModels.SmeBillingDetail", "SmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.PlanModels.Plan", b =>
                {
                    b.Navigation("PlanTypes");
                });

            modelBuilder.Entity("Data.Models.PlanModels.Residential", b =>
                {
                    b.Navigation("ResidentialBillingDetails");
                });

            modelBuilder.Entity("Data.Models.PlanModels.Sme", b =>
                {
                    b.Navigation("SmeBillingDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
