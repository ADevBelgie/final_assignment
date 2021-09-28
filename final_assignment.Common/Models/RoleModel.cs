using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.Common.Models
{
    public class RoleModel: IdentityRole
    {
        // Costumizable IdentityRole
        public string Description { get; set; }
    }
}
