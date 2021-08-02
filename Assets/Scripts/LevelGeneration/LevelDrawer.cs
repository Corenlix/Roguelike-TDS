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
            DrawLevelBackground(level.GetLength(0), level.GetLength(1));
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int j = 0; j < level.GetLength(0); j++)
                {
                    var currentCell = level[i, j];
                    var tile = GetTileFromCellType(currentCell);
                    var palette = GetTilemapFromCellType(currentCell);
                    palette.SetTile(new Vector3Int(i, j, 0), tile);
                }    
            }
        }

        private void DrawLevelBackground(int levelWidth, int levelHeight)
        {
            floorsTilemap.ClearAllTiles();
            wallsTilemap.ClearAllTiles();
            for (int i = -offset; i < levelWidth + offset; i++)
            {
                for (int j = -offset; j < levelHeight + offset; j++)
                {
                    if(i < 0 || i >= levelWidth || j < 0 || j >= levelHeight)
                        GetTilemapFromCellType(CellType.Wall).SetTile(new Vector3Int(i, j, 0), GetTileFromCellType(CellType.Wall));
                    else
                        GetTilemapFromCellType(CellType.RoomFloor).SetTile(new Vector3Int(i, j, 0), GetTileFromCellType(CellType.CorridorFloor));
                }
            }
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
