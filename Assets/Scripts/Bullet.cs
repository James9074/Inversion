using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
    private Vector3 origin;
    private float maxDistanceSqr;

    public float Distance
    {
        set
        {
            maxDistanceSqr = value * value;
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
        float distanceSqr = (transform.position - origin).sqrMagnitude;

        if (distanceSqr > maxDistanceSqr)
        {
            GameObject.Destroy(this.gameObject);
        }
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Destroy(this.gameObject);

        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Player>().Kill();
        }
    }
}
