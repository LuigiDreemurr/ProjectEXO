using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && gameObject.transform.tag == "Start")
        {
            Application.LoadLevel(2);
        }
        else if (other.transform.tag == "Player" && gameObject.transform.tag == "Quit")
        {
            Application.Quit();
        }
    }
}
