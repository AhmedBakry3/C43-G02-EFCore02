using Assignment_Session_1_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Session_2_EF_Core.Configuration
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> D)
        {
            //RelationShip Between Department & Instructor [1:1]
            D.HasOne(D => D.ManagesInstructors)
             .WithOne(I => I.ManagesInstDept)
             .HasForeignKey<Department>(D => D.InstructorDepartmentId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
