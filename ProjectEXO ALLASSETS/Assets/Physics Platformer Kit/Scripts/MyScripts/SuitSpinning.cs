using UnityEngine;
using System.Collections;

public class SuitSpinning : MonoBehaviour
{
    public float spinSpeed;
    private MenuControl menuControl;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * spinSpeed, 0);
    }
}