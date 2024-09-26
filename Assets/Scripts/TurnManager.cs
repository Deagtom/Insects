using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections;

public class TurnManager : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI turnTimeText;
    [SerializeField] private Button endTurnButton;

    private int turn;
    private int turnTime;
    private Coroutine turnCoroutine;

    public bool IsPlayerTurn => turn % 2 == 0;

    public static TurnManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [Server]
    public void StartTurn()
    {
        if (turnCoroutine != null)
            StopCoroutine(turnCoroutine);

        turnCoroutine = StartCoroutine(TurnTimer());
    }

    private IEnumerator TurnTimer()
    {
        turnTime = 30;
        RpcUpdateTurnTime(turnTime);

        while (turnTime > 0)
        {
            yield return new WaitForSeconds(1);
            turnTime--;
            RpcUpdateTurnTime(turnTime);
        }

        ChangeTurn();
    }

    [Server]
    public void ChangeTurn()
    {
        turn++;
        RpcUpdateTurnButtonState(IsPlayerTurn);
        StartTurn();
    }

    [ClientRpc]
    private void RpcUpdateTurnTime(int time)
    {
        turnTimeText.text = time.ToString();
    }

    [ClientRpc]
    private void RpcUpdateTurnButtonState(bool isPlayerTurn)
    {
        endTurnButton.interactable = isPlayerTurn;
    }

    public void OnEndTurnButtonClicked()
    {
        if (isLocalPlayer)
        {
            CmdChangeTurn();
        }
    }

    [Command]
    private void CmdChangeTurn()
    {
        StartTurn();
    }
}