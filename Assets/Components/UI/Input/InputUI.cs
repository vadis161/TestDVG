using GameCharacter;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Input
{
    public class InputUI : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] Character character;

        public void OnPointerDown(PointerEventData eventData)
        {
            character.ToJump();
        }
    }
}