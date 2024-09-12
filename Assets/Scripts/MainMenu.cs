using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToDeckBuilder()
    {
        SceneManager.LoadScene("DeckBuilder");
    }

    public void HostMatch()
    {
        NetworkManager networkManager = FindFirstObjectByType<NetworkManager>();
        if (networkManager != null)
            networkManager.StartHost();
    }

    public void JoinMatch()
    {
        NetworkManager networkManager = FindFirstObjectByType<NetworkManager>();
        if (networkManager != null)
            networkManager.StartClient();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}