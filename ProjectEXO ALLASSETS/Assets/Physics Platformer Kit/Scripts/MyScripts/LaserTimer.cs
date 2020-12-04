using UnityEngine;
using System.Collections;

public class LaserTimer : MonoBehaviour {

    public float OnOffCountDown;
    public float OnOffTimer;
    public bool OnOff;

    // Use this for initialization
    void Start ()
    {
        //OnOff = true;
        //OnOffTimer = OnOffCountDown;
    }
	
	// Update is called once per frame
	void Update ()
    {
        OnOffCountDown -= Time.deltaTime; // Counts Down

        if (OnOffCountDown <= 0)
        {
            OnOff = !OnOff; //Sets the bool to the opposite
            OnOffCountDown = OnOffTimer; //Resets the timer
            gameObject.GetComponent<Renderer>().enabled = OnOff; //Sets the gameObject renderer to be On or Off depending on OnOff bool
            gameObject.GetComponent<Collider>().enabled = OnOff;
        }
	}
}
