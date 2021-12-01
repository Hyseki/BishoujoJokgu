using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public GameObject player;

    float moveMultiple = 20;

    public static GameManager GetInstance()
    {
        return instance;
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void SetCharacterMoveVector(Vector2 vector, float speed, bool isMove)
    {
        player.GetComponent<Player>().SetMoveVector(vector, speed * moveMultiple, isMove);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
