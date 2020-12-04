using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HazardWarning : MonoBehaviour
{

    //Timer
    private float onDuration;
    private float offDuration;
    private float currentTime;

    private bool hazardState;

    private enum hazards { Fire = 1, Radiation }
    private hazards currentHazard;

    //Hazards
    public GameObject fireHazard;
    public GameObject radiationHazard;

    //Particle Effects
    public ParticleSystem fireParticle;
    public ParticleSystem radiationParticle;

    // Warning
    public Sprite[] warningSprites;
    public GameObject warning;

    private Image warningImage;

    private bool waitStart;

    void Awake()
    {
        warningImage = warning.GetComponent<Image>();
        //warningRenderers = GameObject.FindGameObjectsWithTag("MaterialHandler").GetComponent<Renderer>();
    }

    // Use this for initialization
    void Start()
    {
        warning.SetActive(false);
        onDuration = 2.0f;
        offDuration = 4.0f;
        waitStart = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            warning.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            warning.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= offDuration / 3)
        {
            warningImage.sprite = warningSprites[(int)currentHazard];
            if (waitStart)
            {
                if ((int)currentHazard != 1)
                {
                    radiationParticle.Play();
                }
                else
                {
                    fireParticle.Play();
                }
                waitStart = false;
            }

        }

        if (currentTime >= onDuration && hazardState == true)
        {
            hazardState = false;
            currentTime = 0;
            waitStart = true;

            //
            warningImage.sprite = warningSprites[0];

            //Turns off hazards
            if (currentHazard == hazards.Fire)
            {
                fireHazard.SetActive(false);
                //fireParticle.Pause();
                currentHazard = hazards.Radiation;
            }
            else
            {
                radiationHazard.SetActive(false);
                //radiationParticle.Pause();
                currentHazard = hazards.Fire;
            }
        }
        else if (currentTime >= offDuration && hazardState == false)
        {
            hazardState = true;
            currentTime = 0;

            //Turns on hazards
            if (currentHazard == hazards.Fire)
            {
                fireHazard.SetActive(true);
                //fireParticle.Play();

            }
            else
            {
                radiationHazard.SetActive(true);
                //radiationParticle.Play();
            }
        }

    }
}
