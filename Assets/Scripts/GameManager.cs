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

    public GameObject pipeGeneratorOrigin;
    public GameObject pipeEntity;

    private GameObject player;
    private Rigidbody playerPhysics;

    public float respawnTime = 1.0f;
    private float lastRespawnInMS = 0f;

    private PipeGenerator pipeGenerator;

    // Start is called before the first frame update
    void Start()
    {
        pipeGenerator = gameObject.AddComponent<PipeGenerator>();
        pipeGenerator.origin = pipeGeneratorOrigin.transform;
        pipeGenerator.obstacle = pipeEntity;

        player = Instantiate(playerEntity, playerStart.transform);
        playerPhysics = player.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, gravity, 0);

        pipeGenerator.SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            playerPhysics.AddForce(new Vector3(0, jumpForce, 0));
        }

        handlePipes();
    }

    void FixedUpdate()
    {
        if (playerPhysics.velocity.y < maximumDownVelocity)
            playerPhysics.velocity = (new Vector3(0, maximumDownVelocity, 0));
        if (playerPhysics.velocity.y > maximumUpVelocity)
            playerPhysics.velocity = (new Vector3(0, maximumUpVelocity, 0));
    }

    void handlePipes()
    {
        lastRespawnInMS += Time.deltaTime;
        if (lastRespawnInMS < respawnTime)
            return;

        pipeGenerator.SpawnPipe();
        lastRespawnInMS = 0f;
    }
}
