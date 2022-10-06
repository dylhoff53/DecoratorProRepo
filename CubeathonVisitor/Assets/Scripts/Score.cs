using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    public int playerScore;

    public float interval = 100f;
    public float current_interval = 100f;
    public float counter = 1f;
    public float current_position;

    public delegate void Milestone(float mark);
    public static event Milestone milestone;

    void Update()
    {
        scoreText.text = player.position.z.ToString("0");
        current_position = player.position.z;

        if (current_position > current_interval)
        {
            milestone(current_interval);
            current_interval += interval;
        }
    }
}
