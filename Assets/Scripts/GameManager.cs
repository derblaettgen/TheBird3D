using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gravity = -20.0f;
    public float maximumUpVelocity = 10.0f;
    public float maximumDownVelocity = -5.0f;
    public float jumpForce = 100.0f;

    public GameObject playerStart;
    public GameObject playerEntity;

    private GameObject player;
    private Rigidbody playerPhysics;

    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(playerEntity, playerStart.transform);
        playerPhysics = player.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, gravity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            playerPhysics.AddForce(new Vector3(0, jumpForce, 0));
        }

        
    }

    private void FixedUpdate()
    {
        if (playerPhysics.velocity.y < maximumDownVelocity)
            playerPhysics.velocity = (new Vector3(0, maximumDownVelocity, 0));
        if (playerPhysics.velocity.y > maximumUpVelocity)
            playerPhysics.velocity = (new Vector3(0, maximumUpVelocity, 0));
    }
}
