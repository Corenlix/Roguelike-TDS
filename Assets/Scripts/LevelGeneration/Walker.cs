using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace LevelGeneration
{
    class Walker
    {
        private int rotate90Chance = 60;
        private int rotate180Chance = 5;
        private int madeErrorSteps = 0;
        
        private CellType cellsType;
        private Direction currentDirection;
        private Vector2Int position;
        private CellType[,] level;
        

        public CellType[,] Walk(CellType[,] level, Vector2Int position, int steps, CellType cellsType, int rotate90Chance, int rotate180Chance) 
        {
            this.level = level;
            this.position = position;
            this.rotate90Chance = rotate90Chance;
            this.rotate180Chance = rotate180Chance;
            this.cellsType = cellsType;
            
            SetRandomDirection();
            while (steps > 0 && madeErrorSteps < 3000)
            {
                Move();
                if (ClearCell())
                    steps -= 1;
            }

            return level;
        }
        
        void Move()
        {
            position += GetMoveDelta();
            if (Random.Range(0, 100) < rotate90Chance)
                Rotate90();
            else if (Random.Range(0, 100) < rotate180Chance)
                Rotate180();

            if (position.x >= level.GetLength(0) || position.y >= level.GetLength(1) || position.x < 0 || position.y < 0)
            {
                position.x = Mathf.Clamp(position.x, 0, level.GetLength(0) -1);
                position.y = Mathf.Clamp(position.y, 0, level.GetLength(1) - 1);
                Rotate90();
            }
        }
        bool ClearCell()
        {
            madeErrorSteps++;
            if (level[position.x, position.y] != (int)CellType.Wall) return false;
            level[position.x, position.y] = cellsType;
            madeErrorSteps = 0;
            return true;
        }

        private void Rotate90() 
        {
            var leftOrRight = Random.Range(0, 100);
            if (leftOrRight > 50)
                currentDirection = (Direction)(((int)currentDirection + 1) % 4);
            else
                currentDirection = (Direction)(((int)currentDirection - 1) % 4);
        }
        private void Rotate180() 
        {
            currentDirection = (Direction)(((int)currentDirection + 2) % 4);
        }

        private Vector2Int GetMoveDelta()
        {
            return currentDirection switch
            {
                Direction.Up => new Vector2Int(0, 1),
                Direction.Down => new Vector2Int(0, -1),
                Direction.Left => new Vector2Int(-1, 0),
                Direction.Right => new Vector2Int(1, 0),
                _ => new Vector2Int(0, 0)
            };
        }
        private void SetRandomDirection() 
        {
            currentDirection = (Direction)Random.Range(0, 3);
        }
        
        private enum Direction 
        {
            Up,
            Right,
            Down,
            Left
        }
    }
}
