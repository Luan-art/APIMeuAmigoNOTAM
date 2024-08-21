using APIMeuAmigoNOTAM.Domain.Entities.v1;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamByIsExperid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Contracts.v1
{
    public interface INotamRepository : IRepository<Notam, string>
    {
    }
}
