using UnityEngine;
using System.Collections;

public class AutoType : MonoBehaviour {
	
	public float letterPause = 0.2f;
	public AudioClip sound;
	public Items item;

	string message;
	
	// Use this for initialization
	void Start () {
		//guiText.text = "You have recieved: ... " + item;
		//message = guiText.text;
		guiText.text = "";
		StartCoroutine(TypeText ());

	}

	void TheStart(string s){
		message = s;
	}
	
	IEnumerator TypeText () {

		foreach (char letter in message.ToCharArray()) {
			guiText.text += letter;
			if (sound)
				audio.PlayOneShot(sound);
			yield return 0;
			yield return new WaitForSeconds (letterPause);

		}
		yield return new WaitForSeconds(2);
		Destroy(this.gameObject);
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


}