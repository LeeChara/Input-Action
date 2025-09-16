using System.Net.NetworkInformation;
using UnityEditor.Purchasing;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    [Header("# Subject")]
    public PlayerInputBroadcaster inputBroadcaster;

    [Header("# Observer")]
    public PlayerMovement playerMovement;

    private void Awake()
    {
        inputBroadcaster.Subscribe(playerMovement);
        Debug.Log("PlayerInitializer : Observer�� �߰��Ͽ����ϴ�." +  playerMovement);
    }
    private void OnDestroy()
    {
        inputBroadcaster.Unsubscribe(playerMovement);
        Debug.Log("PlayerInitializer : Observer�� �����Ͽ����ϴ�." + playerMovement);
    }
}
