using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthGenerator
{
    class Cell
    {
        public int x;
        public int y;
        public bool isChecked;
        public bool leftWall;
        public bool rightWall;
        public bool upWall;
        public bool downWall;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            isChecked = false;
            leftWall = true;
            rightWall = true;
            upWall = true;
            downWall = true;
        }

        public Cell(Cell cell)
        {
            x = cell.x;
            y = cell.y;
            isChecked = cell.isChecked;
            leftWall = cell.leftWall;
            rightWall = cell.rightWall;
            upWall = cell.upWall;
            downWall = cell.downWall;
        }
    }
}
