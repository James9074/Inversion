using UnityEngine;
using System.Collections;

public enum item  
{
    Sunglasses= 4,
    Heels=1,
    Umbrella=2,
    DietSoda=3
}

public class Current : MonoBehaviour
{
	public string currentItem = "None";
    public void setCurrentItem(string itemName){
		currentItem = itemName;
	}

	public string getCurrentItem(){
		return currentItem;
	}
}
