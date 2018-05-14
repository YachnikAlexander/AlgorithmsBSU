using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjects : MonoBehaviour
{

    public float speed = 5f, checkPos = 0f;
    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (rect.offsetMin.y != checkPos)
        {
            rect.offsetMin += new Vector2(rect.offsetMin.x, speed);
            rect.offsetMax += new Vector2(rect.offsetMax.x, speed);

        }
    }
}
