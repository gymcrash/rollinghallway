using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWalkControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.position = (
                new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.05f));
        }
        else if (UnityEngine.Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.position = (
                new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.05f));
        }
    }
}
