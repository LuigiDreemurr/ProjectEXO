using UnityEngine;
using System.Collections;

public class DoorTimerEdit: MonoBehaviour
{
    //
    public string[] effectedTags = { "Player" };                //which objects are vulnerable to this hazard (tags)
    public bool triggerEnter;				//are we checking for a trigger collision? (ie: hits a child trigger symbolising area of effect)
    public GameObject door;
    private Renderer doorRenderer;
    private Collider doorCollider;

    // Door animation
    public float speed;
    public int doorType;

    //Door 1
    public GameObject mainDoor;
    private Vector3 openPosition;
    public float openZ;

    private Vector3 closePosition;
    
    //
    private const int STEALTH = 3;
    private SuitUpgrades SuitControl;
    private float OpenCloseCountdown; // Holds the current time on the counter
    private bool Colliding;

    void Awake()
    {
        SuitControl = GameObject.FindGameObjectsWithTag("SuitController")[0].GetComponent<SuitUpgrades>();

        //doorRenderer = door.GetComponent<Renderer>();
        doorCollider = door.GetComponent<Collider>();
        
        closePosition = mainDoor.transform.position;
        openPosition = new Vector3(mainDoor.transform.position.x, mainDoor.transform.position.y, openZ);
        
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

        
        if (Colliding == false)
        {
            doorCollider.enabled = false;
                
            if (mainDoor.transform.position != openPosition)
            {
                mainDoor.transform.position += new Vector3(0, 0, speed/10);

                if (mainDoor.transform.position.z > openPosition.z)
                {
                    mainDoor.transform.position = openPosition;
                }

            }
            
        }
        else if (Colliding == true)
        {
            doorCollider.enabled = true;

            if (mainDoor.transform.position != closePosition)
            {
                mainDoor.transform.position -= new Vector3(0, 0, speed/10);

                if (mainDoor.transform.position.z < closePosition.z)
                {
                    mainDoor.transform.position = closePosition;
                }
            }
        }
    }
}