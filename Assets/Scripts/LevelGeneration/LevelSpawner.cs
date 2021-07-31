using System;
using UnityEngine;

namespace LevelGeneration
{
    public class LevelSpawner : MonoBehaviour
    {
        [SerializeField] private LevelCreator levelCreator;
        [SerializeField] private LevelDrawer levelDrawer;
        [SerializeField] private Transform player;
        
        private void SpawnLevel()
        {
            var level = levelCreator.CreateLevel();
            var entitySpawner = new EntitySpawner(level, player);
            entitySpawner.MovePlayer();
            levelDrawer.DrawLevel(level.LevelCells);
        }

        private void Start()
        {
            SpawnLevel();
        }
    }
}
