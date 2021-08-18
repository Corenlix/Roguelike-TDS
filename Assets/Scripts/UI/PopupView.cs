using TMPro;
using UnityEngine;

namespace UI
{
    public class PopupView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro text;

        public void SetDescription(string description)
        {
            text.text = description;
        }
    }
}