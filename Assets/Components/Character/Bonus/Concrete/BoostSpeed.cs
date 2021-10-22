using UnityEngine;

namespace GameCharacter.Bonus
{
    [RequireComponent(typeof(Character))]
    public class BoostSpeed : AbstractBonus
    {
        public float Speed { get; set; } = 5f;

        protected override void ApplyEffect()
        {
            character.Speed += Speed;
            character.IsCanDeath = false;
        }

        protected override void RemoveEffect()
        {
            character.Speed -= Speed;
            character.IsCanDeath = true;
        }
    }
}