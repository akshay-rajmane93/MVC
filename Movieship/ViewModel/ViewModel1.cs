using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movieship.Models;

namespace Movieship.ViewModel
{
    // veiw model we use to render in only veiw
    // if we want to display two models data in single veiw then we use veiwmodel
    // veiwmodel from this name we get that it is only related with the view to display data 
    //or  for taking input from view. 
    public class ViewModel1
    {
        public IEnumerable<MemberShip>  MemberShip { get; set; }

        public Customer Customer { get; set; }
    }
}