using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 moveVector3;
    float moveSpeed;
    bool isMove = false;
    // Start is called before the first frame update
    void Start()
    {
        moveVector3 = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
    }

    void MoveUpdate()
    {
        if (!isMove)
            return;

        transform.position += new Vector3(moveVector3.x, 0, moveVector3.z) * moveSpeed * Time.deltaTime;
    }



    public void SetMoveVector(Vector2 vector, float speed, bool isMove)
    {
        this.isMove = isMove;
        moveVector3 = new Vector3(vector.x, 0, vector.y);
        moveSpeed = speed;

    }
}
