using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine.UI;
using System.Net;
using System.Linq;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button serverBtn;
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private InputField ipInputField;

    [SerializeField] private ushort port = 7777;

    private void Awake()
    {
        serverBtn.onClick.AddListener(StartServer);
        hostBtn.onClick.AddListener(StartHost);
        clientBtn.onClick.AddListener(StartClient);
    }

    private void StartServer()
    {
        var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.SetConnectionData("0.0.0.0", port); // слушает все адреса
        NetworkManager.Singleton.StartServer();
        Debug.Log("Server started on 0.0.0.0:" + port);
    }

    private void StartHost()
    {
        var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.SetConnectionData("0.0.0.0", port); // слушает все адреса
        NetworkManager.Singleton.StartHost();
        Debug.Log("Host started on 0.0.0.0:" + port);
    }

    private void StartClient()
    {
        string ip = ipInputField.text.Trim();
        if (string.IsNullOrEmpty(ip))
        {
            Debug.LogWarning("Введите IP-адрес хоста!");
            return;
        }

        var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.SetConnectionData(ip, port); // подключаемся к IP хоста
        NetworkManager.Singleton.StartClient();
        Debug.Log("Client trying to connect to " + ip + ":" + port);
    }
}