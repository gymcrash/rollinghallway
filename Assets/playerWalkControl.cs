using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkControl : MonoBehaviour
{

    private float horizontalSpeed = 2.0f;
    private float verticalSpeed = 2.0f;
    private List<Vector3> positionHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        this.handleWalking();
        this.handleLooking();
    }

    private void handleWalking()
    {
        if (UnityEngine.Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, 0, 0.1f);
            this.stabalisePositionAndRecordHistory();
        }
        else if (UnityEngine.Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, 0, -0.025f);
            this.stabalisePositionAndRecordHistory();
        }

    }

    private void stabalisePositionAndRecordHistory()
    {
        this.transform.position = new Vector3(this.transform.position.x, 2f, this.transform.position.z);
        this.positionHistory.Add(this.transform.position);
        if (this.positionHistory.Count > 30)
        {
            this.positionHistory = this.positionHistory.GetRange(1, this.positionHistory.Count - 2);
        }
    }
    private void handleLooking()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = -verticalSpeed * Input.GetAxis("Mouse Y");
        float x = transform.rotation.eulerAngles.x + v;
        float y = transform.rotation.eulerAngles.y + h;
        Vector3 rotation = new Vector3(
            ((x > 340f || (x < 20f && x > -20f))) ? x : transform.rotation.eulerAngles.x,
            y,
            transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(rotation);
    }

    void OnTriggerStay(Collider col)
    {
        this.rewindMovementToEscapeCollision(col);
    }

    void OnTriggerEnter(Collider col)
    {
        this.rewindMovementToEscapeCollision(col);
    }

    void OnTriggerExit(Collider col)
    {
        this.rewindMovementToEscapeCollision(col);
    }

    private void rewindMovementToEscapeCollision(Collider col)
    {
        while (col.bounds.Intersects(this.GetComponent<Collider>().bounds) && this.positionHistory.Count > 1)
        {
            this.transform.position = this.positionHistory[this.positionHistory.Count - 1];
            Physics.SyncTransforms();
            this.positionHistory = this.positionHistory.GetRange(0, this.positionHistory.Count - 2);
        }
    }
}
