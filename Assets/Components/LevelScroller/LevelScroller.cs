using GameCharacter;
using UnityEngine;

namespace LevelScroll
{
    public class LevelScroller : MonoBehaviour
    {
        [SerializeField] Character character;
        public float Speed { get => character.Speed; }
        public float DistancePassed { get; private set; }

        private void Update()
        {
            UpdateDistance();
        }

        void UpdateDistance()
        {
            DistancePassed += Speed * Time.deltaTime;
        }
    }
}
