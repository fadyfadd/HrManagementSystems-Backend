using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrManagementSystems.DataContext
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments", "dbo");
            builder.HasKey(a => a.DepartmentId);
            builder.Property(a => a.DepartmentId).HasColumnName("DepartmentId");
            builder.Property(a => a.DepartmentName).HasColumnName("DepartmentName");
            builder.Property(a => a.ManagerId).HasColumnName("ManagerId");
           
            
        }
    }
}
