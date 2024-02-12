using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    public float timer = 60f;
    public bool isTimerRunning = true;
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                playerController.gameOver = true;
                playerController.playerAnim.SetBool("Death_b", true);
                playerController.playerAnim.SetInteger("DeathType_int", 1);
                playerController.dirtSplatter.Stop();
                playerController.playerAudio.PlayOneShot(playerController.crashSound, 1.0f);
                playerController.GameOver();
            }
            

        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(0);
        int seconds = Mathf.FloorToInt(timer % 60);
        int milliseconds = Mathf.FloorToInt((timer * 1000) % 1000);
        if(timer > 0)
        {
            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }
        else
        {
            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", 0, 0, 0);
        }
        
    }
}
