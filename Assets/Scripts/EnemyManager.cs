using Mirror;
using UnityEngine;

public class EnemyManager : NetworkBehaviour
{
    public Transform handTransform;
    public Transform frontFieldTransform;
    public Transform backFieldTransform;

    public static EnemyManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (!isLocalPlayer)
            GameManager.Instance.SetEnemyPlayer(this);
    }
}