using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class TextNAdioHandler : MonoBehaviour
{
    public string folder;

    //Screen
    public GameObject screen;
    private bool isActive;

    //Text
    public GameObject textOut;
    private Text outputText;
    private int numOfLines;
    private List<string> devilTaunts = new List<string>();
    private int currentLine;
    private int finalTemp;
    private TextAsset text;

    //Character 
    public GameObject devile;
    public GameObject eugene;
    private int characterPic;

    //Audio
    private AudioSource aSource;
    public AudioClip[] audioFile;
    private int currentAudio;
    private int numFiles;
    
    // Use this for initialization
    void Start()
    {
        numOfLines = 0;
        currentLine = 0;
        currentAudio = 0;
        isActive = false;

        text = Resources.Load("Text/" + folder + "/GameText") as TextAsset;
        outputText = textOut.GetComponent<Text>();
        parseTextAsset(text);


        aSource = gameObject.GetComponent<AudioSource>();

        if (folder == "Menu")
        {
            numFiles = 2;
        }
        else
        {
            numFiles = 16;
        }

        audioFile = new AudioClip[numFiles];

        LoadAudioFiles();
    }

    // Update is called once per frame
    void Update()
    {
        //
        eugene.SetActive(true);
        devile.SetActive(true);

        //
        screen.SetActive(isActive);

        if (isActive)
        {
            //player.GetComponent<AudioSource>().Play();  //needs work...
            if (characterPic == 0)
            {
                eugene.SetActive(false);
            }
            else if (characterPic == 1)
            {
                devile.SetActive(false);
            }
        }
        else
        {
            //player.GetComponent<AudioSource>().Pause();  //needs work...
        }
    }

    /*public string getLines(int lines)
    {
        return devilTaunts[lines];
    }*/

    void parseTextAsset(TextAsset ft)
    {
        string fs = ft.text;
        string[] fLines = Regex.Split(fs, "\n");

        for (int i = 0; i < fLines.Length; i++)
        {
            devilTaunts.Add(fLines[i]);
            numOfLines++;
        }
    }

    void LoadAudioFiles()
    {
        Debug.Log(numFiles);
        for (int i = 0; i < numFiles; i++)
        {
            audioFile[i] = Resources.Load("Audio/" + folder + "/VoiceLines-" + (i + 1)) as AudioClip;
        }
    }

    public void dialogOn(int characterPortrat, int startLine, int finalLine)
    {

        isActive = true;
        characterPic = characterPortrat;
        currentLine = startLine;
        finalTemp = finalLine;
        StartCoroutine(printText());

    }

    public void dialogOff()
    {
        Debug.Log("dialogOff is underway");
        isActive = false;
        StopCoroutine(printText());
    }

    IEnumerator printText()
    {
        bool run = true;
        while (run)
        {

            outputText.text = devilTaunts[currentLine];
            aSource.clip = audioFile[currentAudio];

            currentLine++;
            currentAudio++;
            
            aSource.Play();

            yield return new WaitForSeconds(aSource.clip.length + 0.5f);

            if (currentLine > devilTaunts.Count)
            {
                Debug.Log("dialogOff is called");
                dialogOff();
                run = false;
            }
            if (currentLine >= finalTemp)
            {
                Debug.Log("dialogOff is called");
                dialogOff();
                run = false;
            }
        }

    }

}