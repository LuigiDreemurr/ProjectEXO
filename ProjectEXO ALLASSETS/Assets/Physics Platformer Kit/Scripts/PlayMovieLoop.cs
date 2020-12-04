using UnityEngine;
using System.Collections;

public class PlayMovieLoop : MonoBehaviour {

    //public MovieTexture movie;

	// Use this for initialization
	void Start () {
        //movie.loop = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //movie.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            //movie.Stop();
        }
    }
}
