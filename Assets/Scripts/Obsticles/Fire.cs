using UnityEngine;
using System.Collections;
using System.Linq;

public class Fire : MonoBehaviour 
{
    private BoxCollider2D rainArea;
    private bool isDeadly;

    private float extinguishTimer = 2f;

	// Use this for initialization
	void Start () 
    {
        isDeadly = true;
        rainArea = GameObject.Find("RainArea").collider2D as BoxCollider2D;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isDeadly && Player.itemEquiped == Items.Umbrella)
        {
            Collider2D[] collisions = Physics2D.OverlapAreaAll(transform.position + Vector3.one, transform.position - Vector3.one);
            
            if (collisions.Contains(rainArea))
            {
                HandleRain();
            }
        }
        else if (!isDeadly)
        {
            extinguishTimer -= Time.deltaTime;

            if (extinguishTimer <= 0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
	}

    void HandleRain()
    {
        isDeadly = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isDeadly)
        {
            if (collider.gameObject.name == "Player")
            {
                collider.gameObject.GetComponent<Player>().Kill();
            }
        }
    }
}
