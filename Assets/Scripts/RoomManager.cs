using UnityEngine;
using Cinemachine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;

    public CinemachineVirtualCamera virtualCam;
    private CinemachineConfiner2D confiner;

    private void Awake()
    {
        Instance = this;
        confiner = virtualCam.GetComponent<CinemachineConfiner2D>();
    }

    public void EnterRoom(Room newRoom, Transform player, Transform targetSpawnPoint)
    {
        confiner.m_BoundingShape2D = newRoom.confinerCollider;
        player.position = targetSpawnPoint.position;
    }
}
