using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        SpeedIncrease,
    } 

    public ItemType type; 

    private void OnItemPickup(GameObject player)
    {
        switch (type)
        {
            case ItemType.SpeedIncrease:
                player.GetComponent<MovementController>().speed++;
                break; 
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) {
            OnItemPickup(other.gameObject);
        }
    }
}
