using UnityEngine;
using System.Collections;
using System.Linq;

public class Turret : MonoBehaviour 
{
    public Vector2 Direction;
    public float BulletSpeed;
    public float Distance;
    public float FireRate;

    public GameObject BulletPrefab;

    private Vector3 bulletSpawn;
    
    private float fireTimer;

	// Use this for initialization
	void Start () 
    {
        bulletSpawn = transform.FindChild("Spawn").position;
        Direction.Normalize();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.DrawLine(bulletSpawn, bulletSpawn + (Vector3)(Direction * Distance));

        fireTimer += Time.deltaTime;

        if (fireTimer > FireRate)
        {
            var hits = Physics2D.RaycastAll(bulletSpawn, Direction, Distance);

            
            foreach (var hit in hits)
            {
                Debug.Log(hit.collider.gameObject.name);
            }

            if (hits.Any(hit => hit.collider.gameObject.name == "Player"))
            {
                fireTimer = 0;
                Fire();
            }
        }
	}

    private void Fire()
    {
        GameObject bulletObj = GameObject.Instantiate(BulletPrefab, bulletSpawn, Quaternion.FromToRotation(Vector3.right, Direction)) as GameObject;
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        bullet.rigidbody2D.velocity = Direction * BulletSpeed;
        bullet.Distance = Distance;
    }
}
