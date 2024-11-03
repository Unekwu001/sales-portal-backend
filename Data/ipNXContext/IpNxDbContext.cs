using Data.Models.AgentModel;
using Data.Models.CoverageModels;
using Data.Models.CustomerRequestsModels;
using Data.Models.DiscountModel;
using Data.Models.EmailModels;
using Data.Models.FileUploadModel;
using Data.Models.OrderModels;
using Data.Models.OtpModel;
using Data.Models.PlanModels;
using Data.Models.UserModels;
using Data.Models.WebsiteVisitModel;
using Data.SeededData;
using Microsoft.EntityFrameworkCore;


namespace Data.ipNXContext
{

    public partial class IpNxDbContext : DbContext
    {
        public IpNxDbContext()
        {
        }

        public IpNxDbContext(DbContextOptions<IpNxDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoverageLocation> CoverageLocations { get; set; }

        public virtual DbSet<GcpGeoCodingApiKey> GcpGeoCodingApiKeys { get; set; }

        public virtual DbSet<ResidentialOrder> ResidentialOrders { get; set; }

        public virtual DbSet<ResidentialOrderBillingDetail> ResidentialOrderBillingDetails { get; set; }

        public virtual DbSet<SmeOrder> SmeOrders { get; set; }

        public virtual DbSet<SmeOrderBillingDetail> SmeOrderBillingDetails { get; set; }

        public virtual DbSet<Plan> Plans { get; set; }

        public virtual DbSet<PlanType> PlanTypes { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Email> EmailSettings { get; set; }

        public virtual DbSet<UserOtp> UserOtps { get; set; }

        public virtual DbSet<RequestForInstallation> InstallationRequests { get; set; }

        public virtual DbSet<RequestCallBack> CallBackRequests { get; set; }

        public virtual DbSet<Agent> Agents { get; set; }

        public virtual DbSet<FileUpload> FileUploads { get; set; }

        public virtual DbSet<Discount> Discounts { get; set; }

        public virtual DbSet<WebsiteVisit> WebsiteVisits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoverageLocation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.CoverageName).HasMaxLength(500);
                entity.Property(e => e.Latitude);
                entity.Property(e => e.Lga).HasMaxLength(255);
                entity.Property(e => e.Longitude);
                entity.Property(e => e.State).HasMaxLength(255);
            });
            modelBuilder.ApplyConfiguration(new CoverageLocationSeeder());


            modelBuilder.Entity<GcpGeoCodingApiKey>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Key).HasMaxLength(500);
            });
            modelBuilder.ApplyConfiguration(new GcpGeoCodingApiKeySeeder());



            modelBuilder.Entity<ResidentialOrder>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasMaxLength(500).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(500).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(500).IsRequired();
                entity.Property(e => e.PhoneNumber).HasMaxLength(500).IsRequired();
                entity.Property(e => e.State).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(200);
                entity.Property(e => e.StreetName).HasMaxLength(200);
                entity.Property(e => e.AlternativePhoneNumber).HasMaxLength(200);
                entity.Property(e => e.EstateName).HasMaxLength(200);
                entity.Property(e => e.HouseNumber).HasMaxLength(200);
                entity.Property(e => e.FlatNumber).HasMaxLength(200);
                entity.Property(e => e.Gender).HasConversion<string>();
                entity.Property(e => e.Nationality).HasMaxLength(200);
                entity.Property(e => e.Occupation).HasMaxLength(200);
                entity.Property(e => e.DateOfBirth).HasColumnType("date");
                entity.Property(e => e.TypeOfBuilding).HasConversion<string>();
                entity.Property(e => e.IsBillingAddressSameAsResidentialAddress).HasConversion<string>();

                entity.HasOne(e => e.Agent)
                .WithMany(a => a.ResidentialOrders)
                .HasForeignKey(e => e.AgentId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<ResidentialOrderBillingDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasMaxLength(500).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(500).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(500).IsRequired();
                entity.Property(e => e.PhoneNumber).HasMaxLength(500).IsRequired();
                entity.Property(e => e.State).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(200);
                entity.Property(e => e.StreetName).HasMaxLength(200);            

            });


            modelBuilder.Entity<SmeOrder>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.CompanyName).HasMaxLength(500).IsRequired();
                entity.Property(e => e.ContactPersonFirstName).HasMaxLength(500).IsRequired();
                entity.Property(e => e.ContactPersonLastName).HasMaxLength(500).IsRequired();
                entity.Property(e => e.ContactPersonEmail).HasMaxLength(500).IsRequired();
                entity.Property(e => e.ContactPersonPhoneNumber).HasMaxLength(500);
                entity.Property(e => e.State).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(200);
                entity.Property(e => e.ContactPersonAlternativePhoneNumber).HasMaxLength(200);
                entity.Property(e => e.TypeOfBusiness).HasMaxLength(200);
                entity.Property(e => e.CompanyStreetName).HasMaxLength(1000);
                entity.Property(e => e.TypeOfBuilding).HasConversion<string>();
                entity.Property(e => e.IsBillingAddressSameAsResidentialAddress).HasConversion<string>();
                entity.Property(e => e.PassportPhotograph).HasMaxLength(500);
                entity.Property(e => e.LetterOfIntroduction).HasMaxLength(500);
                entity.Property(e => e.GovernmentId).HasMaxLength(500);
                entity.Property(e => e.UtilityBill).HasMaxLength(500);
                entity.Property(e => e.CertificateOfIncorporation).HasMaxLength(500);

                entity.HasOne(e => e.Agent)
                .WithMany(a => a.SmeOrders)
                .HasForeignKey(e => e.AgentId)
                .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<SmeOrderBillingDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.ContactPersonFirstName).HasMaxLength(500).IsRequired();
                entity.Property(e => e.ContactPersonLastName).HasMaxLength(500).IsRequired();
                entity.Property(e => e.ContactPersonEmail).HasMaxLength(500).IsRequired();
                entity.Property(e => e.State).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(200);
                entity.Property(e => e.CompanyStreetName).HasMaxLength(200);
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.PlanName).HasMaxLength(128).IsRequired();
                entity.Property(e => e.SetUpCharge);
                entity.Property(e => e.PhoneLine).HasMaxLength(128);

                entity.HasMany(e => e.PlanTypes)
                .WithOne(e => e.Plan)
                .HasForeignKey(e => e.PlanId);

            });

            modelBuilder.Entity<PlanType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.PlanTypeName).HasMaxLength(500).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.PaymentCycle).HasConversion<string>().IsRequired();
                entity.Property(e => e.BandSpeedValue).IsRequired();
                entity.Property(e => e.BandSpeedUnit).HasMaxLength(100).IsRequired();
                entity.Property(e => e.SetUpCharge).IsRequired();
                entity.Property(e => e.DataAllowance).HasMaxLength(100);

                entity.HasOne(pt => pt.Discount)
                .WithMany(d => d.PlanTypes)
                .HasForeignKey(pt => pt.DiscountId)
                .OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.HashedPassword).HasMaxLength(255);
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.Email).HasMaxLength(128);
                entity.Property(e => e.CompanyName).HasMaxLength(255);
                entity.Property(e => e.FirstName).HasMaxLength(255);
                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.HasIndex(e => e.Email).IsUnique();

            });


            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.SmtpPort);
                entity.Property(e => e.SmtpHost).HasMaxLength(255);
                entity.Property(e => e.SmtpPassword).HasMaxLength(255);
                entity.Property(e => e.SmtpUsername).HasMaxLength(255);
            });
            modelBuilder.ApplyConfiguration(new EmailSeeder());

            modelBuilder.Entity<UserOtp>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.Otp).HasMaxLength(255);
                entity.Property(e => e.Expiration);
            });


            modelBuilder.Entity<RequestForInstallation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.InstallationDate).IsRequired();
                entity.Property(e => e.OrderId).IsRequired();
            });

            modelBuilder.Entity<RequestCallBack>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(500);
                entity.Property(e => e.Region).HasMaxLength(128);
                entity.Property(e => e.Type).HasMaxLength(128);

                entity.Property(e => e.Address).HasMaxLength(255);

            });
            modelBuilder.Entity<FileUpload>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.FileName).HasMaxLength(500);
                entity.Property(e => e.FilePath).HasMaxLength(500);
                entity.Property(e => e.UploadDate);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.States).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Cities).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Streets).HasMaxLength(255).IsRequired();
                entity.Property(e => e.StartDate);
                entity.Property(e => e.EndDate);
                entity.Property(e => e.Percentage).IsRequired();

                entity.HasMany(d => d.PlanTypes)
                .WithOne(pt => pt.Discount)
                .HasForeignKey(pt => pt.DiscountId);
            });

            modelBuilder.Entity<WebsiteVisit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();              
                entity.Property(e => e.VisitDate).IsRequired();

            });
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
