using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Zipcode
    {
        public string Code { get; set; }
        public int IdCity { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }

        public Zipcode(string code, int idCity, string street, string neighborhood)
        {
            Code= code;
            IdCity= idCity;
            Street= street;
            Neighborhood= neighborhood;


        }
    }
}
