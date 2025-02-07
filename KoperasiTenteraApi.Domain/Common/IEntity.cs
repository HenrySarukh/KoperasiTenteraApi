using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Domain.Common
{
    public interface IEntity<TId> where TId : struct
    {
        TId Id { get; }
    }
}
