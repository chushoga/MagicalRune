using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazard;
	public Vector3 spawnValues;

	private float screenWidth;
	private float screenHeight;

	private Vector3 testSpawnValues;

    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public static int score; // set score

	// Use this for initialization
	void Start () {
		// get the screen width and height
		screenWidth = Screen.width;
		screenHeight = Screen.height;


		Vector3 playerPosScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2 + 7, Screen.height/2, Camera.main.nearClipPlane +5));
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate(hazard[1], playerPosScreen, spawnRotation);
		Debug.Log(playerPosScreen);
		// set the spawn area

        score = 0; // start the core at 0
        UpdateScore();
        StartCoroutine(SpawnWaves());
	}

    void Update()
    {
        UpdateScore();
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
                Instantiate(hazard[rnd], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }        
    }
	
	// Update is called once per frame
	void UpdateScore () {
        scoreText.text = "" + score;
	}
}
