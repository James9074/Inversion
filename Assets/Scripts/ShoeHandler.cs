using UnityEngine;
using System.Collections;

public class ShoeHandler : MonoBehaviour 
{

    bool PrevIsShoes;
    	
	// Update is called once per frame
	void Update () 
    {
        bool isShoes = Player.itemEquiped == Items.Heels;

        if (isShoes != PrevIsShoes)
        {
            float scale = (isShoes) ? .5f : 1f;

            Vector3 localScale = transform.localScale;

            localScale.x = scale;
            localScale.y = scale;

            transform.localScale = localScale;

            PrevIsShoes = isShoes;
        }
	}
}
