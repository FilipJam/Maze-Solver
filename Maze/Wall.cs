using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Maze
{
    internal class Wall
    {
        private static List<Wall> walls = new List<Wall>();
        private Panel pnl;
        public Wall(Panel pnl) => this.pnl = pnl;
        public Rectangle Bounds { get => this.pnl.Bounds; }

        public static void Add(Wall w) => walls.Add(w);

        public static bool IsAnyColliding(Rectangle target)
        {
            foreach (var wall in walls)
                if (target.IntersectsWith(wall.Bounds))
                    return true;
            return false;
        }
    }
}
