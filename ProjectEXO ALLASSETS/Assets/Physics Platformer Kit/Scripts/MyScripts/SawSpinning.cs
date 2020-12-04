using UnityEngine;
using System.Collections;

public class SawSpinning : MonoBehaviour {
    public float spinSpeed;
    private MenuControl menuControl;

	// Update is called once per frame
	void Update ()
    {
            transform.Rotate(Time.deltaTime * spinSpeed, 0, 0);
    }
}
