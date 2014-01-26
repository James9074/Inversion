using UnityEngine;
using System.Collections;

public class FragilePlatform : MonoBehaviour
{
    private float BreakTimer = 1;
    private bool isBreaking;

    void Update()
    {
        if (isBreaking)
        {
            BreakTimer -= Time.deltaTime;

            if (BreakTimer <= 0)
            {
                OnBroken();
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("hre");
            if (Player.itemEquiped == Items.DietSoda)
            {
                Break();
            }
        }
    }

    private void Break()
    {
        isBreaking = true;

        foreach (var collider in this.GetComponents<Collider2D>())
        {
            GameObject.Destroy(collider);
        }
    }

    private void OnBroken()
    {
        GameObject.Destroy(this.gameObject);
    }
}
