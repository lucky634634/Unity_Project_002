using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        if (score > GameManager.highsScore)
        {
            GameManager.highsScore = score;
        }
    }
}
