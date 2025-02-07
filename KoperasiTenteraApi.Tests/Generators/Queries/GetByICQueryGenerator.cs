using Bogus;
using KoperasiTenteraApi.Application.Authentication.Queries.GetByIC;
using KoperasiTenteraApi.Domain.Shared;
using KoperasiTenteraApi.Tests.Generators.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Tests.Generators.Queries
{
    public class GetByICQueryGenerator : Faker<GetByICQuery>
    {
        public GetByICQueryGenerator()
        {
            RuleFor(x => x.IC, f => f.Random.Number(100000, 999999).ToString().PadLeft(Constants.ICLength, '0'));
        }

        public GetByICQueryGenerator WithInvalidData()
        {
            RuleFor(x => x.IC, f => f.Random.Number(100000, 999999).ToString().PadLeft(Constants.ICLength + 1, '0'));

            return this;
        }
    }
}
