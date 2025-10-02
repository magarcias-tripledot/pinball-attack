using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pinball
{
    public class Game : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}