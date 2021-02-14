using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movieship.Models;
using System.ComponentModel.DataAnnotations;

namespace Movieship.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSuscribed { get; set; }

        //[BirthdateCustomValidation]
        public DateTime? Birthdate { get; set; }
      
        public int MembId { get; set; }
    
        public MemberShipDto MemberShip { get; set; }
       
    }
}