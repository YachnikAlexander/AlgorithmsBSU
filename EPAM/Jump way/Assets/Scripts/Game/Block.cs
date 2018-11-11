using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    private bool firstOne;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cube" && firstOne)
        {
            GetComponent<AudioSource>().Play();
        }





//hjdglhgjdksgjksd

        if (!firstOne) firstOne = true;
    }
}
