using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Стрельба_по_мишеням
{
    class ApplicationContex : DbContext
    {
        private static ApplicationContex _context;
        public DbSet<Gamer> Gamers { get; set; }

        public ApplicationContex() : base("DefaultConnection") { }

        public static ApplicationContex GetContext()
        {
            if (_context == null)
                _context = new ApplicationContex();

            return _context;
        }
    }
}
