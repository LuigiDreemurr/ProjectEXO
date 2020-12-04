using UnityEngine;
using System.Collections;

public class LoadCredits : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && gameObject.transform.tag == "Credits")
        {
            Application.LoadLevel(3);
        }
    }
}
