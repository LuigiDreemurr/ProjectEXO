using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SuitSwap : MonoBehaviour {

    private SuitUpgrades SuitControl;

    public Material[] material;

    public GameObject[] Icons;

    private Image[] Icon;

    public Sprite[] IconSprites;

    private Renderer rend;

    private MenuControl menuControl;
    
    private bool buttonPressed;
    private float switchTimer;
    private const float DELAY = 0.2f;
    public bool triggerPressed;

    void Start()
    {
        rend = GameObject.FindGameObjectsWithTag("MaterialHandler")[0].GetComponent<Renderer>();

        SuitControl = GameObject.FindGameObjectsWithTag("SuitController")[0].GetComponent<SuitUpgrades>();

        //PauseMenu 
        menuControl = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuControl>();

        SuitControl.UnlockedSuit[0] = true;

        for (int i = 1; i < SuitUpgrades.MAX_SUITS; i++)
        {
            SuitControl.UnlockedSuit[i] = false; 
        }

        buttonPressed = false;

        triggerPressed = false;

        switchTimer = DELAY;
    }

    //
    public void FindPrevSuit()
    {
        if (menuControl.gamePaused == false)
        {
            //Find Next Suit
            bool unlockedSuitFound = false;

            int validSuit = (int)SuitControl.currentSuit;

            while (!unlockedSuitFound)
            {
                validSuit++;

                if (validSuit > 3)
                {
                    validSuit = 0;
                }

                if (SuitControl.UnlockedSuit[validSuit] == true)
                {
                    SuitControl.nextSuit = (SuitUpgrades.upgrades)validSuit;
                    unlockedSuitFound = true;

                    //Swaps CurrentSuit Icon
                    Icons[2].GetComponent<Image>().sprite = IconSprites[validSuit];
                }
            }
        }
    }

    public void FindNextSuit()
    {
        if (menuControl.gamePaused == false)
        {
            //Find Previous Suit
            bool unlockedSuitFound = false;

            int validSuit = (int)SuitControl.currentSuit;

            while (!unlockedSuitFound)
            {
                validSuit--;

                if (validSuit < 0)
                {
                    validSuit = 3;
                }

                if (SuitControl.UnlockedSuit[validSuit] == true)
                {
                    SuitControl.previousSuit = (SuitUpgrades.upgrades)validSuit;
                    unlockedSuitFound = true;

                    //Swaps CurrentSuit Icon
                    Icons[1].GetComponent<Image>().sprite = IconSprites[validSuit];
                }
           }
        }
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(menuControl.gamePaused);

        {
            switchTimer -= Time.deltaTime;

            if (switchTimer <= 0)
            {
                buttonPressed = false;
            }

            if ((Input.GetAxisRaw("Next Suit (X-Box)") == -1 && triggerPressed != true) || Input.GetButtonUp("Last Suit (PC)"))
            {
                bool unlockedSuitFound = false;

                int validSuit;

                triggerPressed = true;

                validSuit = (int)SuitControl.currentSuit;

                while (!unlockedSuitFound)
                {
                    validSuit++;

                    if (validSuit > 3)
                    {
                        validSuit = 0;
                    }

                    if (SuitControl.UnlockedSuit[validSuit] == true)
                    {
                        SuitControl.currentSuit = (SuitUpgrades.upgrades)validSuit;
                        rend.material = material[validSuit];
                        unlockedSuitFound = true;

                        //Swaps CurrentSuit Icon
                        Icons[0].GetComponent<Image>().sprite = IconSprites[validSuit];
                    }
                }

                //Debug.Log("Current: " + SuitControl.currentSuit);

                FindNextSuit();

                //Debug.Log("Next: " + SuitControl.nextSuit);

                FindPrevSuit();

                //Debug.Log("Prev: " + SuitControl.previousSuit);

                Debug.Log(Input.GetAxisRaw("Next Suit (X-Box)"));

            }

            if ((Input.GetAxisRaw("Last Suit (X-Box)") < 1 && Input.GetAxisRaw("Next Suit (X-Box)") > 0))
            {
                triggerPressed = false;
            }

            if ((Input.GetAxisRaw("Last Suit (X-Box)") == 1 && triggerPressed != true) || Input.GetButtonUp("Last Suit (PC)"))
            {
                bool unlockedSuitFound = false;

                int validSuit;

                triggerPressed = true;

                validSuit = (int)SuitControl.currentSuit;

                while (!unlockedSuitFound)
                {
                    validSuit--;

                    if (validSuit < 0)
                    {
                        validSuit = 3;
                    }

                    if (SuitControl.UnlockedSuit[validSuit] == true)
                    {
                        SuitControl.currentSuit = (SuitUpgrades.upgrades)validSuit;
                        rend.material = material[validSuit];
                        unlockedSuitFound = true;

                        //Swaps CurrentSuit Icon
                        Icons[0].GetComponent<Image>().sprite = IconSprites[validSuit];
                    }
                }

                //Debug.Log("Current: " + SuitControl.currentSuit);


                FindNextSuit();

                //Debug.Log("Next: " + SuitControl.nextSuit);

                FindPrevSuit();

                //Debug.Log("Prev: " + SuitControl.previousSuit);

                Debug.Log(Input.GetAxisRaw("Last Suit (X-Box)"));
            }

            //Hotkeys
            if (Input.GetAxisRaw("Base (X-Box)") < -0.8 || Input.GetButtonUp("Base (PC)"))
            {
                //Switches current suit to be base
                SuitControl.currentSuit = SuitUpgrades.upgrades.Base;

                FindNextSuit();
                FindPrevSuit();

                //Switches current material to be base
                rend.material = material[0];

                //Swaps CurrentSuit Icon
                Icons[0].GetComponent<Image>().sprite = IconSprites[0];

                //Sends out current suit in the console
                Debug.Log(SuitControl.currentSuit);

                Debug.Log(Input.GetAxisRaw("Next Suit (X-Box)"));
            }
            if ((Input.GetAxisRaw("Fire (X-Box)") > 0.8 && SuitControl.UnlockedSuit[(int)SuitUpgrades.upgrades.Fire] == true) || (Input.GetButtonUp("Fire (PC)") && SuitControl.UnlockedSuit[(int)SuitUpgrades.upgrades.Fire] == true))
            {
                SuitControl.currentSuit = SuitUpgrades.upgrades.Fire;

                FindNextSuit();
                FindPrevSuit();

                //Switches current material to be fire
                rend.material = material[1];

                //Swaps CurrentSuit Icon
                Icons[0].GetComponent<Image>().sprite = IconSprites[1];

                Debug.Log(SuitControl.currentSuit);
            }
            if ((Input.GetAxisRaw("Stealth (X-Box)") < -0.8 && SuitControl.UnlockedSuit[(int)SuitUpgrades.upgrades.Stealth] == true) || (Input.GetButtonUp("Stealth (PC)") && SuitControl.UnlockedSuit[(int)SuitUpgrades.upgrades.Stealth] == true))
            {
                SuitControl.currentSuit = SuitUpgrades.upgrades.Stealth;

                FindNextSuit();
                FindPrevSuit();

                //Switches current material to be stealth
                rend.material = material[3];

                //Swaps CurrentSuit Icon
                Icons[0].GetComponent<Image>().sprite = IconSprites[3];

                Debug.Log(SuitControl.currentSuit);
            }
            if ((Input.GetAxisRaw("Radiation (X-Box)") > 0.8 && SuitControl.UnlockedSuit[(int)SuitUpgrades.upgrades.Radiation] == true) || (Input.GetButtonUp("Radiation (PC)") && SuitControl.UnlockedSuit[(int)SuitUpgrades.upgrades.Radiation] == true))
            {
                SuitControl.currentSuit = SuitUpgrades.upgrades.Radiation;

                FindNextSuit();
                FindPrevSuit();

                //Switches current material to be radiation
                rend.material = material[2];

                //Swaps CurrentSuit Icon
                Icons[0].GetComponent<Image>().sprite = IconSprites[2];

                Debug.Log(SuitControl.currentSuit);
            }
        }
    }
}
