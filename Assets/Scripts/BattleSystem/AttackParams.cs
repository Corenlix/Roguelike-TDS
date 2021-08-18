using System;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace BattleSystem
{
    [Serializable]
    public class AttackParams
    {
        [SerializeField] private int damage;
        [SerializeField] private float knockbackTime;
        [SerializeField] private float knockbackForce;
        [SerializeField] private LayerMask interactiveLayers;
        [FormerlySerializedAs("popup")] [SerializeField] private PopupSpawner popupSpawner;
    
        public int Damage => damage;
        public float KnockbackTime => knockbackTime;
        public float KnockbackForce => knockbackForce;
        public LayerMask InteractiveLayers => interactiveLayers;
        public PopupSpawner PopupSpawner => popupSpawner;
    
        public void SetPopupSpawner(PopupSpawner popupSpawner)
        {
            this.popupSpawner = popupSpawner;
        }
    }
}
