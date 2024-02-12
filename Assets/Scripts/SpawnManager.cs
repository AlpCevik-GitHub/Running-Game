 
    using UnityEngine;
  

    public class SpawnManager : MonoBehaviour
    {
        public GameObject obstaclePrefab;
        public GameObject pickUpPrefab;
   
        private float startDelay = 0.3f;
        private PlayerController playerController;
        public TimerController timerController; 
        private Vector3 spawnPos;
    


        // Start is called before the first frame update
        void Start()
        {


            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            InvokeRepeating("SpawnObstacle", startDelay, 0.8f);
           
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void SpawnObstacle()
        {
       
            spawnPos = new Vector3(Random.Range(-4, 2), 0.0f, 0);
            GameObject pooledObstacle = ObjectPooler.SharedInstance.GetPooledObject();

            if (playerController.gameOver == false && timerController.timer != 0)
            {
                pooledObstacle.transform.position = spawnPos;
                pooledObstacle.SetActive(true);
                Instantiate(pickUpPrefab, new Vector3(spawnPos.x, spawnPos.y + 2.1f, spawnPos.z), pickUpPrefab.transform.rotation);
            }


        }

  
    }
