using System.ComponentModel.DataAnnotations;

namespace webapilab.Models
{
    public class MemberViewModel : MemberBaseViewModel
    {
        [Required]
        public int MemberId { get; set; }
    }
}