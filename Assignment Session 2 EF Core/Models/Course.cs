

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Session_1_EF_Core.Models
{
    //Model : Poco Class [Plaing Old CLR Object] - Domain Entity
    [Table("Courses")]
    internal class Course
    {

        //#region By Convention
        //public int Id { get; set; }


        //public decimal Duration { get; set; }

        //public string? Name { get; set; }

        //public string? Description { get; set; }

        ////Foreign Key
        //public int CourseTopicId { get; set; }

        ////Navigation Preoprty For Topic : [One]
        //public Topic? CourseTopic { get; set; }

        //#endregion

        #region By Annontation
        [Key]
        public int CourseId { get; set; } //Pk with identity Constraint [1,1]

        [Column("CourseDuration", TypeName = "decimal(10,2)")]
        public decimal Duration { get; set; }

        [Required]
        [Column("CourseName", TypeName = "VarChar(50)")]
        public string? Name { get; set; }
        //Nullable Reference Type
        //string? is Mapped to NVarChar(Max) , Allow Null


        [Required]
        [Column("CourseDecription", TypeName = "VarChar(50)")]
        public string? Description { get; set; }


        [ForeignKey(nameof(CourseTopic))]
        //Foreign Key
        public int TopicCourseId { get; set; }

        //Navigation Preoprty For Topic : [One]
        [InverseProperty(nameof(Topic.TopicCourse))]
        public Topic? CourseTopic { get; set; }
        #endregion

    }

}
