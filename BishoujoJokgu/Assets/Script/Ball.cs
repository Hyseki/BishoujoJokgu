using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 direction;
    private float radian;
    private readonly float gravity = 9.8f;
    private float time;
    private int bound;

	// Update is called once per frame
	private void Update()
    {
        time += Time.deltaTime;

        // 1 ~ 89도 각도를 벗어날 경우 버그남
        float x = startPosition.x + direction.x * Mathf.Cos(radian) * time;
        float y = startPosition.y + direction.y * Mathf.Sin(radian) * time - (gravity * 0.5f) * (time * time);
        float z = startPosition.z + direction.z * Mathf.Tan(radian) * time;

        transform.position = new Vector3(x, y, z);
    }

    public void Parabola(Vector3 targetPosition, float degreeAngle)
	{
        startPosition = transform.position;
        radian = Mathf.Deg2Rad * degreeAngle;
        time = 0;

        direction = targetPosition - transform.position;
        direction.y = degreeAngle * 0.2f;
	}

    private void Rebound()
	{
        Parabola(direction + direction, radian * Mathf.Rad2Deg);
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.collider.tag == "Finish")
        {
            Debug.Log(bound);
            if (bound++ == 0)
			{
                Rebound();
			}
            else if (bound >= 1)
			{
                Destroy(gameObject);
            }
        }
	}
}
