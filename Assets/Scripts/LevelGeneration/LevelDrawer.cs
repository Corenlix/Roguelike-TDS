using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelGeneration
{
    public class LevelDrawer : MonoBehaviour
    {
        [SerializeField] private Tilemap floorsTilemap, wallsTilemap;
        [SerializeField] private RuleTile floorTale, wallTile;
        [SerializeField] private int offset;
        
        public void DrawLevel(CellType[,] level)
        {
            level = InitLevel(level);
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int j = 0; j < level.GetLength(0); j++)
                {
                    var currentCell = level[i, j];
                    GetTilemapFromCellType(currentCell).SetTile(new Vector3Int(i, j, 0), GetTileFromCellType(currentCell));
                }    
            }
        }

        private CellType[,] InitLevel(CellType[,] level)
        {
            floorsTilemap.ClearAllTiles();
            wallsTilemap.ClearAllTiles();
            for (int i = -offset; i < level.GetLength(0) + offset; i++)
            {
                for (int j = -offset; j < level.GetLength(1) + offset; j++)
                {
                    if(i < 0 || i >= level.GetLength(0) || j < 0 || j >= level.GetLongLength(1))
                        GetTilemapFromCellType(CellType.Wall).SetTile(new Vector3Int(i, j, 0), GetTileFromCellType(CellType.Wall));
                    else
                        GetTilemapFromCellType(CellType.RoomFloor).SetTile(new Vector3Int(i, j, 0), GetTileFromCellType(CellType.CorridorFloor));
                }
            }

            return level;
        }
        private RuleTile GetTileFromCellType(CellType cellType)
        {
            return cellType switch
            {
                CellType.Wall => wallTile,
                _ => floorTale,
            };
        }

        private Tilemap GetTilemapFromCellType(CellType cellType)
        {
            return cellType switch
            {
                CellType.Wall => wallsTilemap,
                _ => floorsTilemap,
            };
        }
        
    }
}
