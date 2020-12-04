using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;


public class textPopUp : MonoBehaviour
{

    public int startLine;
    public int finalLine;
    public int portrait;

    void OnTriggerEnter(Collider c)
    {

        //isActive = true;
        //StartCoroutine(printText());
        //Debug.Log("calling master script");
        FindObjectOfType<TextNAdioHandler>().dialogOn(portrait, startLine, finalLine);
        Destroy(gameObject);

    }
    /*
    IEnumerator printText()
    {

        textOut.GetComponent<Text>().text = "hello!";
        string temp;
        textOut.GetComponent<Text>().text = dialog[currentLine];
        currentLine++;
        
        yield return new WaitForSeconds(5.0f);
    }
    */
}
