using UnityEngine;
using System.Collections;

public class Darkness : MonoBehaviour 
{

    bool prevEnabled = true;
    	
	// Update is called once per frame
	void Update () 
    {
        bool enabled = !(Player.itemEquiped == Items.Sunglasses);

        if (enabled != prevEnabled)
        {
            renderer.enabled = enabled;
            prevEnabled = enabled;
        }
	}
}
