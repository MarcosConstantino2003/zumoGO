using UnityEngine;

public class Door : MonoBehaviour
{
    public Room targetRoom;
    public Transform targetSpawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RoomManager.Instance.EnterRoom(targetRoom, collision.transform, targetSpawnPoint);
        }
    }
}
