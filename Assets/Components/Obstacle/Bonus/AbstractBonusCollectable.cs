using GameCharacter;
using UnityEngine;

namespace GameObstacle.Bonus
{
    [RequireComponent(typeof(Obstacle))]
    public abstract class AbstractBonusCollectable : MonoBehaviour
    {
        [SerializeField] protected float durationSeconds = 30f;

        Obstacle obstacles;
        protected Character character { get => obstacles.Character; }
        protected abstract void PlayerCollision();

        void Awake()
        {
            obstacles = GetComponent<Obstacle>();
            obstacles.CollisionTwoSpriteRenderer.EventCollisionDetected += OnPlayerCollide;
        }

        void OnPlayerCollide()
        {
            PlayerCollision();
            Destroy(gameObject);
        }

        void OnDestroy()
        {
            obstacles.CollisionTwoSpriteRenderer.EventCollisionDetected -= OnPlayerCollide;
        }
    }
}