using UnityEngine;
using System.Collections;

public class RainDrop : MonoBehaviour 
{
    public float Speed;
    public float MaxDistance
    {
        set
        {
            MaxDistanceSqr = value * value;
        }
    }
    
    private float MaxDistanceSqr;

    private Vector3 origin;

	// Use this for initialization
	void Start () 
    {
        origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 position = transform.position;
        position -= Vector3.up * Speed * Time.deltaTime;
        transform.position = position;

        float distanceSqr = (position - origin).sqrMagnitude;

        if (distanceSqr > MaxDistanceSqr)
        {
            GameObject.Destroy(this.gameObject);
        }
	}
}
