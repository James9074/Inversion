using UnityEngine;
using System.Collections;
using System.Linq;

public class Platform : MonoBehaviour {

    private GameObject player;
    private Collider2D playerCollider;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        playerCollider = player.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 size = (collider2D as BoxCollider2D).size;
        Collider2D[] colliders = Physics2D.OverlapAreaAll(transform.position - size/2, transform.position + size/2);

        bool collidingPlayer = colliders.Contains(playerCollider);
        bool playerRising = player.rigidbody2D.velocity.y > 0;

        if (playerRising)
        {
            EnableColliders(false);
        }
        else if (!collidingPlayer)
        {
            EnableColliders(true);
        }
	}

    private void EnableColliders(bool enable)
    {
        foreach (var collider in this.GetComponents<Collider2D>())
        {
            collider.enabled = enable;
        }
    }
}
