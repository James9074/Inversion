using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
//IGNORE THIS FOR NOW! I SWEAR I WILL USE A BEARABLE (hehe bear) SYSTEM SOON!
	// Use this for initialization

	public int selGridInt = 0;
	public string[] selStrings = new string[] {"Empty", "Windbreaker", "Umbrella", "Sunglasses", "Gasmask", "Diet Soda", "Armor", "Flashlight", "Hard Hat", "Heels", "Spacesuit"};

	void OnGUI () {
		
		selGridInt = GUILayout.SelectionGrid(new Rect(Screen.width/2 - 450, Screen.height/8, 900, 64), selGridInt, selStrings, 9);

		}
}
 