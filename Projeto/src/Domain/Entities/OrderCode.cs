using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderCode
    {
        public string Value { get; set; }
        public OrderCode(DateTime date,int sequence)
        {
            Value = GnereateCode(date, sequence);
        }
        private string GnereateCode(DateTime date, int sequence) {
            string code = Convert.ToString(sequence);
            int year = date.Year;
            return $"{year}{code.PadLeft(8, '0')}";          
        }
    }
}
