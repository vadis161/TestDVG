using GameCharacter;
using LevelScroll;
using UnityEngine;

namespace GameObstacle
{
    public class ObstacleFactory : MonoBehaviour
    {
        [SerializeField] Obstacle[] obstacles;
        [Space]
        [SerializeField] LevelScroller levelScroller;
        [SerializeField] Character character;
        public Obstacle[] Obstacles { get => obstacles; }
        public Obstacle CreateNewBarrier(Obstacle obstaclePrefab)
        {
            Obstacle newObstacle = Instantiate(obstaclePrefab);
            newObstacle.Inject(levelScroller, character);
            return newObstacle;
        }
    }
}