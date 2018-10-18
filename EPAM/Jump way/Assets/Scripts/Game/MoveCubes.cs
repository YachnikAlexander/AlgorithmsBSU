using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour {
    private bool moved = true;
    private Vector3 target;

    void Start()
    {
        target = new Vector3(0.23f, 5.9f, 0.52f);
    }

    void Update()
    {
        if (CubeJump.nextBlock)
        {
            if (transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 7f);
            }
            else if (transform.position == target && !moved)
            {
                target = new Vector3(transform.position.x - 2.8f, transform.position.y + 3.40f, transform.position.z);
                CubeJump.jump = false;
                moved = true;
            }

            if (CubeJump.jump)
            {
                moved = false;
            }
        }
    }
}
