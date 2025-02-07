using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Application.Authentication.Queries.GetByIC
{
    public class GetByICQuery : IRequest<ErrorOr<bool>>
    {
        public required string IC { get; set; }
    }
}
