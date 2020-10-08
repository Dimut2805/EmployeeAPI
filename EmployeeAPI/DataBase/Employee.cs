using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.DataBase
{
    [Table("people")]
    public class Employee
    {     
        [Key]
        [Column("id")]
        public int id;
        [Column("name")]
        public string name { get; set; }
        [Column("surname")]
        public string surname { get; set; }
        [Column("phone")]
        public string phone { get; set; }
        [Column("companyid")]
        public int companyId { get; set; }
        public Passport passport { get; set; }
    }
}
