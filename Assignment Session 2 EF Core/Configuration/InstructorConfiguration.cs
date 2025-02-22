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
    internal class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> I)
        {
            //RelationShip Between Department & Instructor [1:M]
           I.HasOne(I=>I.WorksInInstructorDepartment)
            .WithMany(D=>D.WorksInInstrucotrs)
            .HasForeignKey(I=>I.InstDeptID)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
