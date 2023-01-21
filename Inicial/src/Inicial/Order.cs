using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicial
{
    public class Order
    {
        private Cpf _cpf;

        public Order(string cpf)
        {
            _cpf = new Cpf(cpf);
        }

        public int GetTotal()
        {
            return 0;
        }

    }
}
