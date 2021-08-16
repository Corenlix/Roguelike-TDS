using UnityEngine;

namespace BattleSystem.Bullet.TargetInteractiveCheckers
{
    public class LayersChecker : TargetInteractiveChecker
    {
        private LayerMask _interactiveLayers;

        public LayersChecker(LayerMask interactiveLayers)
        {
            _interactiveLayers = interactiveLayers;
        }
        public override bool IsTargetInteractive(GameObject target)
        {
            return (_interactiveLayers.value & (1 << target.gameObject.layer)) != 0;
        }
    }
}
