using Collision;
using GameCharacter;
using UnityEngine;

namespace GameObstacle
{
    [RequireComponent(typeof(Obstacle))]
    public class Barrier : MonoBehaviour
    {
        Obstacle obstacle;
        CollisionTwoSpriteRenderer collisionTwoSpriteRenderer;
        Character character;
        private void Start()
        {
            obstacle = GetComponent<Obstacle>();
            collisionTwoSpriteRenderer = obstacle.CollisionTwoSpriteRenderer;
            character = obstacle.Character;

            collisionTwoSpriteRenderer.EventCollisionDetected += OnPlayerCollision;
        }

        private void OnPlayerCollision()
        {
            character.Die();
        }
        private void OnDestroy()
        {
            collisionTwoSpriteRenderer.EventCollisionDetected -= OnPlayerCollision;
        }
    }
}
