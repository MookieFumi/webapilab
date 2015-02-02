using System.Collections.Generic;
using System.Threading.Tasks;
using webapilab.entities;

namespace webapilab.services
{
    public interface IProvincesService
    {
        Task<Province> Get(int provinceId);
        Task<IEnumerable<Province>> GetAll();
    }
}