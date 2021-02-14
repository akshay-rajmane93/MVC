using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movieship.DTOs
{
    public class RentanDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}