using UnityEngine;
using System.Collections;
using System.Linq;

public class BoulderCreator : MonoBehaviour
{

    public GameObject BoulderPrefab;

    private bool PrevHatOn;

    private const float MaxHeight = 20f;
    private const float MinHeight = 8f;

	// Update is called once per frame
	void Update ()
    {
        Debug.DrawLine(transform.position + Vector3.up * MinHeight, transform.position + Vector3.up * MaxHeight, Color.green);
        Debug.DrawLine(transform.position, transform.position + Vector3.up * MinHeight, Color.red);

        bool hatOn = (Player.itemEquiped == Items.HardHat);

        if (PrevHatOn != hatOn)
        {
            if (hatOn)
            {
                TrySpawnBoulder();
            }

            PrevHatOn = hatOn;
        }
	}

    private void TrySpawnBoulder()
    {
        GameObject existingBoulder = GameObject.Find("Boulder(Clone)");
        if (existingBoulder != null)
        {
            GameObject.Destroy(existingBoulder);
        }

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.up);

        float height = MaxHeight;
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.name != "Player" && hit.collider.gameObject.name != "EffectArea")
            {
                Vector2 point = hit.point;
                float distance = (point - (Vector2) transform.position).magnitude;

                height = Mathf.Min(distance, height);
            }
        }

        Debug.Log(height);
        if (height >= MinHeight)
        {
            GameObject.Instantiate(BoulderPrefab, (Vector2) transform.position + new Vector2(0, height), Quaternion.identity);
        }
    }

}
