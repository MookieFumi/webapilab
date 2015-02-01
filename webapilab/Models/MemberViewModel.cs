using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webapilab.Models
{
    public class MemberViewModel : MemberBaseViewModel
    {
        [Required]
        public int MemberId { get; set; }
    }

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