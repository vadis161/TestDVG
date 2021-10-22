using Collision;
using GameCharacter;
using LevelScroll;
using UnityEngine;

namespace GameObstacle
{
    [RequireComponent(typeof(ObjectScroller), typeof(CollisionTwoSpriteRenderer))]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;

        ObjectScroller objectScroller;
        public CollisionTwoSpriteRenderer CollisionTwoSpriteRenderer { get; private set; }
        public Character Character { get; private set; }
        public SpriteRenderer SpriteRenderer { get => spriteRenderer; }
        private void Awake()
        {
            CollisionTwoSpriteRenderer = GetComponent<CollisionTwoSpriteRenderer>();
            objectScroller = GetComponent<ObjectScroller>();
        }
        public void Inject(LevelScroller levelScroller, Character character)
        {
            Character = character;
            objectScroller.Inject(levelScroller);
            CollisionTwoSpriteRenderer.Inject(spriteRenderer, character.SpriteRenderer);
        }
    }
}
