using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interface;


namespace Infra.Persistence
{
    public class CityRepositoryDatabase : ICityRepository
    {
        private readonly IDapperAdapter _dapperAdapter;
        public CityRepositoryDatabase(IDapperAdapter dapperAdapter)
        {
            _dapperAdapter = dapperAdapter;
        }

        public async Task<City> GetByZipCode(string code)
        {
            var cityModel = await _dapperAdapter.QuerySingle<CityModel>($"select c.id_city, c.name, c.latitude, c.longitude from ccca_freight.zipcode z inner join ccca_freight.city c on z.id_city = c.id_city where z.code = '{code}'");
            return new City(cityModel.id_city, cityModel.name, cityModel.latitude, cityModel.longitude);
        }
    }
}
