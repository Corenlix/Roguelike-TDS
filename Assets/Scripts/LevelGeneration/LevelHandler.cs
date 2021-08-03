using System.Linq;
using Pathfinding;
using UnityEngine;

namespace LevelGeneration
{
    public class LevelHandler : MonoBehaviour
    {
        public static LevelHandler Instance;
        public Pathfinder Pathfinder { get; private set; }
        
        [SerializeField] private LevelCreator levelCreator;
        [SerializeField] private LevelDrawer levelDrawer;
        [SerializeField] private Transform player;
        [SerializeField] private GameObject enemiesPrefab;
        [SerializeField] private SpawnEnemiesRune runesPrefab;

        private Level _level;
        
        public Level SpawnLevel()
        {
            var level = levelCreator.CreateLevel();
            var entitySpawner = new EntitySpawner(level, player);

            var notUsedRooms = level.Rooms.ToList();
            var playerRoom = entitySpawner.MovePlayer();
            notUsedRooms.Remove(playerRoom);
            foreach (var room in notUsedRooms)
            {
                CreateRune(room.center, runesPrefab);
            }
            
            levelDrawer.DrawLevel(level.LevelCells);
            return level;
        }

        private void CreateRune(Vector2 position, SpawnEnemiesRune rune)
        {
            SpawnEnemiesRune createdRune = Instantiate(rune, position, Quaternion.identity);
            createdRune.runeDestroyed.AddListener(
                (destroyedRune) =>
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        SpawnEnemy(destroyedRune.transform.position, enemiesPrefab);
                    }
                }
                );
        }
        private void SpawnEnemy(Vector2 position, GameObject enemy)
        {
            Instantiate(enemy, position, Quaternion.identity);
        }
        private void Awake()
        {
            if(!Instance)
                Instance = this;
            else Destroy(gameObject);
            
            _level = SpawnLevel();
            Pathfinder = new Pathfinder(_level);
        }
    }
}
