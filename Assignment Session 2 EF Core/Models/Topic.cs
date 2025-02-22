
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Session_1_EF_Core.Models
{
    internal class Topic
    {
        // #region By Convention

        // public int Id { get; set; } 



        // public string? Name { get; set; }

        ////Navigation Property [One]
        //public Course? TopicCourse { get; set; }
        //#endregion

        #region By Annotation

        [Key]
        public int Id { get; set; } //Pk with identity Constraint [1,1]


        [Required]
        [Column("TopicNmae", TypeName = "VarChar")]
        [StringLength(50, MinimumLength = 3)] //Since that Min is an Application Validation , It will not be Mapped
        //Only Max (50) Will be Mapped
        public string? Name { get; set; }


        //Navigation Property [One]
        [InverseProperty(nameof(Course.CourseTopic))]
        public Course? TopicCourse { get; set; }
        #endregion
    }
}
