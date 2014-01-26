using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{
    public Items item;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.name == "Player")
        {
            Player.UnlockItem(item);
            GameObject.Destroy(this.gameObject);
        }
    }
}
