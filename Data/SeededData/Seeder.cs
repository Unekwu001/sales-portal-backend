
using Data.Models.CoverageModels;
using Data.Models.EmailModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.SeededData
{
    public class CoverageLocationSeeder : IEntityTypeConfiguration<CoverageLocation>
    {
        public void Configure(EntityTypeBuilder<CoverageLocation> builder)
        {

            //builder.HasData(
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Parkview Coverage Gap", State = "Lagos", Lga = "Ikoyi", Longitude = 3.433333, Latitude = 6.4499999999999993 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "victoria garden city", State = "Lagos", Lga = "Ajah", Longitude = 3.5725244, Latitude = 6.464587400000001 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Oral Estate", State = "Lagos", Lga = "Lekki", Longitude = 3.5465458, Latitude = 6.4466677000000008 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Northern Foreshore", State = "Lagos", Lga = "lekki", Longitude = 3.521828, Latitude = 6.4582095 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Ikota GRA", State = "Lagos", Lga = "lekki", Longitude = 3.5577774, Latitude = 6.4460405 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Lekki Phase 1", State = "Lagos", Lga = "lekki", Longitude = 3.4723495, Latitude = 6.4478092999999994 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Ammsco Platinum", State = "Abuja", Lga = "Galadimawa", Longitude = 7.4244746999999993, Latitude = 8.9982132 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Fafu Estate", State = "Abuja", Lga = "Lokogoma", Longitude = 7.4581914, Latitude = 8.9786175 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Wonderland Estate", State = "Abuja", Lga = "Kukwaba", Longitude = 7.4339159000000006, Latitude = 9.017571199999999 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Aminas Court", State = "Abuja", Lga = "Apo-Dutse", Longitude = 7.4790487, Latitude = 8.977547 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Sticks and Stones", State = "Abuja", Lga = "Apo-Dutse", Longitude = 7.4790487, Latitude = 8.977547 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Pleasant Places", State = "Abuja", Lga = "Apo-Dutse", Longitude = 7.4790487, Latitude = 8.977547 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Standard Estate", State = "Abuja", Lga = "Galadimawa", Longitude = 7.4202883999999987, Latitude = 8.9737824 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Trademoore", State = "Abuja", Lga = "Apo-Dutse", Longitude = 7.4790487, Latitude = 8.977547 },
            //    new CoverageLocation { Id = Guid.NewGuid(), CoverageName = "Jubilation Comfort(Yoruba Estate)", State = "Abuja", Lga = "Lokogoma", Longitude = 7.4405290000000006, Latitude = 8.9610229999999991 }
            //);
        }
    }

    public class GcpGeoCodingApiKeySeeder : IEntityTypeConfiguration<GcpGeoCodingApiKey>
    {
        public void Configure(EntityTypeBuilder<GcpGeoCodingApiKey> builder)
        {

            //builder.HasData(
            //    new GcpGeoCodingApiKey { Id = Guid.NewGuid(), Key = "AIzaSyDdN2yR9ooX0Glo7oMHFmBZGVYniVl71Bk" }
            //);
        }

    }




    public class EmailSeeder : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {

            //builder.HasData(
            //    new Email { Id = Guid.NewGuid(), SmtpHost = "smtp-mail.outlook.com", SmtpPassword = "Otusegwa360@", SmtpPort = 587, SmtpUsername = "unekwutheophilus@outlook.com" }
            //);
        }

    }






}
