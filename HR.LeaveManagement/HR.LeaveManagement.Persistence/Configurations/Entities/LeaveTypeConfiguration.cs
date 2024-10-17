using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HR.LeaveManagement.Persistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    ID = 1,
                    DefaultDays = 10,
                    Name = "Vacation",
                    CreatedBy = "Configuration",
                    LastModifiedBy = "Configuration"
                },
                new LeaveType
                {
                    ID = 2,
                    DefaultDays = 12,
                    Name = "Sick",
                    CreatedBy = "Configuration",
                    LastModifiedBy = "Configuration"
                }
            );
        }
    }
}
