using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
            (
                new Company
                {
                    Id = new Guid("50575e92-4a29-4557-9a4b-8a96278a6dbe"),
                    Name = "IT_Solutions Ltd",
                    Address = "House 498, Street 105, Model Town, Humak, Islamabad",
                    Country = "Pakistan"
                },
                new Company
                {
                    Id = new Guid("c65761ae-89fa-4c5c-98b6-4f55eb454f59"),
                    Name = "Admin_Solutions Ltd",
                    Address = "House 1228i, Usman Block, Bahria Phase 8, Rawalpindi",
                    Country = "Pakistan"
                }
            );
        }
    }
}
