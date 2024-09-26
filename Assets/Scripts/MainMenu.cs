using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToDeckBuilder()
    {
        SceneManager.LoadScene("DeckBuilder");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}