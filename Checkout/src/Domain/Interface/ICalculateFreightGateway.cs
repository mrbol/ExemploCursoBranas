using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.DTO;


namespace Domain.Interface
{
    public interface ICalculateFreightGateway
    {
        Task<FreightGatewayResponse> Calculate(FreightGatewaySend freightGatewaySend);
    }
}
