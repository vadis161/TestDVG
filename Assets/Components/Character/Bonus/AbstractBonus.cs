using System.Collections;
using UnityEngine;

namespace GameCharacter.Bonus
{
    public abstract class AbstractBonus : MonoBehaviour
    {
        float durationSeconds = 2f;
        BonusesObserver bonusesObserver;
        protected Character character;

        protected abstract void ApplyEffect();
        protected abstract void RemoveEffect();

        public float DurationSeconds { get => durationSeconds; set => durationSeconds = value; }

        void Start()
        {
            character = GetComponent<Character>();
            bonusesObserver = GetComponent<BonusesObserver>();

            RegistreBonus();
            ApplyEffect();
            StartCoroutine(WaitandRemoveBonus());
        }

        IEnumerator WaitandRemoveBonus()
        {
            yield return new WaitForSeconds(durationSeconds);

            RemoveEffect();
            UnregisterBonus();
            RemoveBonus();
        }

        void RemoveBonus()
        {
            Destroy(this);
        }
        void RegistreBonus()
        {
            bonusesObserver.AddBonuses(this);
        }

        void UnregisterBonus()
        {
            bonusesObserver.RemoveCurrentBonus();
        }

    }
}
