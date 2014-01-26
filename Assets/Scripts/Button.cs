using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    private Vector3 origin;
    public float fallSpeed = 5;
    public float releaseTime = 1;

    private float ReleaseTimer;

    public bool IsPressed
    {
        get
        {
            return (transform.position.y - origin.y) < -1;
        }
    }

	// Use this for initialization
	void Start () 
    {
        origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (ReleaseTimer < 0)
        {
            Vector3 position = transform.position;
            position += Vector3.up * fallSpeed * Time.deltaTime;

            float distance = (position.y - origin.y);
            if (distance > 0)
            {
                transform.position = origin;
            }
            else
            {
                transform.position = position;
            }
        }
        else
        {
            ReleaseTimer -= Time.deltaTime;
        }
	}

    private void OnTriggerStay2D(Collider2D collider)
    {
        OnTrigger(collider);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        OnTrigger(collider);
    }

    private void OnTrigger(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);

        if (collider.gameObject.name == "Player" || collider.gameObject.name == "Boulder(Clone)")
        {
            ReleaseTimer = releaseTime;
            Fall();
        }
    }

    private void Fall()
    {
        Vector3 position = transform.position;

        position -= Vector3.up * fallSpeed * Time.deltaTime;
        
        transform.position = position;
    }
}
