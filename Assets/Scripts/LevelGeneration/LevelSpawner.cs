using System;
using UnityEngine;

namespace LevelGeneration
{
    public class LevelSpawner : MonoBehaviour
    {
        [SerializeField] private LevelCreator levelCreator;
        [SerializeField] private LevelDrawer levelDrawer;

        private void SpawnLevel()
        {
            var level = levelCreator.CreateLevel();
            levelDrawer.DrawLevel(level);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SpawnLevel();
        }

        private void Start()
        {
            SpawnLevel();
        }
    }
}
