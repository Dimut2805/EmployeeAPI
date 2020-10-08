using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EmployeeAPI.DataBase
{
    [Table("passport")]
    public class Passport
    {    

        [Column("type")]
        public string type { get; set; }
        [Column("number")]
        public string number { get; set; }
        [ForeignKey("employee")]
        public int id { get; set; }
        public Employee employee { get; set; }
    }
}
