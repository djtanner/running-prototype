using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(20,0,0);
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 3, 3);

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle() {

        int prefabIndex = Random.Range(0, 4);

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab[prefabIndex], spawnPos, obstaclePrefab[prefabIndex].transform.rotation);
        }

    }


}
