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
    [Migration("20240604123624_updatedSmeAndResidential")]
    partial class updatedSmeAndResidential
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
                            Id = new Guid("9a192dc0-36b3-4b0d-8f17-e939eae1e84d"),
                            CoverageName = "Parkview Coverage Gap",
                            Latitude = 6.4499999999999993,
                            Lga = "Ikoyi",
                            Longitude = 3.4333330000000002,
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("51f0d2cc-92e4-4830-b04e-23fb9966c090"),
                            CoverageName = "victoria garden city",
                            Latitude = 6.464587400000001,
                            Lga = "Ajah",
                            Longitude = 3.5725243999999998,
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("2f4cc87f-9206-4c97-b435-7feb1ddd567f"),
                            CoverageName = "Oral Estate",
                            Latitude = 6.4466677000000008,
                            Lga = "Lekki",
                            Longitude = 3.5465458000000001,
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("e46ede8a-46b4-4d31-8bc8-2af130dc3995"),
                            CoverageName = "Northern Foreshore",
                            Latitude = 6.4582094999999997,
                            Lga = "lekki",
                            Longitude = 3.5218280000000002,
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("08969f0c-8a2c-451f-ae79-da333aaacf00"),
                            CoverageName = "Ikota GRA",
                            Latitude = 6.4460404999999996,
                            Lga = "lekki",
                            Longitude = 3.5577774,
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("2e7e7207-e8ff-4ea2-aff9-cfae4b97562b"),
                            CoverageName = "Lekki Phase 1",
                            Latitude = 6.4478092999999994,
                            Lga = "lekki",
                            Longitude = 3.4723495,
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("b0a972ce-e1b0-4b9c-a49f-a10459f85ab3"),
                            CoverageName = "Ammsco Platinum",
                            Latitude = 8.9982132000000004,
                            Lga = "Galadimawa",
                            Longitude = 7.4244746999999993,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("26a35dad-6d01-4ea6-bfa0-478a518cd5fc"),
                            CoverageName = "Fafu Estate",
                            Latitude = 8.9786175000000004,
                            Lga = "Lokogoma",
                            Longitude = 7.4581913999999996,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("3686eb74-b89e-49cc-b707-2725b597e360"),
                            CoverageName = "Wonderland Estate",
                            Latitude = 9.017571199999999,
                            Lga = "Kukwaba",
                            Longitude = 7.4339159000000006,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("2b4132f1-851f-40e0-a5ff-7784429c5489"),
                            CoverageName = "Aminas Court",
                            Latitude = 8.9775469999999995,
                            Lga = "Apo-Dutse",
                            Longitude = 7.4790486999999999,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("ae44d2e5-031a-4ca6-88a3-7e94fc56c842"),
                            CoverageName = "Sticks and Stones",
                            Latitude = 8.9775469999999995,
                            Lga = "Apo-Dutse",
                            Longitude = 7.4790486999999999,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("1b4d7124-7868-4903-8e2a-1d08d70f465a"),
                            CoverageName = "Pleasant Places",
                            Latitude = 8.9775469999999995,
                            Lga = "Apo-Dutse",
                            Longitude = 7.4790486999999999,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("37dcafa1-ea54-466d-9ed5-52cd53816d3e"),
                            CoverageName = "Standard Estate",
                            Latitude = 8.9737823999999993,
                            Lga = "Galadimawa",
                            Longitude = 7.4202883999999987,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("14231066-ebdf-4cd7-887e-17b86def5f6b"),
                            CoverageName = "Trademoore",
                            Latitude = 8.9775469999999995,
                            Lga = "Apo-Dutse",
                            Longitude = 7.4790486999999999,
                            State = "Abuja"
                        },
                        new
                        {
                            Id = new Guid("cd8440cb-369d-4a71-b735-dd4886b17b97"),
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
                            Id = new Guid("8a474e3b-a69f-4482-a29c-123f3118d634"),
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
                            Id = new Guid("78c30738-6dd2-4c55-aa98-608386295b4f"),
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

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

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

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

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

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

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

                    b.HasKey("Id");

                    b.HasIndex("ContactPersonEmail")
                        .IsUnique();

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

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

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

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdatedOnUtc")
                        .HasColumnType("timestamp with time zone");

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
