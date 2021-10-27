using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IVeiculoRepository 
    {
        Task<List<Veiculo>> GetAllAsync();
        Task<Veiculo> GetByIdAsync(string id);
        Task<Veiculo> CreateAsync(Veiculo veiculo);
        Task UpdateAsync(string id, Veiculo veiculo);
        Task DeleteAsync(string id);
    }
}
