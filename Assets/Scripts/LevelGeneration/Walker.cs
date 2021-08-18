using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace LevelGeneration
{
    class Walker
    {
        private int _rotate90Chance = 60;
        private int _rotate180Chance = 5;
        private int _madeErrorSteps = 0;
        
        private CellType _cellsType;
        private Direction _currentDirection;
        private Vector2Int _position;
        private CellType[,] _level;
        

        public CellType[,] Walk(CellType[,] level, Vector2Int position, int steps, CellType cellsType, int rotate90Chance, int rotate180Chance) 
        {
            _level = level;
            _position = position;
            _rotate90Chance = rotate90Chance;
            _rotate180Chance = rotate180Chance;
            _cellsType = cellsType;
            
            SetRandomDirection();
            while (steps > 0 && _madeErrorSteps < 3000)
            {
                Move();
                if (ClearCell())
                    steps -= 1;
            }

            return level;
        }
        
        void Move()
        {
            _position += GetMoveDelta();
            if (Random.Range(0, 100) < _rotate90Chance)
                Rotate90();
            else if (Random.Range(0, 100) < _rotate180Chance)
                Rotate180();

            if (_position.x >= _level.GetLength(0) || _position.y >= _level.GetLength(1) || _position.x < 0 || _position.y < 0)
            {
                _position.x = Mathf.Clamp(_position.x, 0, _level.GetLength(0) -1);
                _position.y = Mathf.Clamp(_position.y, 0, _level.GetLength(1) - 1);
                Rotate90();
            }
        }
        bool ClearCell()
        {
            _madeErrorSteps++;
            if (_level[_position.x, _position.y] != (int)CellType.Wall) return false;
            _level[_position.x, _position.y] = _cellsType;
            _madeErrorSteps = 0;
            return true;
        }

        private void Rotate90() 
        {
            var leftOrRight = Random.Range(0, 100);
            if (leftOrRight > 50)
                _currentDirection = (Direction)(((int)_currentDirection + 1) % 4);
            else
                _currentDirection = (Direction)(((int)_currentDirection - 1) % 4);
        }
        private void Rotate180() 
        {
            _currentDirection = (Direction)(((int)_currentDirection + 2) % 4);
        }

        private Vector2Int GetMoveDelta()
        {
            return _currentDirection switch
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
            _currentDirection = (Direction)Random.Range(0, 3);
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
