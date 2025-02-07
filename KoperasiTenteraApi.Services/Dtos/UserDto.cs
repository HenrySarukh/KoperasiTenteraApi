using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Application.Dtos
{
    public class UserDto
    {
        public required string Name { get; set; }
        public required string IC { get; set; }
        public required string MobileNumber { get; set; }
        public required string Email { get; set; }
    }
}
