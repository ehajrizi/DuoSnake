using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2Int gridMoveDirection;

    private Vector2Int gridPosition;

    //nje variabel per me e store kohen untill the next movement
    private float gridMoveTimer;
    //nje variabel per me store kohen between moves
    private float gridMoveTimerMax;
    private void Awake()
    {
        gridPosition = new Vector2Int(0, 0);
        gridMoveTimerMax = 0.3f;
        gridMoveTimer = gridMoveTimerMax;  //shkaku i qesaj every 0.3second snake leviz ne grid
        gridMoveDirection = new Vector2Int(1, 0); // by default snake leviz ne te djathte

    }

    private void Update()
    {
        HandleInput();
        HandleGridMovement();


    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = +1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != +1) //mujna me shku down if we are not currentyly going down
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != +1)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -1)
            {
                gridMoveDirection.x = +1;
                gridMoveDirection.y = 0;
            }

        }


    }
    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            //nese osht true i bjen qe u bo 1 sekond prej qe kena leviz
            // na vyn me dit kah me qu tash
            gridPosition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax;
        }

        transform.position = new Vector3(gridPosition.x, gridPosition.y);
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 90);
    }

    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}