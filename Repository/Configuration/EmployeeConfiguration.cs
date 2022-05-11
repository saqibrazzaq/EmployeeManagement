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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData
                (
                new Employee
                {
                    Id = new Guid("3070e5f0-90a6-4ccd-82ca-dd437e1ba295"),
                    Name = "Saqib Razzaq",
                    Age = 41,
                    Position = "CEO",
                    CompanyId = new Guid("50575e92-4a29-4557-9a4b-8a96278a6dbe")
                },
                new Employee
                {
                    Id = new Guid("c4ca2c04-0f10-4324-992f-33e41e9f006e"),
                    Name = "Rabia Basri",
                    Age = 38,
                    Position = "Director",
                    CompanyId = new Guid("50575e92-4a29-4557-9a4b-8a96278a6dbe")
                },
                new Employee
                {
                    Id = new Guid("b5279d7a-d4ae-42a7-871c-7997ab9bb2a2"),
                    Name = "Shaheer Saqib",
                    Age = 11,
                    Position = "CEO",
                    CompanyId = new Guid("c65761ae-89fa-4c5c-98b6-4f55eb454f59")
                }
                );
        }
    }
}
