using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : ControllerBase
    {
         private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        
    }
}