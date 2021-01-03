using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    GameObject playerModel;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        playerModel = gameObject.transform.GetChild(0).gameObject;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerModel.transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 3);
    }
}
