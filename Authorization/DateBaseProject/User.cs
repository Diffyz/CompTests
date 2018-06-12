using System.ComponentModel.DataAnnotations;

namespace DateBaseProject
{
    public class User
    {
        [Key]
        public string login { get; set; }
        public string password { get; set; }
    }
}
