using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button startServerButton;
    [SerializeField]
    private Button startHostButton;
    [SerializeField]
    private Button startClientButton;

    [SerializeField]
    private TextMeshProUGUI playersInGameText;

    private void Awake()
    {
        Cursor.visible = true;
    }
    private void Update()
    {
        playersInGameText.text = $"Players in game: {PlayersManager.Instance.PlayersInGame}";
    }

    private void Start()
    {
        startHostButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartHost())
            { 
                Logger.Instance.LogInfo("Started host");
            }
            else
            {
                Logger.Instance.LogInfo("Failed to start host");
            }
        }
        );
        startServerButton.onClick.AddListener(() =>
        {
            if(NetworkManager.Singleton.StartServer())
            {                 
                Logger.Instance.LogInfo("Started server");
            }
            else
            {
                Logger.Instance.LogInfo("Failed to start server");
            }
        }
        );
        startClientButton.onClick.AddListener(()=>
        {
            if(NetworkManager.Singleton.StartClient())
            {
                Logger.Instance.LogInfo("Started client");
            }
            else
            {
                Logger.Instance.LogInfo("Failed to start client");
            }
        }
        );
    }
}
