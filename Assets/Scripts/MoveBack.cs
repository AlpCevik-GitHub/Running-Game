
    using UnityEngine;

    public class MoveBack : MonoBehaviour
    {

        [SerializeField] float speed = 15.0f;
        private PlayerController playerController;
        private TimerController timerController;

    // Start is called before the first frame update
    void Start()
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        timerController = GameObject.Find("Timer").GetComponent<TimerController>();
    }

        // Update is called once per frame
        void Update()
        {

            if(playerController.gameOver == false && timerController.timer != 0)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
       


        }
    }
