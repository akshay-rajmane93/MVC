using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Movieship.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please fill name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSuscribed { get; set; }

        [Display(Name="DOB")]
        [BirthdateCustomValidation]
        public DateTime? Birthdate { get; set; }
        [Display(Name="Membership Type")]
        public int MembId { get; set; }
        [ForeignKey("MembId")]
        public MemberShip MemberShip { get; set; } //navigation property
        


    }
}