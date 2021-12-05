using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 moveVector3;
	private float moveSpeed;
	private bool isMove = false;

	// Start is called before the first frame update
	private void Start()
    {
        moveVector3 = new Vector3(0, 0, 0);
    }

	// Update is called once per frame
	private void Update()
    {
        MoveUpdate();

        if (Input.GetMouseButtonDown(0))
		{
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
			{
                var ball = Instantiate(Resources.Load<GameObject>("Ball"));
                ball.transform.position = transform.position + Vector3.up;
                ball.GetComponent<Ball>().Parabola(hit.point, 45f);
			}
		}
    }

	private void MoveUpdate()
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
