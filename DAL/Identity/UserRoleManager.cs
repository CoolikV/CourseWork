using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace DAL.Identity
{
    public class UserRoleManager : RoleManager<UserRole>
    {
        public UserRoleManager(RoleStore<UserRole> store) : base(store)
        {
        }
    }
}
