using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSUHvZ.Models;

namespace DSUHvZ.Controllers
{
    public class AppUserController : Controller
    {
        private ApplicationDbContext _context;

        public AppUserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
    }
}