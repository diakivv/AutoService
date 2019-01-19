using System;
using System.Collections.Generic;
using System.Text;

namespace AutoService.DAL.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public List<Car> Cars { get; set; }
    }
}
