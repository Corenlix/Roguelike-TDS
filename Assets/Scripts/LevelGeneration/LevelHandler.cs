using System.Linq;
using Enemies;
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
        [SerializeField] private EnemyFactory enemyFactory;
        [SerializeField] private SpawnEnemiesRune runesPrefab;

        private Level _level;
        
        [ContextMenu("Create Level")]
        private Level SpawnLevel()
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

        private void CreateRune(Vector2 position, SpawnEnemiesRune runeTemplate)
        {
            var rune = Instantiate(runeTemplate, position, Quaternion.identity);
            rune.SetEnemyFactory(enemyFactory);
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
