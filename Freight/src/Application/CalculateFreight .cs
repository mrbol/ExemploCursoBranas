using Domain.DTO;
using Domain.Entity;
using Domain.Interface;

namespace Application
{
    public class CalculateFreight: ICalculateFreight
    {
        private readonly ICityRepository _cityRepository;

        public CalculateFreight(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<CityResponse> Execute(CitySend citySend)
        {
            var from = await _cityRepository.GetByZipCode(citySend.From);
            var to = await _cityRepository.GetByZipCode(citySend.To);
            var distance = DistanceCalculator.Calculate(from.Coordinate, to.Coordinate);
            double total = 0;
            foreach (OrderItemSend orderItem in citySend.OrderItems)
            {
                total += FreightCalculator.Calculate(distance, orderItem.Volume, orderItem.Density) * orderItem.Quantity;
            }
            total = Math.Round(total * 100) / 100;
            return new CityResponse { Total = total };
        }
    }
}