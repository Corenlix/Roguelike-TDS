using UnityEngine;

namespace LevelGeneration
{
    
    [CreateAssetMenu(menuName = "LevelCreator", order = 1)]
    internal class LevelCreator : ScriptableObject
    {
        [SerializeField] private int levelSize = 64;
        [Range(0,10)][SerializeField] private int splitTimes = 4;
        
        [Range(0, 5000)][SerializeField] private int walkerRoomPart = 60;
        [Range(0, 100)][SerializeField] private int walkerRotate90Chance = 60;
        [Range(0, 100)][SerializeField] private int walkerRotate180Chance = 5;
        
        [Range(0, 5)][SerializeField] private float maxSizeDivide = 1.5f;
        [Range(10, 100)][SerializeField] private int minRoomSizePercent = 10;
        [Range(10, 100)][SerializeField] private int maxRoomSizePercent = 20;
        [Range(1,5)][SerializeField] private int corridorsThickness = 2;
        
        private CellType[,] _levelCells;
        
        public Level CreateLevel()
        {
            InitLevel();
            InitDungeonFragmentVariables();
            
            var rootDungeon = new DungeonFragment(new RectInt(0, 0, levelSize - 1, levelSize - 1));
            rootDungeon.SplitDungeon(splitTimes);
            rootDungeon.CreateCorridors();
            
            var corridors = rootDungeon.GetCorridors();
            foreach (var corridor in corridors)
            {
                FillRectToLevel(corridor, CellType.CorridorFloor);
            }
            
            var rooms = rootDungeon.GetRooms();
            foreach(var room in rooms) 
            {
                FillRectToLevel(room, CellType.RoomFloor);
            }

            foreach (var room in rooms)
            {
                LetWalkerToRoom(room);
            }

            return new Level(_levelCells, rooms, corridors);
        }
        private void InitDungeonFragmentVariables()
        {
            DungeonFragment.MaxSizeDivide = maxSizeDivide;
            DungeonFragment.MinRoomSizePercent = minRoomSizePercent;
            DungeonFragment.MaxRoomSizePercent = maxRoomSizePercent;
            DungeonFragment.CorridorsThickness = corridorsThickness;
        }
        private void InitLevel() 
        {
            _levelCells = new CellType[levelSize, levelSize];
            for(int i = 0; i < levelSize; i++) 
            {
                for(int j = 0; j < levelSize; j++) 
                {
                    _levelCells[i, j] = CellType.Wall;
                }
            }
        }
        
        private void LetWalkerToRoom(RectInt roomRect)
        {
            var walker = new Walker();
            int roomSquare = roomRect.size.x * roomRect.size.y;
            int stepsCount = (int) (roomSquare * walkerRoomPart / 100f);
            _levelCells = walker.Walk(_levelCells, new Vector2Int((int) roomRect.center.x, (int) roomRect.center.y), stepsCount,
                CellType.RoomFloor, walkerRotate90Chance, walkerRotate180Chance);
        }
        private void FillRectToLevel(RectInt roomRect, CellType cellsType) 
        {
            for(int i = roomRect.x; i <= roomRect.xMax; i++) 
            {
                for (int j = roomRect.y; j <= roomRect.yMax; j++)
                {
                    if (i < _levelCells.GetLength(0) && j < _levelCells.GetLength(1) && i > 0 && j > 0)
                        _levelCells[i, j] = cellsType;
                }
            }
        }
    }
    
    public enum CellType
    {
        Wall,
        RoomFloor,
        CorridorFloor,
    }
}
