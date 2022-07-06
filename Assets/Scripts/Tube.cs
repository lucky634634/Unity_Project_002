using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public Transform endPoint;
    public float lowerTubeHeight;
    public float upperTubeHeight;
    public float gameHeight;
    public GameObject upperTube;
    public GameObject lowerTube;
    public float speed;

    public GameObject player;
    public GameController gameController;

    private bool isAlreadyThrought;

    private void Start()
    {
        isAlreadyThrought = false;
    }

    private void Update()
    {
        SetHeight();
        if (!player.GetComponent<PlayerController>().isDead)
        {
            MoveTube();
            OverTube();
        }
        DestroyTube();
    }

    private void MoveTube()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
    }

    private void SetHeight()
    {
        upperTube.transform.localScale = new Vector3(upperTube.transform.localScale.x, upperTubeHeight, upperTube.transform.localScale.z);
        upperTube.transform.localPosition = new Vector3(0f, (gameHeight - upperTubeHeight) / 2f, 0f);

        lowerTube.transform.localScale = new Vector3(lowerTube.transform.localScale.x, lowerTubeHeight, lowerTube.transform.localScale.z);
        lowerTube.transform.localPosition = new Vector3(0f, -(gameHeight - lowerTubeHeight) / 2f, 0f);
    }

    private void DestroyTube()
    {
        if (Vector2.Distance(transform.position, endPoint.position) <= 0.01f)
        {
            Destroy(gameObject);
        }
    }

    private void OverTube()
    {
        if (player.transform.position.x >= transform.position.x - transform.localScale.x / 2f && player.transform.position.x <= transform.position.x + transform.localScale.x / 2f && !isAlreadyThrought)
        {
            gameController.score++;
            isAlreadyThrought = true;
        }
    }
}
