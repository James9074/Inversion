using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static Items itemEquiped = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Kill()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

public enum Items
{
    Empty,
    Windbreaker,
    Umbrella,
    Sunglasses,
    DietSoda,
    HardHat,
    Heels,
    Spacesuit
};

