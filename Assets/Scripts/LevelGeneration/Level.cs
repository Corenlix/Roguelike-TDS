using System.Collections.Generic;
using UnityEngine;

namespace LevelGeneration
{ 
    public class Level
    {
        public CellType[,] LevelCells { get; }
        public List<RectInt> Rooms { get; }
        public List<RectInt> Corridors { get; }

        public Level(CellType[,] levelCells, List<RectInt> rooms, List<RectInt> corridors)
        {
            LevelCells = levelCells;
            Rooms = rooms;
            Corridors = corridors;
        }
    }
}
