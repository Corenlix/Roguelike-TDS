using System.Linq;
using BattleSystem.Bullet.Attackers;
using BattleSystem.Bullet.TargetInteractiveCheckers;
using UI;
using UnityEngine;

namespace BattleSystem.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletBehavior bulletBehavior; 
        [SerializeField] private GameObject wallHitEffect;
        [SerializeField] private AttackerType attackerType;
    
        private AttackParams _attackParams;
        private Attacker _attacker;
        private TargetInteractiveChecker[] _targetInteractiveCheckers;

        public void Init(Vector2 targetPosition, AttackParams attackParams)
        {
            _attackParams = attackParams;
            _attacker = AttackerCreator.Create(attackerType);
            _targetInteractiveCheckers = new TargetInteractiveChecker[] { new LayersChecker(attackParams.InteractiveLayers) };
        
            bulletBehavior.Init(targetPosition);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            var otherGameObject = other.gameObject;
        
            if (_targetInteractiveCheckers.Any(x=>!x.IsTargetInteractive(otherGameObject)))
                return;
        
            if (other.isTrigger)
                OnEnemyHit(other);
            else
                OnWallHit();
        }

        private void OnEnemyHit(Collider2D enemyCollider)
        {
            _attacker.TryAttack(transform, enemyCollider, _attackParams);
        }
        private void OnWallHit()
        {
            if(wallHitEffect)
                Instantiate(wallHitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
