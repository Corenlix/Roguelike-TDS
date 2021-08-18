using System;
using UnityEngine;

namespace Items
{
    [Serializable]
    [RequireComponent(typeof(ItemCommand))]
    [RequireComponent(typeof(Collider2D))]
    public class Item : MonoBehaviour
    {
        public string ItemName => itemName;
        [SerializeField] private string itemName;
        public string PickText => pickText;
        [SerializeField] private string pickText;
        [SerializeField] private bool needPressPickButton = false;
        public bool NeedPressPickButton => needPressPickButton;
        [SerializeField] private ItemCommand[] itemCommands;

        public void OnPick(Player player)
        {
            foreach (var itemCommand in itemCommands)
            {
                itemCommand.Execute(player);
            }
            Destroy(gameObject);
        }
    }
}
