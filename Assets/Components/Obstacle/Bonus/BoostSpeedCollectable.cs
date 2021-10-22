using GameCharacter.Bonus;
using UnityEngine;

namespace GameObstacle.Bonus
{

    public class BoostSpeedCollectable : AbstractBonusCollectable
    {
        [SerializeField] float boostSpeed = 5f;

        protected override void PlayerCollision()
        {
            BoostSpeed bonus = character.gameObject.AddComponent<BoostSpeed>();
            bonus.DurationSeconds = durationSeconds;
            bonus.Speed = boostSpeed;
        }
    }
}