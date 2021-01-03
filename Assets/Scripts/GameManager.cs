using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gravity = -20.0f;
    public float maximumDownwardVelocity = -5f;

    public GameObject player;
    private Rigidbody playerPhysics;

    // Start is called before the first frame update
    void Start()
    {
        playerPhysics = player.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, gravity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //playerPhysics.velocity = (new Vector3(0, 10, 0));
            playerPhysics.AddForce(new Vector3(0, 100, 0));
        }

        
    }

    private void FixedUpdate()
    {
        if (playerPhysics.velocity.y < maximumDownwardVelocity)
            playerPhysics.velocity = (new Vector3(0, maximumDownwardVelocity, 0));
        if (playerPhysics.velocity.y > 10)
            playerPhysics.velocity = (new Vector3(0, 10, 0));
    }
}
