    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.DeleteNotamByID
{
    public class DeleteNotamByIdCommandResponse
    {
        public string Id { get; set; }
        public bool Success { get; set; }
    }
}
