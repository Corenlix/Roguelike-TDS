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

        private Level _level;
        
        private Level SpawnLevel()
        {
            var level = levelCreator.CreateLevel();
            var entitySpawner = new EntitySpawner(level, player);
            entitySpawner.MovePlayer();
            levelDrawer.DrawLevel(level.LevelCells);
            return level;
        }

        private void Start()
        {
            _level = SpawnLevel();
            Pathfinder = new Pathfinder(_level);
        }

        private void Awake()
        {
            if(!Instance)
                Instance = this;
            else Destroy(gameObject);
        }
    }
}
