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
    internal class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> T)
        {
            //RelationShip Between Topic & Course [1:M]
            T.HasOne(T => T.TopicCourse)
             .WithOne(C => C.CourseTopic)
             .HasForeignKey<Course>(C => C.TopicCourseId)
             .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
