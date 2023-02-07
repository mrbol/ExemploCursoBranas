using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ICalculateFreight
    {
        Task<CityResponse> Execute(CitySend citySend);
    }
}
