using UnityEngine;
using System.Collections;

public class DeathArea : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            collider.gameObject.GetComponent<Player>().Kill();
        }
    }
}
