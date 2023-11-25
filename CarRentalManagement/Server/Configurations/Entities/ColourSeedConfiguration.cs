using CarRentalManagement.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalManagement.Server.Configurations.Entities
{
    public class ColourSeedConfiguration : IEntityTypeConfiguration<Colour>
    {
        public void Configure(EntityTypeBuilder<Colour> builder)
        {
            builder.HasData(
                 new Colour
                 {
                     id = 1,
                     Name = "Black",
                     DateCreated = DateTime.Now,
                     DateUpdated = DateTime.Now,
                     CreatedBy = "System",
                     UpdatedBy = "System"
                 },
                 new Colour
                 {
                     id = 2,
                     Name = "Blue",
                     DateCreated = DateTime.Now,
                     DateUpdated = DateTime.Now,
                     CreatedBy = "System",
                     UpdatedBy = "System"
                 }
            );

        }
    }
}
