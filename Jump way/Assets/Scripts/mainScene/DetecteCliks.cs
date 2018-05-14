using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetecteCliks : MonoBehaviour
{

    public GameObject[] cubes;
    public GameObject buttons, m_cube, spawn_blocks, music;
    public Text playTxt, gameName, study, record;
    private bool clicked;
    public Animation cubes_anim, block;

    void OnMouseDown()
    {
        if (!clicked)
        {
            StartCoroutine(delCubes());
            clicked = true;
            playTxt.gameObject.SetActive(false);
            study.gameObject.SetActive(true);
            record.gameObject.SetActive(true);
            if (music.activeSelf)
            {
                for (int i = 0; i < music.transform.parent.transform.childCount; i++)
                {
                    music.transform.parent.transform.GetChild(i).gameObject.SetActive(!music.transform.parent.transform.GetChild(i).gameObject.activeSelf);
                }
            }
            gameName.text = "0";
            buttons.GetComponent<ScrollObjects>().speed = -10f;
            buttons.GetComponent<ScrollObjects>().checkPos = -150f;
            m_cube.GetComponent<Animation>().Play("StartGameCube");
            StartCoroutine(cubeToBlock());
            m_cube.transform.localScale = new Vector3(1f,1f,1f);
            cubes_anim.GetComponent<Animation>().Play("CubesPosition");
        } else if (clicked && study.gameObject.activeSelf)
            study.gameObject.SetActive(false);
    }

    IEnumerator delCubes()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.3f);
            Destroy(cubes[i]);
        }

        spawn_blocks.GetComponent<SpawnBlock>().enabled = true;
    }

    IEnumerator cubeToBlock()
    {
        yield return new WaitForSeconds(m_cube.GetComponent<Animation>().clip.length);
        block.Play();
        m_cube.AddComponent<Rigidbody>();   
    }

}
