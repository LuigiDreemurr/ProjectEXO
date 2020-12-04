using UnityEngine;
using System.Collections;

//ATTACH TO MAIN CAMERA, shows your health and coins
public class GUIManager : MonoBehaviour 
{	
	public GUISkin guiSkin;                 //assign the skin for GUI display
    [HideInInspector]

    private SuitUpgrades suit;
	
	//setup, get how many coins are in this level
	void Start()
	{
        suit = GameObject.FindGameObjectsWithTag("SuitController")[0].GetComponent<SuitUpgrades>();
    }
	
	//show current health and how many coins you've collected
	void OnGUI()
	{
		GUI.skin = guiSkin;
		GUILayout.Space(5f);
	}
}