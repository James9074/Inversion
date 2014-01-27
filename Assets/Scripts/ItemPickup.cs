using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{
    public Items item;
	public GameObject popupBox;
	private string popupText;
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.name == "Player")
        {

			GameObject poofObj = (GameObject)Instantiate(popupBox, new Vector2(.25f,.75f), Quaternion.identity);
			popupText = "You have found the "+item+"!";
			if (popupText == "You have found the DietSoda!")
				popupText = "You have found the Diet Soda!";
			if (popupText == "You have found the HartHat!")
				popupText = "You have found the Hard Hat!";
			poofObj.SendMessage("TheStart",popupText);
			Player.UnlockItem(item);
            GameObject.Destroy(this.gameObject);
        }



    }





}
