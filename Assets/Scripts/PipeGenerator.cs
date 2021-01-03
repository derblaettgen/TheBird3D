using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeGenerator : MonoBehaviour
{
    public GameObject obstacle { private get; set; }
    public Transform origin { private get; set; }

    //private float respawnTime = 3.0f;
    private float pipeSpeed = -10.0f;

    //private float currentTime = 0f;
    private List<GameObject> pipeState = new List<GameObject>();

    //// Start is called before the first frame update
    //void Start()
    //{
    //    SpawnPipe();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    currentTime += Time.deltaTime;

    //    if (currentTime >= respawnTime)
    //        SpawnPipe();
    //}

    public void SpawnPipe()
    {
        //currentTime = 0;
        GameObject pipe = Instantiate(obstacle, origin);

        float verticalPosition = Random.Range(-4, 4);
        pipe.transform.position += new Vector3(0, verticalPosition, 0);

        pipe.GetComponent<Rigidbody>().velocity = new Vector3(pipeSpeed, 0, 0);

        pipeState.Add(pipe);
        if (pipeState.Count >= 10)
        {
            Destroy(pipeState[0]);
            pipeState.RemoveAt(0);
        }
    }
}
