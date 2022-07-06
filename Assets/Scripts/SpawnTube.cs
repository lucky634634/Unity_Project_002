using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTube : MonoBehaviour
{
    [Header("Tube")]
    public GameObject tubePrefab;
    public GameObject endPoint;
    public float timeToSpawn;
    public float distanceBetween;
    public float tubeStartSpeed;
    public float tubeAcceleration;
    public int tubesSpeedUp;

    [Header("Environment")]
    public GameObject sky;
    public GameObject ground;

    public GameObject player;
    public GameController gameController;

    private float timeSpawnCountDown;
    private int tubeCountDown;
    private float tubeSpeed;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        float screenWidth = cam.orthographicSize * cam.pixelWidth / cam.pixelHeight;
        transform.position = new Vector3(screenWidth + 1f, 0f, 0f);
        endPoint.transform.position = new Vector3(-screenWidth - 1f, 0f, 0f);
        sky.transform.localScale = new Vector3(screenWidth * 2f, 1f, 1f);
        ground.transform.localScale = new Vector3(screenWidth * 2f, 1f, 1f);
    }

    private void Start()
    {
        timeSpawnCountDown = 0f;
        tubeCountDown = tubesSpeedUp;
        tubeSpeed = tubeStartSpeed;
    }

    private void Update()
    {
        if (!player.GetComponent<PlayerController>().isDead)
        {
            timeSpawnCountDown -= Time.deltaTime;
            if (timeSpawnCountDown <= 0)
            {
                Spawn();
                tubeCountDown--;
                if (tubeCountDown <= 0)
                {
                    tubeCountDown = tubesSpeedUp;
                    tubeSpeed += tubeAcceleration;
                }
                timeSpawnCountDown = timeToSpawn;
            }
        }
    }

    void Spawn()
    {
        Tube tube = Instantiate(tubePrefab, transform.position, transform.rotation).GetComponent<Tube>();
        tube.player = player;
        tube.gameController = gameController;
        tube.endPoint = endPoint.transform;
        tube.upperTubeHeight = Random.Range(2f, tube.gameHeight - distanceBetween - 2f);
        tube.lowerTubeHeight = tube.gameHeight - tube.upperTubeHeight - distanceBetween;
        tube.speed = tubeSpeed;
    }
}
