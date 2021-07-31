using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelGeneration
{
    class EntitySpawner
    {
        private Level level;
        private Transform player;

        public EntitySpawner(Level level, Transform playerTransform)
        {
            this.level = level;
            this.player = playerTransform;
        }

        public void MovePlayer()
        {
            var rooms = level.RootDungeon.GetRooms();
            player.transform.position = rooms[Random.Range(0, rooms.Count - 1)].Rect.center;

            
            var pathfinder = new Pathfinder(level.LevelCells);
            var firstPoint = new Vector2Int((int) player.transform.position.x, (int) player.transform.position.y);
            var secondPoint = rooms[Random.Range(0, rooms.Count - 1)].Rect.min + Vector2Int.one;
            var path = pathfinder.FindPath(firstPoint, secondPoint);
            if (path == null)
                return;
            for (int i = 0; i < path.Count - 1; i++)
            {
                var a = new Vector3(path[i].x + 0.5f, path[i].y + 0.5f);
                var b = new Vector3(path[i + 1].x + 0.5f, path[i + 1].y + 0.5f);
                Debug.DrawLine(a, b, Color.green, 50);
            }
        }
    }
}
