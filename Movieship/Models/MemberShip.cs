using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movieship.Models
{
    public class MemberShip
    {
        public int Id { get; set; }
        public int MonthDuration { get; set; }
        public int SignupFee { get; set; }
        public string MenberShipType { get; set; }
    }
}