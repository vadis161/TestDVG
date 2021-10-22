using UnityEngine;

namespace GameCharacter
{
    public class Gravity : MonoBehaviour
    {
        [SerializeField] Transform ground;
        public bool IsGround { get => transform.position.y <= groundVerticalPosition; }
        float groundVerticalPosition { get => ground.position.y; }

        float VerticalVelocity = 0f;

        private void Update()
        {
            ApplyVelocity();
            ApplyGravity();
        }

        void ApplyVelocity()
        {
            transform.position += Vector3.up * VerticalVelocity * Time.deltaTime;
        }
        void ApplyGravity()
        {
            if (!IsGround)
            {
                AddForce(Physics.gravity.y * Time.deltaTime);
            }
            else
            {
                VerticalVelocity = 0f;
            }

        }
        public void AddForce(float force)
        {
            VerticalVelocity += force;
        }
    }
}
