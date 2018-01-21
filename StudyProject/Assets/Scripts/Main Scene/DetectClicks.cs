using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectClicks : MonoBehaviour {

    public GameObject buttons, m_cube, spawnBlocks, first_SpBlock;
    public Text playTxt, gameName;

    private bool clicked;

    void OnMouseDown()
    {
        if (!clicked)
        {
            clicked = true;
            playTxt.gameObject.SetActive(false);
            gameName.text = "0";
            buttons.GetComponent<ScrollObjects>().speed = -10f;
            buttons.GetComponent<ScrollObjects>().checkPos = -100f;
            m_cube.GetComponent<Animation>().Play("StartGameCube");

            Instantiate(first_SpBlock, new Vector3(-3f, 1.4f, 0f), Quaternion.identity);
        }
    }
}
