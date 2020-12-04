using UnityEngine;
using System.Collections;

public class HazardTimer : MonoBehaviour {

    public float OnOffCountDown;
    public float OnOffTimer;
    public float PauseCountDown;
    public float PauseTimer;
    public bool OnOff;
    private bool Pause;

    private MenuControl menuControl;
    private Renderer hazardRenderer;
    private Collider hazardCollider;

    // Use this for initialization
    void Start ()
    {
        Pause = false;

        hazardRenderer = gameObject.GetComponent<Renderer>(); //Sets the gameObject renderer to be On or Off depending on OnOff bool
        hazardCollider = gameObject.GetComponent<Collider>();

        //PauseMenu 
       // menuControl = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuControl>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if (menuControl.gamePaused == false)
        //{

            OnOffCountDown -= Time.deltaTime; // Counts Down

            if (OnOffCountDown <= 0)
            {
                if (Pause == false)
                {
                    Pause = true;

                    hazardRenderer.enabled = false; //Sets the gameObject renderer to be On or Off depending on OnOff bool
                    hazardCollider.enabled = false;

                    OnOff = !OnOff; //Sets the bool to the opposite
                }
                PauseCountDown -= Time.deltaTime;

                if (PauseCountDown <= 0)
                {
                    Pause = false;
                    OnOffCountDown = OnOffTimer; //Resets the timer\
                    PauseCountDown = PauseTimer;
                    hazardRenderer.enabled = OnOff; //Sets the gameObject renderer to be On or Off depending on OnOff bool
                    hazardCollider.enabled = OnOff;
                }
            }
       // }
	}
}
