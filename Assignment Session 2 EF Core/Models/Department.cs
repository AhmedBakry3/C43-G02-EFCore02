
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Session_1_EF_Core.Models
{
    //Model : Poco Class [Plaing Old CLR Object] - Domain Entity
    [Table("Departments")]
    internal class Department
    {
        //#region By Convention
        //public int Id { get; set; } 

        //public string? Name { get; set; }

        //public DateTime HiringDate { get; set; }

        //ForeignKey
        //public int ManagesInstructorsId { get; set; }

        ////Navigation Preoprty For Student : [Many]
        //public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        ////Navigation Property For Instructor For WorksIn Relationship : [Many]
        //public ICollection<Instructor>? WorksInInstrucotrs { get; set; } = new HashSet<Instructor>();

        ////Navigation Property For Instructor For Manges Relationship : [One]
        //public Instructor ManagesInstructors { get; set; } = null!;

        //Since Department has Multiple relationship , we cant do it By Convention or Data Annotation , we can only do it with Fluent API
        //#endregion

        #region By Annotation
        [Key]
        public int Id { get; set; } //Pk with identity Constraint [1,1]


        [Required]
        [Column("DepartmentAddress", TypeName = "VarChar")]
        [StringLength(70, MinimumLength = 3)] //Since that Min is an Application Validation , It will not be Mapped
        //Only Max (70) Will be Mapped
        public string? Name { get; set; }
        //Nullable Reference Type
        //string? is Mapped to NVarChar(Max) , Allow Null

        [Column("StudentHiringDate", TypeName = "DateTime2")]
        public DateTime HiringDate { get; set; }

        [ForeignKey(nameof(ManagesInstructors))]
        //ForeignKey
        public int InstructorDepartmentId { get; set; }

        //Navigation Preoprty For Student : [Many]
        [InverseProperty(nameof(Student.StudentDepartment))]
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        //Navigation Property For Instructor For WorksIn Relationship : [Many]
        [InverseProperty(nameof(Instructor.WorksInInstructorDepartment))]
        public ICollection<Instructor>? WorksInInstrucotrs { get; set; } = new HashSet<Instructor>();

        //Navigation Property For Instructor For Manges Relationship : [One]
        [InverseProperty(nameof(Instructor.ManagesInstDept))]
        public Instructor ManagesInstructors { get; set; } = null!;

        ////Since Department has Multiple relationship , we cant do it By Convention or by Data Annotation , we Can only do it with Fluent API ,
        ///Migration Happens , but you cant Update-Database Because Confilit Between RelationShips Because of Casacade

        #endregion
    }
}
