using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
//IGNORE THIS FOR NOW! I SWEAR I WILL USE A BEARABLE (hehe bear) SYSTEM SOON!
	// Use this for initialization

	public static int selGridInt = 0;
	public string[] selStrings = new string[] {"Empty", "Windbreaker", "Umbrella", "Sunglasses", "Diet Soda",  "Hard Hat", "Heels", "Spacesuit"};
	private int gridXPos = Screen.width/2 - 350; 
	private int gridYPos = Screen.height/8 -50; 
	private int gridXSize = 800;
	private int gridYSize = 30;
	void OnGUI () {
		//Item equiped to recieved, checked for GUI changes, and is set again.
		selGridInt = (int) Player.itemEquiped;
		selGridInt = GUI.SelectionGrid(new Rect(gridXPos, gridYPos, gridXSize, gridYSize), selGridInt, selStrings, 09);
        Player.itemEquiped = (Items) selGridInt;
		}
}
 