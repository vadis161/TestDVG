using GameCharacter.Bonus;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BonusTimeLeftLabel : MonoBehaviour
    {
        [SerializeField] BonusesObserver bonusesObserver;

        float timeLeft = 0f;

        TextMeshProUGUI label;
        private void Awake()
        {
            label = GetComponent<TextMeshProUGUI>();

            bonusesObserver.EventAddBonus += OnAddBonus;
            bonusesObserver.EventRemoveBonus += OnRemoveBonus;

            HideLabel();
        }

        private void Update()
        {
            timeLeft -= Time.deltaTime;
            UpdateText();
        }
        private void OnAddBonus(AbstractBonus bonus)
        {
            timeLeft = bonus.DurationSeconds;
            ShoweLabel();
            UpdateText();
        }

        private void OnRemoveBonus()
        {
            HideLabel();
        }

        void UpdateText()
        {
            label.text = System.Math.Ceiling(timeLeft).ToString();
        }

        void ShoweLabel()
        {
            gameObject.SetActive(true);
        }

        void HideLabel()
        {
            gameObject.SetActive(false);
        }

    }
}