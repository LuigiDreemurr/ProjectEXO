using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public enum pickupType { Fire = 1, Radiation, Stealth};
    public pickupType currentPickup;

    private SuitUpgrades SuitControl;
    private SuitSwap suitSwap;

    void Start()
    {
        suitSwap = GameObject.FindGameObjectsWithTag("SuitController")[0].GetComponent<SuitSwap>();
        SuitControl = GameObject.FindGameObjectsWithTag("SuitController")[0].GetComponent<SuitUpgrades>();
    }

    void OnTriggerEnter(Collider c)
    {
        //
        SuitControl.UnlockedSuit[(int)currentPickup] = true;
        Debug.Log(currentPickup + " suit aquired");
        GameObject.Destroy(gameObject);

        //
        suitSwap.FindPrevSuit();
        suitSwap.FindNextSuit();
    }
}
