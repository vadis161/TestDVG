using GameCharacter.Bonus;
using LevelScroll;
using UnityEngine;

namespace GameObstacle
{
    [RequireComponent(typeof(LevelScroller))]
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] ObstacleFactory barrierFactory;
        [SerializeField] ObstacleFactory bonusFactory;
        [SerializeField] BonusesObserver bonusesObserver;
        [Space]
        [Range(0f, 1f)]
        [SerializeField] float spawnBonusChance = 0.2f;
        [SerializeField] float spawnAfterDistance = 3f;
        [SerializeField] Transform ground;
        Vector3 startObstaclePosition;

        float lastSpawnInDistance = 0f;

        LevelScroller levelScroller;
        void Awake()
        {
            levelScroller = GetComponent<LevelScroller>();
        }

        private void Start()
        {
            CalcStartObstaclePosition();
        }
        void Update()
        {
            SpawnObstacleIfNeed();
        }

        void CalcStartObstaclePosition()
        {
            Vector3 rightSideOffScreen = Vector3.right * Helper.GetScreenHalfWidthUnit();
            Vector3 groundVertical = Vector3.up * ground.position.y;
            startObstaclePosition = rightSideOffScreen + groundVertical;
        }

        void SpawnObstacleIfNeed()
        {
            if (isNeedSpawnNewObstacle())
            {
                SpawnObstacle(GetRandomFactory());
            }
        }

        ObstacleFactory GetRandomFactory()
        {
            ObstacleFactory factory = barrierFactory;
            if (isCanSpawnBonus())
                factory = bonusFactory;

            return factory;
        }

        bool isCanSpawnBonus()
        {
            return !bonusesObserver.IsHaveBonus && spawnBonusChance >= Random.Range(0f, 1f);
        }

        bool isNeedSpawnNewObstacle()
        {
            return levelScroller.DistancePassed - lastSpawnInDistance >= spawnAfterDistance;
        }

        void SpawnObstacle(ObstacleFactory factory)
        {
            lastSpawnInDistance = levelScroller.DistancePassed;
            Obstacle newObstacle = factory.CreateNewBarrier(GetRandomObstacle(factory));
            newObstacle.transform.position = startObstaclePosition;
        }

        Obstacle GetRandomObstacle(ObstacleFactory factory)
        {
            int obstcaleCount = factory.Obstacles.Length;
            return factory.Obstacles[Random.Range(0, obstcaleCount)];
        }
    }
}