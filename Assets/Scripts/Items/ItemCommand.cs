using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Item))]
    public abstract class ItemCommand : MonoBehaviour
    {
        public abstract void Execute(Player player);
    }
}
