using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Dimension
    {
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Weight { get; set; }

        public Dimension(decimal width = 0, decimal height = 0, decimal length = 0, decimal weight = 0)
        {
            if (width < 0 || height < 0 || length < 0 || weight < 0)
            {
                throw new AppException("Invalid dimensions");
            }
            Width = width;
            Height = height;
            Length = length;
            Weight = weight;
        }

        public decimal GetVolume()
        {
            return Width / 100 * Height / 100 * Length / 100;
        }

        public decimal GetDensity()
        {
            if (GetVolume() == 0) return 0;
            return Weight / GetVolume();
        }
    }
}
