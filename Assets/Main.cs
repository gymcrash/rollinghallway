using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public List<Transform> hallwayPrefabs;
    public Transform player;

    public Transform lastDoorBillboard;

    private List<Transform> hallways = new List<Transform>();
    private int playerHallwayIndex = 0;
    private const int MAX_HALLWAYS = 3;
    private const float MAX_Z_BOUND = 21f;
    private const float MIN_Z_BOUND = 0f;
    private const float HALLWAY_LENGTH = 20f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < hallwayPrefabs.Count; i++)
        {
            this.hallways.Add(GameObject.Instantiate(this.hallwayPrefabs[i], new Vector3(0, 0, HALLWAY_LENGTH * i), Quaternion.identity));
        }
        this.player.position = new Vector3(2f, 2f, 0);
        this.lastDoorBillboard.position = new Vector3(2f, 1.5f, HALLWAY_LENGTH * MAX_HALLWAYS);
        this.setupHallways();
    }



    private void setupHallways()
    {
        this.hideAllHallways();
        for (int i = 0; i < MAX_HALLWAYS; i++)
        {
            hallways[(this.playerHallwayIndex + i) % this.hallways.Count].gameObject.SetActive(true);
            hallways[(this.playerHallwayIndex + i) % this.hallways.Count].position = new Vector3(0, 0, HALLWAY_LENGTH * i);
        }
        hallways[(this.playerHallwayIndex + (this.hallways.Count - 1)) % this.hallways.Count].gameObject.SetActive(true);
        hallways[(this.playerHallwayIndex + (this.hallways.Count - 1)) % this.hallways.Count].position = new Vector3(0, 0, -HALLWAY_LENGTH);

    }
    private void hideAllHallways()
    {
        for (int i = 0; i < hallways.Count; i++)
        {
            hallways[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.handleInfiniteHallway();
    }

    private void handleInfiniteHallway()
    {
        if (this.isPlayerOutOfBounds())
        {
            float posZmod = HALLWAY_LENGTH;
            if (this.player.position.z > MAX_Z_BOUND)
            {
                this.playerHallwayIndex = (this.playerHallwayIndex + 1) % this.hallways.Count;
                posZmod *= -1;
            }
            else
            {
                this.playerHallwayIndex = (this.playerHallwayIndex > 0) ? (this.playerHallwayIndex - 1) % this.hallways.Count : this.hallways.Count - 1;
            }
            this.player.position = new Vector3(this.player.position.x, this.player.position.y, this.player.position.z + posZmod);
            this.setupHallways();
        }

    }

    private bool isPlayerOutOfBounds()
    {
        return this.player.position.z > MAX_Z_BOUND || this.player.position.z < MIN_Z_BOUND;
    }
}
