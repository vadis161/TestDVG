using UnityEngine;

namespace GameCharacter.Bonus
{
    [RequireComponent(typeof(Character))]
    public class BoostJump : AbstractBonus
    {
        public float Jump { get; set; } = 2f;

        protected override void ApplyEffect()
        {
            character.JumpForce += Jump;
        }

        protected override void RemoveEffect()
        {
            character.JumpForce -= Jump;
        }
    }
}