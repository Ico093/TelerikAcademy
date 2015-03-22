using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models;

namespace Tetris.Data
{
    public class TetrisContext: DbContext
    {
        public TetrisContext()
            : base("TetrisDb")
        { }

        public DbSet<Player> Players { get; set; }
    }
}
