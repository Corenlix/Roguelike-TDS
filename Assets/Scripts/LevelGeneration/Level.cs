namespace LevelGeneration
{ 
    class Level
    {
        public CellType[,] LevelCells { get; }
        public DungeonFragment RootDungeon { get; }

        public Level(CellType[,] levelCells, DungeonFragment rootDungeon)
        {
            LevelCells = levelCells;
            RootDungeon = rootDungeon;
        }
    }
}
