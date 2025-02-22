using Assignment_Session_1_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Session_2_EF_Core.Configuration
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> S)
        {
            //RelationShip Between Student & Department
            S.HasOne(S => S.StudentDepartment)
             .WithMany(D => D.Students)
             .HasForeignKey(D => D.StuddntDepartmentID)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
