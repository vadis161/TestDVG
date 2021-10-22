using GameCharacter;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay
{
    public class RestartOnCharacterDeath : MonoBehaviour
    {
        [SerializeField] Character character;
        private void Start()
        {
            character.EventDeath += OnPlayerDeath;
        }

        private void OnPlayerDeath()
        {
            ReloadScene();
        }
        void ReloadScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        private void OnDestroy()
        {
            character.EventDeath -= OnPlayerDeath;
        }
    }
}