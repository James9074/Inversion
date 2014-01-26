using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour 
{
	public bool UnlockAllItems;
	
	private static bool UnlockAllItemsS;
	
	public static Items itemEquiped = 0;
	public static List<Items> itemsUnlocked;
	public static bool newItem = false;
	public Animator anim;
	public GameObject Poof;
	public static void UnlockItem(Items item)
	{
		if (!UnlockAllItemsS)
		{
			//Secret Unlock-Jutsu!
			itemsUnlocked.Add(item);
		}
	}
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		UnlockAllItemsS = UnlockAllItems;
		itemEquiped = 0;
		itemsUnlocked = new List<Items>();
		
		if (UnlockAllItems)
		{
			itemsUnlocked.AddRange(Enum.GetValues(typeof(Items)).Cast<Items>());
		}
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(newItem == true){
			Debug.Log(itemEquiped);
			newItem = false;
			anim.StopPlayback();
			anim.InterruptMatchTarget(true);
			
			
			UnityEngine.Object poofObj = GameObject.Instantiate(Poof, (Vector2) transform.position, Quaternion.identity);
			Destroy(poofObj,.25f);
			
			
		}
	}
	
	
	public void Kill()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}

public enum Items
{
	Empty,
	Heels,
	DietSoda,
	Windbreaker,
	HardHat,
	Umbrella,
	Sunglasses,
	Spacesuit
};

