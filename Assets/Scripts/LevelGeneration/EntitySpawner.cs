using UnityEngine;

namespace LevelGeneration
{
    internal class EntitySpawner
    {
        private readonly Level _level;
        private readonly Transform _player;

        public EntitySpawner(Level level, Transform playerTransform)
        {
            _level = level;
            _player = playerTransform;
        }

        public void MovePlayer()
        {
            _player.transform.position = _level.Rooms[Random.Range(0, _level.Rooms.Count - 1)].center;
        }
    }
}
