using Domain.Model;
using Infrastructure.Configuration;
using Infrastructure.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class VeiculoService : IVeiculoRepository , IVeiculoService
    {

        private readonly IMongoCollection<Veiculo> _veiculo;
        private readonly VeiculoConfig _settings;
        public VeiculoService(IOptions<VeiculoConfig> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _veiculo = database.GetCollection<Veiculo>(_settings.VeiculoCollectionName);
        }
        public async Task<List<Veiculo>> GetAllAsync()
        {
            return await _veiculo.Find(c => true).ToListAsync();
        }
        public async Task<Veiculo> GetByIdAsync(string id)
        {
            return await _veiculo.Find<Veiculo>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Veiculo> CreateAsync(Veiculo veiculo)
        {
            await _veiculo.InsertOneAsync(veiculo);
            return veiculo;
        }
        public async Task UpdateAsync(string id, Veiculo veiculo)
        {
            await _veiculo.ReplaceOneAsync(c => c.Id == id, veiculo);
        }
        public async Task DeleteAsync(string id)
        {
            await _veiculo.DeleteOneAsync(c => c.Id == id);
        }
    }
}