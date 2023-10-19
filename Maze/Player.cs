using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Maze
{
    internal class Player
    {
        private const int speed = 8;
        //private const int padding = 0;

        private Panel pnl;

        private Point startPos = new Point(18, 237);
        public Player(Panel pnl) => this.pnl = pnl;

        public Panel Square { get => this.pnl; set => this.pnl = value; }

        public Point Location { get => pnl.Location; set => pnl.Location = value; }

        public void ResetPos()
        {
            this.pnl.Location = startPos;
        }

        internal bool Move(int[] d, bool wait=false)
        {
            int shiftedX = pnl.Left + speed * d[0];
            int shiftedY = pnl.Top + speed * d[1];
            Point shiftedPos = new Point(shiftedX, shiftedY);
            Rectangle playerBounds = new Rectangle(shiftedPos, this.pnl.Size);


            if (!Wall.IsAnyColliding(playerBounds))
            {
                if (!wait)
                {
                    this.pnl.Left = shiftedX;
                    this.pnl.Top = shiftedY;

                    if (Goal.IsColliding(playerBounds))
                        Finish();
                }
                return true;
            }

            return false;
        }
    
        private void Finish()
        {

            //MessageBox.Show("You Win!!");
            ResetPos();
            Goal.IsReached = true;

        }
    }
}
