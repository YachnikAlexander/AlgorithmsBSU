using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{

    public GameObject allCubes;
    public GameObject block;
    private GameObject blockInst;
    private Vector3 blockPos;
    private float speed = 7f;
    private bool onPlace = false;
	
	void Start ()
	{
	    spawn();
	}

    void Update()
    {
        if(blockInst.transform.position != blockPos && !onPlace)  
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed);
        else if (blockInst.transform.position == blockPos)
            onPlace = true;

        if (CubeJump.jump && CubeJump.nextBlock)
        {
            spawn();

            onPlace = false;
        }
    }

    float RandScale()
    {
        float rand;
        if (Random.Range(0, 100) > 80)
        {
            rand = Random.Range(1.4f, 2f);
        }
        else
        {
            rand = Random.Range(1.4f, 1.7f);
        }

        return rand;
    }

    void spawn()
    {
        blockPos = new Vector3(Random.Range(1.1f, 1.8f), Random.Range(-3f, 0f), 5.27f);
        blockInst = Instantiate(block, new Vector3(5f, -5f, 0f), Quaternion.identity) as GameObject;
        blockInst.transform.localScale = new Vector3(RandScale(), 0.35f, 10f);
        blockInst.transform.parent = allCubes.transform;
    }
}
