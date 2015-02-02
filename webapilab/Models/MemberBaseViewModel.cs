using System.ComponentModel.DataAnnotations;

namespace webapilab.Models
{
    public class MemberBaseViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Departament { get; set; }
    }
}