using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour {

    void OnMouseDown() {
        transform.localScale = new Vector3(1.10f, 1.10f, 1.10f);
    }

    void OnMouseUp(){
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
