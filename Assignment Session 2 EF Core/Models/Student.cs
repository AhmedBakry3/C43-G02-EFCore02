
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Session_1_EF_Core.Models
{
    //Model : Poco Class [Plaing Old CLR Object] - Domain Entity
    [Table("Students")]
    internal class Student
    {
        //#region By Convention


        //public int Id { get; set; } 


        //public string? FName { get; set; }


        //public string? LName { get; set; }

        //public string? Address { get; set; }

        //public int Age { get; set; }

        ////Foreign Key 
        //public int StudentDepartmentId { get; set; }

        ////Navigation Property : [One]
        //[InverseProperty(nameof(Department.Students))]  
        //public Department? StudentDepartment { get; set; }

        //#endregion

        #region By Data Annotation

        [Key]
        public int Id { get; set; } //Pk with identity Constraint [1,1]

        [Required]
        [Column("StudentFirstName", TypeName = "VarChar")]
        [StringLength(50, MinimumLength = 3)] //Since Min is Application Validation , It will not be Mapped
        //Only Max (50) Will be Mapped

        public string FName { get; set; }
        //Nullable Reference Type
        //string? is Mapped to NVarChar(Max) , Allow Null

        [Required]
        [Column("StudentLastName", TypeName = "VarChar")]
        [StringLength(50, MinimumLength = 3)] //Since that Min is an Application Validation , It will not be Mapped
        //Only Max (50) Will be Mapped
        public string LName { get; set; }
        //Nullable Reference Type
        //string? is Mapped to NVarChar(Max) , Allow Null

        [Required]
        [Column("StudentAddress", TypeName = "VarChar")]
        [StringLength(50, MinimumLength = 3)] //Since that Min is an Application Validation , It will not be Mapped
        //Only Max (50) Will be Mapped
        public string? Address { get; set; }
        //Nullable Reference Type
        //string? is Mapped to NVarChar(Max) , Allow Null

        [DeniedValues(40, 45, 50)] //Since that  DeniedValues is Application Validation , It will not be Mapped
        public int Age { get; set; }
        //Value Type
        //Not Allow Null
        //int is Mapped to int , Not Allow Null


        //[ForeignKey(nameof(StudentDepartment))]
        //Foreign Key 
        public int StuddntDepartmentID { get; set; }

        //Navigation Property : [One]
        [InverseProperty(nameof(Department.Students))]
        public Department? StudentDepartment { get; set; }
        #endregion
    }
}
