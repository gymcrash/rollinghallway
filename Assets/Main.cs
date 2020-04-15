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
    // Start is called before the first frame update
    void Start()
    {
        // this.hallway1 = GameObject.Instantiate(this.hallwayPrefab1, new Vector3(0, 0, 0), Quaternion.identity);
        // this.hallway2 = GameObject.Instantiate(this.hallwayPrefab2, new Vector3(0, 0, 20f), Quaternion.identity);
        for (int i = 0; i < hallwayPrefabs.Count; i++)
        {
            this.hallways.Add(GameObject.Instantiate(this.hallwayPrefabs[i], new Vector3(0, 0, 20f * i), Quaternion.identity));
        }
        this.player.position = new Vector3(2f, 2f, 0);
        this.lastDoorBillboard.position = new Vector3(2f, 1.5f, 20f * MAX_HALLWAYS);
        this.setupHallways();
    }



    private void setupHallways()
    {
        this.hideAllHallways();
        for (int i = 0; i < MAX_HALLWAYS; i++)
        {
            hallways[(this.playerHallwayIndex + i) % this.hallways.Count].gameObject.SetActive(true);
            hallways[(this.playerHallwayIndex + i) % this.hallways.Count].position = new Vector3(0, 0, 20f * i);
        }
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
        if (this.player.position.z > 21f)
        {
            this.playerHallwayIndex = (this.playerHallwayIndex + 1) % this.hallways.Count;
            this.player.position = new Vector3(this.player.position.x, this.player.position.y, this.player.position.z - 20f);
            this.setupHallways();
        }
    }
}
