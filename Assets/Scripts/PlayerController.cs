
    using TMPro;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;


    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb ;
        public Animator playerAnim;
        public ParticleSystem explosionParticle;
        public ParticleSystem dirtSplatter;
        public AudioSource playerAudio;
        public AudioClip jumpSound;
        public AudioClip crashSound;
        public AudioClip pickSound;
        public float jumpForce = 11.4f;
        public float gravityModifier = 3.0f;
        public bool isOnGround = true;
        public bool gameOver = false;
        [SerializeField] float horizontalInput;
        [SerializeField] float speed = 10.0f;
        public GameObject leftBackground;
        public GameObject rightBackground;

        public TextMeshProUGUI scoreText;
        public Button backToMenu;
        public TextMeshProUGUI nameText;
        public GameObject GameOverText;
        public TextMeshProUGUI bestScoreText;
        private int Points = 0;

        public TimerController timerController;





    // Start is called before the first frame update
    void Start()
        {


            playerRb = GetComponent<Rigidbody>();
            playerAnim = GetComponent<Animator>();
            playerAudio = GetComponent<AudioSource>();
            leftBackground = GameObject.Find("BackgroundLeft");
            rightBackground = GameObject.Find("BackgroundRight");

            if (!DataHolder.Instance.verfiyModifier)
            {
                Physics.gravity *= gravityModifier;

            }


            backToMenu.interactable = false;
            backToMenu.gameObject.SetActive(false);

            if (DataHolder.Instance != null)
            {

                if (MenuUIHandler.playerName.Equals(DataHolder.Instance.playerName))
                {
                    nameText.SetText("Name: " + DataHolder.Instance.playerName);
                    bestScoreText.SetText("Best Score : " + DataHolder.Instance.bestScore+"pts");
                }
                else
                {
                    DataHolder.Instance.playerName = MenuUIHandler.playerName;
                    nameText.SetText("Name: " + DataHolder.Instance.playerName);
                    DataHolder.Instance.bestScore = 0;
                    bestScoreText.SetText("Best Score : " + DataHolder.Instance.bestScore+"pts");
                }




            }

        }

        // Update is called once per frame
        void Update()
        {


            horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);



            if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && !gameOver && timerController.timer != 0)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);


                isOnGround = false;
                playerAnim.SetTrigger("Jump_b");

                dirtSplatter.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }
            else if (gameOver)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    DataHolder.Instance.verfiyModifier = true;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }


        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
                dirtSplatter.Play();
            }
        else if (collision.gameObject.CompareTag("Obstacle"))
            {

                gameOver = true;
                
            
                explosionParticle.Play();
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
            
                dirtSplatter.Stop();
                playerAudio.PlayOneShot(crashSound, 1.0f);
                GameOver();

            } else if (collision.gameObject.CompareTag("PickUp"))
            {
                playerAudio.PlayOneShot(pickSound, 1.0f);
                AddPoint(10);
            }

        }

        void AddPoint(int point)
        {
            Points += point;
            scoreText.SetText("" + Points+"pts");



        }

        public void GameOver()
        {
            DataHolder.Instance.bestScore += Points;
            GameOverText.SetActive(true);
            backToMenu.interactable = true;
            backToMenu.gameObject.SetActive(true);
            timerController.isTimerRunning = false;
    }



    }
