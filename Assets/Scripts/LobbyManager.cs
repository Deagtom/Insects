using Mirror;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : NetworkBehaviour
{
    [SyncVar] private int firstPlayerIndex;

    public List<GameObject> avatarObjects;
    private Dictionary<PlayerManager, GameObject> assignedPlayers = new Dictionary<PlayerManager, GameObject>();

    public static LobbyManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AssignAvatarAndButton(PlayerManager player)
    {
        for (int i = 0; i < avatarObjects.Count; i++)
        {
            if (!assignedPlayers.ContainsValue(avatarObjects[i]))
            {
                player.transform.position = avatarObjects[i].transform.position;
                avatarObjects[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(player.imagePath);

                Button readyButton = avatarObjects[i].GetComponentInChildren<Button>();
                readyButton.onClick.AddListener(() => player.CmdToggleReady());

                assignedPlayers[player] = avatarObjects[i];

                break;
            }
        }
    }

    
    [Server]
    private void DetermineFirstPlayer()
    {
        firstPlayerIndex = Random.Range(0, 2);
        
        int index = 0;
        foreach (var player in assignedPlayers.Keys)
        {
            player.isFirstPlayer = index == firstPlayerIndex;
            index++;
        }
    }


    public void CheckIfAllPlayersReady()
    {
        if (assignedPlayers.Keys.Count != 2)
            return;

        foreach (var player in assignedPlayers.Keys)
        {
            if (!player.isReady)
                return;
        }

        DetermineFirstPlayer();
        StartGame();
    }

    [Server]
    private void StartGame() => NetworkManager.singleton.ServerChangeScene("Game");

    public void StopGame()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
            NetworkManager.singleton.StopHost();
        else if (NetworkClient.isConnected)
            NetworkManager.singleton.StopClient();
        else if (NetworkServer.active)
            NetworkManager.singleton.StopServer();
    }
}