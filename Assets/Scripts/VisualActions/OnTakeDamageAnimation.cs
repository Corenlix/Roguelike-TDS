using UnityEngine;

namespace VisualActions
{
    [RequireComponent(typeof(Health))]
    public class OnTakeDamageAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");

        private void OnEnable()
        {
            GetComponent<Health>().Damaged += PlayDamageAnimation;
        }

        private void OnDisable()
        {
            GetComponent<Health>().Damaged -= PlayDamageAnimation;
        }

        private void PlayDamageAnimation(int damage)
        {
            animator.SetTrigger(TakeDamage);
        }
    }
}
