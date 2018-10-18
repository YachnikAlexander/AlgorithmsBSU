using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour {

    public static bool jump, nextBlock = false;
    public GameObject mainCube, buttons, loseButtons;
    private bool anim, lose;
    private float speed = 0.5f, startTime, yPosCube;
    public static int count_blocks;

    void Start()
    {
        StartCoroutine(CanJump());
    }

    void FixedUpdate()
    {
        if (anim && mainCube.transform.localScale.y > 0.4f)
        {
            PressCube(speed);
        }
        else if (!anim && mainCube != null)
        {
            if (mainCube.transform.localScale.y < 1f)
            {
                PressCube(-3f * speed);
            }
        }

        if (mainCube != null)
        {
            if (mainCube.transform.position.y < -10f)
            {
                Destroy(mainCube, 0.5f);
                print("Player lose");
                lose = true;
            }
        }

        if (lose)
        {
            PlayerLose();
        }
    }

    void PlayerLose()
    {
        buttons.GetComponent<ScrollObjects>().speed = 5f;
        buttons.GetComponent<ScrollObjects>().checkPos = 0;
        if (loseButtons.activeSelf == false)
        {
            loseButtons.SetActive(true);
            loseButtons.GetComponent<ScrollObjects>().checkPos = 70;
        }
        GetComponent<AudioSource>().Play();

    }

    void OnMouseDown()
    {
        if (nextBlock && mainCube.GetComponent<Rigidbody>())
        {
            anim = true;
            startTime = Time.time;
            yPosCube = mainCube.transform.localPosition.y;
        }

    }

    void OnMouseUp()
    {
        if (nextBlock && mainCube.GetComponent<Rigidbody>() != null)
        {
            anim = false;

            jump = true;
            float force, diff;
            diff = Time.time - startTime;
            if (diff < 3f)
            {
                force = 190 * diff;
            }
            else
            {
                force = 300f;
            }

            if (force < 60f) { force = 60f; }

            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.up * force);
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * force);

            StartCoroutine(checkCubePos());

            nextBlock = false;
        }
    }

    void PressCube(float force)
    {
        mainCube.transform.localPosition -= new Vector3(0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale -= new Vector3(0f, force * Time.deltaTime, 0f);
    }


    IEnumerator checkCubePos()
    {
        yield return new WaitForSeconds(0.7f);
        if ((yPosCube - mainCube.transform.localPosition.y <= 0 && yPosCube - mainCube.transform.localPosition.y > -0.02) || (yPosCube - mainCube.transform.localPosition.y > 0 && yPosCube - mainCube.transform.localPosition.y < 0.02))
        {
            lose = true;
            print("Player lose");
        }
        else
        {
            while (!mainCube.GetComponent<Rigidbody>().IsSleeping())
            {
                yield return new WaitForSeconds(0.05f);
                if (mainCube == null)
                {
                    break;
                }
            }

            if (!lose)
            {
                nextBlock = true;
                count_blocks++;
                print("Next one");
                //mainCube.transform.localPosition = new Vector3(0f, mainCube.transform.localPosition.y, mainCube.transform.localPosition.z);
                mainCube.transform.eulerAngles = new Vector3(0f, mainCube.transform.eulerAngles.y, 5.249712f);
            }
        }
    }

    IEnumerator CanJump()
    {
        while (!mainCube.GetComponent<Rigidbody>())
        {
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        nextBlock = true;
    }
}
