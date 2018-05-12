using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour {

    public GameObject mainCube;
    private bool anim, jumped;
    private float speed = 0.5f, startTime, yPosCube;

    void FixedUpdate() {
        if (anim && mainCube.transform.localScale.y > 0.4f) {
            PressCube(speed);
        }
        else if (!anim) {
            if (mainCube.transform.localScale.y < 1f) {
                PressCube(-3f * speed);
            }
        }

        if (mainCube.GetComponent<Rigidbody>()) {
            if (mainCube.GetComponent<Rigidbody>().IsSleeping() && jumped) {
                print("Next platform");
                //mainCube.transform.localPosition = new Vector3(-0.3f, mainCube.transform.localPosition.y, mainCube.transform.localPosition.z);
                mainCube.transform.eulerAngles = new Vector3(0f, mainCube.transform.eulerAngles.y,0f);

            }
        }
        
    }

    void OnMouseDown(){
        if (mainCube.GetComponent<Rigidbody>() != null) {
            anim = true;
            startTime = Time.time;
        }

        yPosCube = mainCube.transform.localPosition.y;

    }

    void OnMouseUp() {
        if (mainCube.GetComponent<Rigidbody>() != null){
            anim = false;

            //Jump
            jumped = true;
            float force, diff;
            diff = Time.time - startTime;
            if (diff < 3f){
                force = 190 * diff;
            }else {
                force = 300f;
            }

            if (force < 60f) { force = 60f;}
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.up * force);
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * force);

            StartCoroutine(checkCubePos());
        }
    }

    void PressCube(float force) {
        mainCube.transform.localPosition -= new Vector3(0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale -= new Vector3(0f, force * Time.deltaTime, 0f);
    }


    IEnumerator checkCubePos() {
        yield return new WaitForSeconds(0.5f);
        if (yPosCube - mainCube.transform.localPosition.y <= 0 && yPosCube - mainCube.transform.localPosition.y>-0.02) print("Player lose  ");
        if (yPosCube - mainCube.transform.localPosition.y > 0 && yPosCube - mainCube.transform.localPosition.y < 0.02) print("Player lose  ");
    }
}
