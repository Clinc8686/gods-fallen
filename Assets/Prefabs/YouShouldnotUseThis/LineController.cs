using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] GameObject sky;
    [SerializeField] GameObject emptiness;

    private void Awake()
    {
        SpriteRenderer srT = sky.GetComponent<SpriteRenderer>();
        float topPosition = srT.bounds.center.y + srT.bounds.extents.y;
        float topLeftPosition = srT.bounds.center.x - srT.bounds.extents.x;
        float topRightPosition = srT.bounds.center.x + srT.bounds.extents.x;
        Vector2 topPositionRight = new Vector2(topRightPosition, topPosition);
        Vector2 topPositionLeft = new Vector2(topLeftPosition, topPosition);

        SpriteRenderer srB = emptiness.GetComponent<SpriteRenderer>();
        float bottomPosition = srB.bounds.center.y - srB.bounds.extents.y;
        float bottomLeftPosition = srB.bounds.center.x - srB.bounds.extents.x;
        float bottomRightPosition = srB.bounds.center.x + srB.bounds.extents.x;
        Vector2 bottomPositionRight = new Vector2(bottomRightPosition, bottomPosition);
        Vector2 bottomPositionLeft = new Vector2(bottomLeftPosition, bottomPosition);

        LineRenderer lr = GetComponent<LineRenderer>();
        lr.positionCount = 4;
        lr.SetPosition(0, bottomPositionLeft);
        lr.SetPosition(1, topPositionLeft);
        lr.SetPosition(2, topPositionRight);
        lr.SetPosition(3, bottomPositionRight);
        
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
