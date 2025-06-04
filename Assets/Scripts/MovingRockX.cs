using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingRockX : MonoBehaviour
{
    public float moveDistance = 10f;
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private bool playerOnRock;

    // Start is called before the first frame update
    void Start()
    {
        //saves the starting position of the rock
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //calculates the new position
        float newPosition = Mathf.PingPong(Time.time * moveSpeed, moveDistance);

        //updates the rocks current position
        transform.position = startPosition + new Vector3(newPosition, 0f, 0f);
    }
}
