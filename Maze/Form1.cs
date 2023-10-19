using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Maze
{
    public partial class Form1 : Form
    {
        private Player player;
        private Player clone;
        private List<int[]> instructions;
        //private int[] inputDirection;
        private int[] nextDirection;
        private int pathIndex = 0;
        //private bool allowClick = true;
        //private bool isMoving = false;
        public Form1()
        {
            InitializeComponent();
            btnStop.SendToBack();
            player = new Player(pnlPlayer);

            Panel pnlClone = new Panel();
            Controls.Add(pnlClone);
            pnlClone.BringToFront();

            pnlClone.Size = player.Square.Size;
            pnlClone.Location = player.Location;

            pnlClone.BackColor = Color.Orange;

            pnlClone.Visible = false;
            //picMaze.Controls.Add(pnlClone);
            

            List<int> ints= new List<int>() { 2,4,5,6,7,8,9};

            clone = new Player(pnlClone);

            Goal.Bounds = pnlGoal.Bounds;
            pnlGoal.BringToFront();
            pnlPlayer.BringToFront();
            Panel[] panelList = { wall1, wall2, wall3, wall4, wall5, wall6, wall7, wall8, wall9, wall10, 
                                  wall11, wall12, wall13, wall14, wall15, wall16, wall17, wall18, wall19, wall20
                                , wall21, wall22, wall23, wall24, wall25, wall26, wall27, wall28, wall29, wall30
                                , wall31, wall32, wall33, wall34, wall35, wall36, wall37, wall38, wall39, wall40
                                , wall41, wall42, wall43, wall44, wall45, wall46, wall47, wall48, wall49, wall50
                                , wall51, wall52, wall53, wall54, wall55, wall56, wall57, wall58, wall59, wall60
                                , wall61, wall62, wall63, wall64, wall65, wall66, wall67, wall68, wall69, wall70
                                , wall71, wall72, wall73, wall74, wall75, wall76, wall77, wall78, wall79, wall80
                                , wall81, wall82, wall83, wall84, wall85, wall86, wall87, wall88, wall89, wall90
                                , wall91, wall92, wall93, wall94, wall95, wall96, wall97, wall98, wall99, wall100
                                , wall101, wall102, wall103, wall104, wall105, wall106, wall107, wall108, wall109, wall110
                                , wall111, wall112, wall113, wall114, wall115, wall116, wall117, wall118, wall119, wall120
                                , wall121, wall122, wall123, wall124, wall125, wall126, wall127, wall128, wall129, wall130
                                , wall131, wall132, wall133, wall134, wall135, wall136, wall137, wall138, wall139, wall140
                                , wall141, wall142, wall143, wall144, wall145, wall146, wall147, wall148, wall149, wall150
                                , wall151, wall152, wall153, wall154, wall155, wall156, wall157, wall158, wall159, wall160
                                , wall161, wall162, wall163, wall164, wall165, wall166, wall167, wall168, wall169, wall170
                                , wall171, wall172, wall173, wall174, wall175, wall176, wall177, wall178, wall179, wall180
                                , wall181, wall182, wall183, wall184, wall185, wall186, wall187, wall188, wall189, wall190
                                , wall191, wall192, wall193, wall194, wall195, wall196, wall197, wall198, wall199, wall200
                                , wall201, wall202, wall203, wall204, wall205, wall206, wall207, wall208, wall209, wall210
                                , wall211, wall212, wall213, wall214, wall215, wall216, wall217, wall218, wall219, wall220
                                , wall221, wall222, wall223, wall224, wall225, wall226, wall227, wall228, wall229, wall230
                                , wall231, wall232, wall233, wall234, wall235, wall236, wall237, wall238, wall239, wall240
                                , wall241, wall242, wall243, wall244, wall245, wall246, wall247, wall248, wall249, wall250
                                , wall251, wall252, wall253, wall254, wall255, wall256, wall257, wall258, wall259, wall260
                                , wall261, wall262, wall263, wall264, wall265, wall266, wall267, wall268, wall269, wall270
                                , wall271, wall272, wall273, wall274, wall275, wall276, wall277, wall278, wall279, wall280
                                , wall281, wall282, wall283, wall284, wall285, wall286, wall287, wall288, wall289, wall290
                                , wall291, wall292, wall293, wall294, wall295, wall296, wall297, wall298, wall299 };
            
            foreach (var panel in panelList)
                ConvertToWall(panel);

           
            /*string[] d = { "Left", "Right", "Up", "Down" };

            foreach (string s in d)
                GetPossibleDirections(NumericDirection(s));*/
        }
        private void ConvertToWall(Panel pnl)
        {
            Wall w = new Wall(pnl);
            Wall.Add(w);
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /*int[] direction = NumericDirection(e.KeyData.ToString());
            if (!isMoving && direction != null && !tmrAI.Enabled)
            {
                inputDirection = direction;
                isMoving = true;
                tmrPlayerMove.Start();
            }*/
            
        }
        private void tmrPlayerMove_Tick(object sender, EventArgs e)
        {
            /*player.Move(inputDirection);


            List<int[]> directions = GetPossibleDirections(inputDirection, player);
            if (directions.Count != 1 || (directions[0][0] != inputDirection[0] || directions[0][1] != inputDirection[1]))
            {
                isMoving = false;
                tmrPlayerMove.Stop();
            }*/
                
        }

        /*private void UserInputMove(string input)
        {
            int[] d = NumericDirection(input);
            player.Move(d);
            lblPosition.Text = $"Player Position: ( {player.Square.Left} , {player.Square.Top} )";
        }
        private int[] NumericDirection(string directionString)
        {
            int[] direction = { 0, 0 };
            switch (directionString)
            {
                case "Up": direction[1] = -1; break;
                case "Down": direction[1] = 1; break;
                case "Left": direction[0] = -1; break;
                case "Right": direction[0] = 1; break;
                default:
                    return null;
            }
            return direction;
        }*/

        private List<int[]> BacktrackList(List<int[]> list)
        {
            int lastIndex = list.Count - 1;
            //var d = list[lastIndex];
            list.RemoveAt(lastIndex);
            /*string s = $"({d[0]},{d[1]}) ";
            MessageBox.Show("REMOVING " + s);*/
            return list;
        }

        private List<int[]> PathFinder(int[] currentDirection = null, List<int[]> instructions = null)
        {
            if (currentDirection == null)
                currentDirection = new int[] { 1, 0 };

            if (instructions == null)
                instructions = new List<int[]> { currentDirection };

            List<int[]> directions;
            do
            {
                clone.Move(currentDirection);

                /*string s = "Instructions: ";
                foreach(var d in instructions)
                    s += $"({d[0]},{d[1]}) ";
                MessageBox.Show(s);*/

                if (Goal.IsReached)
                {
                    //MessageBox.Show(instructions.Count.ToString());
                    return instructions;
                }

                directions = GetPossibleDirections(currentDirection, clone);
                if (directions.Count == 1 && (directions[0][0] != currentDirection[0] || directions[0][1] != currentDirection[1]))
                    currentDirection = directions[0];

            } while (directions.Count == 1);

            if (directions.Count == 0)
                return BacktrackList(instructions);
                
            
            foreach(var d in directions)
            {
                
                
                instructions.Add(d);
                /*string s = $"({d[0]},{d[1]}) ";
                MessageBox.Show("ADDING " + s);*/
                Point savedPos = clone.Location;
                instructions = PathFinder(d, instructions);
                clone.Location = savedPos;

                if (Goal.IsReached)
                {
                    //MessageBox.Show(instructions.Count.ToString());
                    return instructions;
                }
                    
            }

            return BacktrackList(instructions);
        }

        private int[] OppositeDirection(int[] d)
        {
            int[] oppositeDir = new int[2];
            for (int i = 0; i < 2; i++)
                oppositeDir[i] = d[i] * -1;
            
            return oppositeDir;
        }

        private List<int[]> GetPossibleDirections(int[] currentDirection, Player square)
        {
            List<int[]> availableDirections = new List<int[]>()
            {
                new int[] { 1, 0 },
                new int[] { -1, 0 },
                new int[] { 0, 1 },
                new int[] { 0, -1 }
            };

            int[] oppositeDir = OppositeDirection(currentDirection);
            int removeIndex = -1;
            for(int i = 0; i < 4; i++)
            {
                if (availableDirections[i][0] == oppositeDir[0] && availableDirections[i][1] == oppositeDir[1])
                {
                    removeIndex= i;
                    break;
                }
            }

            availableDirections.RemoveAt(removeIndex);

            List<int[]> possibleDirections = new List<int[]>();

            foreach (var d in availableDirections)
                if (square.Move(d, wait: true))
                    possibleDirections.Add(d);


            return possibleDirections;
        }

        private void SolveMaze()
        {
            clone.Square.Visible = chkPath.Checked;
            instructions = new List<int[]>();
            instructions = PathFinder();
            //MessageBox.Show(instructions.Count.ToString() + "   sdfsdf");
            clone.Location = player.Location;
            clone.Square.Visible = false;
            /*MessageBox.Show(instructions.Count.ToString());
            string s = "Instructions: ";
            foreach (var d in instructions)
            {
                string coord = $"({d[0]},{d[1]}), ";
                s += $"({d[0]},{d[1]}), ";

            }
            MessageBox.Show(s);*/

            //MessageBox.Show(s);
            /*int[] d = instructions[instructions.Count - 1];
            string s = $"({d[0]},{d[1]}), ";
            MessageBox.Show(s);*/

            //allowClick = true;
            pathIndex = 0;
            Goal.IsReached = false;

            nextDirection = instructions[0];
            tmrAI.Start();
            
            
        }

        

        private void picMaze_Click(object sender, EventArgs e)
        {
            if (!btnStart.Visible) return;

            int midPoint = pnlGoal.Width / 2;
            int xPos = Cursor.Position.X - this.Left - 8 - midPoint;
            int yPos = Cursor.Position.Y - this.Top - 32 - midPoint;

            pnlGoal.Location = new Point(xPos, yPos);
            //pnlGoal.BringToFront();
            Goal.Bounds = pnlGoal.Bounds;

            //allowClick = false;

        }

        private void Reset()
        {
            Goal.IsReached = false;
            //allowClick = true;
            btnStart.Visible = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            pathIndex = 0;
            tmrAI.Stop();
            player.ResetPos();
        }

        private bool RouteFinished()
        {
            if (Goal.IsReached)
            {
                Reset();
                return true;
            }
            return false;
        }

        /*private Node ConvertToLinkedList(List<int[]> list)
        {
            Node root = new Node(list[0]);
            Node cur = root;

            for (int i = 1; i < list.Count; i++)
            {
                cur.Next = new Node(list[i]);
                cur = cur.Next;
            }

            return root;
        }*/



        private void tmrAI_Tick(object sender, EventArgs e)
        {
            if (!btnStop.Enabled)
            {
                btnStop.Enabled = true;
                btnStart.Visible = false;
            }
            player.Move(nextDirection);

            if (RouteFinished())
                return;
            
            // always at least one direction
            List<int[]> directions = GetPossibleDirections(nextDirection, player);

            if (directions.Count > 1) // Intersection Condition
                nextDirection = instructions[++pathIndex];
            else if (directions[0][0] != nextDirection[0] || directions[0][1] != nextDirection[1]) // Path Turning Condition
                nextDirection = directions[0];

        }

        

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            
            SolveMaze();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Reset();
        }



        /*private void chkPath_KeyDown(object sender, KeyEventArgs e)
        {
            int[] direction = NumericDirection(e.KeyData.ToString());
            if (!isMoving && direction != null && !tmrAI.Enabled)
            {
                inputDirection = direction;
                isMoving = true;
                tmrPlayerMove.Start();
            }
        }*/
    }
}
