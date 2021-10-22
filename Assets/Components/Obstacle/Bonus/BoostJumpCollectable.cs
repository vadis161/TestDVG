using GameCharacter.Bonus;
using UnityEngine;

namespace GameObstacle.Bonus
{
    public class BoostJumpCollectable : AbstractBonusCollectable
    {
        [SerializeField] float boostJump = 2f;

        protected override void PlayerCollision()
        {
            BoostJump bonus = character.gameObject.AddComponent<BoostJump>();
            bonus.DurationSeconds = durationSeconds;
            bonus.Jump = boostJump;
        }
    }
}