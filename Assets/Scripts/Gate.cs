using UnityEngine;
using System.Collections;
using System.Linq;

public class Gate : MonoBehaviour
{
    public GameObject[] ButtonObjects;
    private Button[] buttons;
    
	// Use this for initialization
	void Start () 
    {
        buttons = ButtonObjects.Select(o => o.GetComponent<Button>()).ToArray();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (buttons.All(b => b.IsPressed))
        {
            GameObject.Destroy(this.gameObject);
        }
	}
}
