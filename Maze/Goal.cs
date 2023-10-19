using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    internal static class Goal
    {
        private static Rectangle goalBounds;

        private static bool isReached = false;
        
        public static Rectangle Bounds { get => goalBounds; set => goalBounds = value; }

        public static bool IsReached { get => isReached; set => isReached = value; }

        public static bool IsColliding(Rectangle target)
        {
            if (target.IntersectsWith(goalBounds))
                return true;
            return false;
        }



    }
}
