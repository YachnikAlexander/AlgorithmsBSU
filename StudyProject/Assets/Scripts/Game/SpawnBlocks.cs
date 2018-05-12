using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour {

    public GameObject block;
    public float speed = 5f;

    private GameObject blockInst;
    private Vector3 blockPos;
    
	void Start () {
        blockPos = new Vector3(Random.Range(-0.5f, 3f), Random.Range(-3.5f, 0.5f), 0f);
        blockInst = Instantiate(block, new Vector3(0.5f, -5.5f, 0f), Quaternion.identity) as GameObject;
        blockInst.transform.localScale = new Vector3(Random.Range(1.2f, 2.2f), 0.3f, 2.17f);
	}

    void Update()
    {
        if (blockInst.transform.position != blockPos)
        {
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed);
        }
    }

}
