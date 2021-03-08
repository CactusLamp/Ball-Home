using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public Transform crossSpawner;
    public GameObject cross;

    public GameObject platformSpawner;
    public GameObject platformSpawner1;
    public GameObject platform;

    public Text home;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void spawnText()
    {
        home.text = "Welcome Home!";
    }

    public void spawnCross()
    {
        Instantiate(cross, crossSpawner.transform.position, Quaternion.identity);
    }

    public void spawnPlatform()
    {
        Instantiate(platform, platformSpawner.transform.position, Quaternion.Euler(0f, 0f, 90f));
        Instantiate(platform, platformSpawner1.transform.position, Quaternion.Euler(0f, 0f, 90f));

    }
}
