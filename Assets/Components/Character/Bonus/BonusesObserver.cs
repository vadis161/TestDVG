using System;
using UnityEngine;

namespace GameCharacter.Bonus
{
    public class BonusesObserver : MonoBehaviour
    {
        public bool IsHaveBonus { get; private set; }

        public event Action<AbstractBonus> EventAddBonus;
        public event Action EventRemoveBonus;
        public void AddBonuses(AbstractBonus bonus)
        {
            IsHaveBonus = true;
            EventAddBonus?.Invoke(bonus);
        }

        public void RemoveCurrentBonus()
        {
            IsHaveBonus = false;
            EventRemoveBonus?.Invoke();
        }
    }
}
