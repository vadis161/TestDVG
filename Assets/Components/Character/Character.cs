using System;
using UnityEngine;

namespace GameCharacter
{
    [RequireComponent(typeof(Gravity))]
    public class Character : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [Space]
        [SerializeField] float speed = 10f;
        [SerializeField] float jumpForce = 15f;

        Gravity gravity;
        public bool IsCanDeath { get; set; } = true;
        public float Speed { get => speed; set => speed = value; }
        public float JumpForce { get => jumpForce; set => jumpForce = value; }
        public SpriteRenderer SpriteRenderer { get => spriteRenderer; }

        public event Action EventDeath;
        private void Awake()
        {
            gravity = GetComponent<Gravity>();
        }

        public void ToJump()
        {
            if (gravity.IsGround)
                gravity.AddForce(jumpForce);
        }

        public void Die()
        {
            if (IsCanDeath)
                EventDeath?.Invoke();
        }

    }
}
