using UnityEngine;
using System.Collections;

public class RainArea : MonoBehaviour
{
    public GameObject RainDrop;
    public float SpawnRate;
    public float DropSpeed;

    BoxCollider2D area;
    private float spawnY;
    private float spawnLeft;
    private float spawnRight;
    private float height;

    private float spawnTimer;

    void Start()
    {
         area = GetComponent<BoxCollider2D>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (Player.itemEquiped == Items.Umbrella)
        {
            UpdateArea();

            spawnTimer += Time.deltaTime;

            if (spawnTimer > SpawnRate)
            {
                int numSpawns = (int)(spawnTimer / SpawnRate);

                for (int i = 0; i < numSpawns; i++)
                {
                    SpawnRainDrop();
                }
                spawnTimer = 0;
            }
        }
	}

    private void UpdateArea()
    {
        spawnY = transform.position.y + area.size.y / 2 + area.center.y;
        spawnLeft = transform.position.x - area.size.x / 2;
        spawnRight = transform.position.x + area.size.x / 2;
        height = area.size.y;
    }

    private void SpawnRainDrop()
    {
        Vector2 spawn = RandomSpawnPoint();

        GameObject dropObject = GameObject.Instantiate(RainDrop, spawn, Quaternion.identity) as GameObject;
        RainDrop drop = dropObject.GetComponent<RainDrop>();
        drop.MaxDistance = height;
        drop.Speed = DropSpeed;
    }

    private Vector2 RandomSpawnPoint()
    {
        float spawnX = Random.Range(spawnLeft, spawnRight);
        return new Vector2(spawnX, spawnY);
    }
}
