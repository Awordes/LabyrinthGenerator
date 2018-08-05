using System;
using System.Collections;

namespace LabyrinthGenerator
{
    class LabGen
    {
        Random rnd;
        public Cell[][] labyrinth;

        public LabGen(int width, int height)
        {
            rnd = new Random();
            labyrinth = new Cell[width][];
            for (int i = 0; i < labyrinth.Length; i++)
            {
                labyrinth[i] = new Cell[height];
                for (int j = 0; j < labyrinth[i].Length; j++)
                    labyrinth[i][j] = new Cell(i, j);
            }
        }

        public Cell[][] getLabyrinth()
        {
            return labyrinth;
        }

        public void Generate()
        {
            int centerX = rnd.Next(labyrinth.Length);
            int centerY = rnd.Next(labyrinth[0].Length);
            Worm(centerX, centerY);
        }

        public void Generate(int centerX, int centerY)
        {
            Worm(centerX, centerY);
        }

        void Worm(int x, int y)
        {
            int startX = x;
            int startY = y;

            Stack stackX = new Stack();
            Stack stackY = new Stack();
            
            while (true)
            {
                labyrinth[x][y].isChecked = true;

                ArrayList neighbors = FindNeighbors(x, y);

                if (neighbors.Count == 0)
                {
                    if (x == startX && y == startY)
                        break;
                    else
                    {
                        x = (int)stackX.Pop();
                        y = (int)stackY.Pop();
                        continue;
                    }
                }

                stackX.Push(x);
                stackY.Push(y);

                switch (rnd.Next(neighbors.Count))
                {
                    case 0:
                        WhatWallEat(x, y, ((Cell)neighbors[0]).x, ((Cell)neighbors[0]).y);
                        x = ((Cell)neighbors[0]).x;
                        y = ((Cell)neighbors[0]).y;
                        continue;
                    case 1:
                        WhatWallEat(x, y, ((Cell)neighbors[1]).x, ((Cell)neighbors[1]).y);
                        x = ((Cell)neighbors[1]).x;
                        y = ((Cell)neighbors[1]).y;
                        continue;
                    case 2:
                        WhatWallEat(x, y, ((Cell)neighbors[2]).x, ((Cell)neighbors[2]).y);
                        x = ((Cell)neighbors[2]).x;
                        y = ((Cell)neighbors[2]).y;
                        continue;
                    case 3:
                        WhatWallEat(x, y, ((Cell)neighbors[3]).x, ((Cell)neighbors[3]).y);
                        x = ((Cell)neighbors[3]).x;
                        y = ((Cell)neighbors[3]).y;
                        continue;
                }
            }
        }

        ArrayList FindNeighbors(int x, int y)
        {
            ArrayList neighbors = new ArrayList();

            if (x > 0 && !labyrinth[x - 1][y].isChecked)
                neighbors.Add(new Cell(labyrinth[x - 1][y]));

            if (x + 1 < labyrinth.Length && !labyrinth[x + 1][y].isChecked)
                neighbors.Add(new Cell(labyrinth[x + 1][y]));

            if (y > 0 && !labyrinth[x][y - 1].isChecked)
                neighbors.Add(new Cell(labyrinth[x][y - 1]));

            if (y + 1 < labyrinth[0].Length && !labyrinth[x][y + 1].isChecked)
                neighbors.Add(new Cell(labyrinth[x][y + 1]));

            return neighbors;
        }

        void WhatWallEat(int x1, int y1, int x2, int y2)
        {
            if (x1 - x2 > 0)
            {
                labyrinth[x1][y1].leftWall = false;
                labyrinth[x2][y2].rightWall = false;
            }
            else if (x1 - x2 < 0)
            {
                labyrinth[x1][y1].rightWall = false;
                labyrinth[x2][y2].leftWall = false;
            }
            else if (y1 - y2 > 0)
            {
                labyrinth[x1][y1].upWall = false;
                labyrinth[x2][y2].downWall = false;
            }
            else if (y1 - y2 < 0)
            {
                labyrinth[x1][y1].downWall = false;
                labyrinth[x2][y2].upWall = false;
            }
        }
    }
}
