using Unity.Netcode;
using UnityEngine;

/// <summary>
/// Этот скрипт нужен, чтобы каждый клиент имел в качестве MainCamera - свою камеру.
/// </summary>
public class PlayerCamera : NetworkBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private AudioListener audioListener;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            // Отключаем всё для чужих игроков
            playerCamera.enabled = false;
            audioListener.enabled = false;
        }
        else
        {
            // Включаем для локального игрока
            playerCamera.enabled = true;
            audioListener.enabled = true;
        }
    }
}