using UnityEngine;
using System.Collections;

public class DoorTimer : MonoBehaviour
{

    public string[] effectedTags = { "Player" };                //which objects are vulnerable to this hazard (tags)
    public bool triggerEnter;				//are we checking for a trigger collision? (ie: hits a child trigger symbolising area of effect)
    public GameObject door;
    public float OpenCloseTimer; // The delay time for the door to reopen

    private const int STEALTH = 3;
    private SuitUpgrades SuitControl;
    private float OpenCloseCountdown; // Holds the current time on the counter
    private bool Colliding;

    void Awake()
    {
        SuitControl = GameObject.FindGameObjectsWithTag("SuitController")[0].GetComponent<SuitUpgrades>();

        //Colliding = false;
        //OpenCloseCountdown = OpenCloseTimer;
    }

    //if were checking for a trigger enter, attack what enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (!triggerEnter)
        {
            return;
        }

        foreach (string tag in effectedTags)
        {
            if (other.transform.tag == tag && STEALTH != (int)SuitControl.currentSuit)
            {
                Colliding = true;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!triggerEnter)
        {
            return;
        }

        foreach (string tag in effectedTags)
        {
            if (other.transform.tag == tag && STEALTH != (int)SuitControl.currentSuit)
            {
                Colliding = true;
            }
            else if (other.transform.tag == tag && STEALTH == (int)SuitControl.currentSuit)
            {
                Colliding = false;
            }
        }
    }

    void OnTriggerExit()
    {
        Colliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        OpenCloseCountdown -= Time.deltaTime;

        if (Colliding == false && OpenCloseCountdown <= 0)
        {
            door.GetComponent<Renderer>().enabled = false; //Sets the gameObject renderer to be On or Off depending on OnOff bool
            door.GetComponent<Collider>().enabled = false;
        }
        else if (Colliding == true)
        {
            OpenCloseCountdown = OpenCloseTimer;
            door.GetComponent<Renderer>().enabled = true; //Sets the gameObject renderer to be On or Off depending on OnOff bool
            door.GetComponent<Collider>().enabled = true;
        }
    }
}