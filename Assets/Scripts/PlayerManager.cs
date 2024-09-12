using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public Transform handTransform;
    public Transform frontFieldTransform;
    public Transform backFieldTransform;

    private GameManager _gameManager;
    
    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();

        if (!isLocalPlayer)
            this.enabled = false;
        else
            _gameManager.SetLocalPlayer(this);
    }
}