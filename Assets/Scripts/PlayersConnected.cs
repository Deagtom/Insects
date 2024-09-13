using Mirror;
using UnityEngine;
using System.Collections.Generic;

public class PlayersConnected : NetworkBehaviour
{
    public GameObject waitingPanel;
    public GameObject gamePanel;

    private List<NetworkIdentity> players = new List<NetworkIdentity>();
    private List<NetworkIdentity> readyPlayers = new List<NetworkIdentity>();

    private void Start()
    {
        waitingPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public override void OnStartServer()
    {
        NetworkServer.RegisterHandler<ConnectMessage>(OnPlayerConnected);
        NetworkServer.RegisterHandler<ReadyMessage>(OnPlayerReady);
    }

    private void OnPlayerConnected(NetworkConnection conn, ConnectMessage msg)
    {
        players.Add(conn.identity);
        UpdateWaitingPanel();
    }

    private void OnPlayerReady(NetworkConnection conn, ReadyMessage msg)
    {
        if (!readyPlayers.Contains(conn.identity))
        {
            readyPlayers.Add(conn.identity);
            CheckAllPlayersReady();
        }
    }

    private void CheckAllPlayersReady()
    {
        if (readyPlayers.Count == players.Count)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        waitingPanel.SetActive(false);
        gamePanel.SetActive(true);
        // Логика начала игры
    }

    private void UpdateWaitingPanel()
    {
        // Обновите панель ожидания списком подключенных игроков
    }
}

public struct ConnectMessage : NetworkMessage { }
public struct ReadyMessage : NetworkMessage { }
