using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazard;
	public Vector3 spawnValues;

	private Vector3 testSpawnValues;

    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public static int score; // set score

	public Text healthText; // temp....
	public static int playerHealth; // player health
	public static int playerMaxHealth;


	// Use this for initialization
	void Start () {

		// Get screen size
		Vector3 myScreen = new Vector3(Screen.width,Screen.height,0);

		// Convert screen size to world size
		Vector3 myWorld = Camera.main.ScreenToWorldPoint(myScreen);

		// set the spawn width and height
		spawnValues.x = myWorld.x - 0.5f;
		spawnValues.y = (myWorld.y) + 0.5f;
		// -------------------------------------------------------------------------------------------------------------------------------------

		score = 0; // start the core at 0
		playerHealth = 100; // health starting at this.
		playerMaxHealth = playerHealth;
        UpdateScore();
        StartCoroutine(SpawnWaves());
	}

    void Update()
    {
		UpdateScore ();
    }

	// TODO: Add a Spawn Pickups Coroutine to handle Pickups. For now they are mixed into the drops.
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for(int i = 0; i < hazardCount; i++)
            {
				// TODO function to randomize the drops depending on level and time etc.
				// for now just going to select random.

				int rnd = Random.Range(0, hazard.Length);
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;

				// check if allready occupied include only layer 10 (happends to be Drops)
				bool isOccupied = Physics2D.OverlapCircle(spawnPosition, 1f, 10);

				// if the space is not occupied then you can spawn.
				if (isOccupied == false){
					Instantiate(hazard[rnd], spawnPosition, spawnRotation);
				}
				yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }        
    }
	
	// Update is called once per frame
	void UpdateScore () {
		
        scoreText.text = "" + score;
		healthText.text = "" + playerHealth;

	}
}
