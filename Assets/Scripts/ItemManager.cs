using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	public GameObject explosionPart;
    public float fallSpeed = 1f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.position -= Vector3.up * fallSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {        
        if (coll.gameObject.tag == "Player")
        {
            GameController.score += 1;
            // TODO: Instantiate a partical effect
            Destroy(this.gameObject);
        }

		if (coll.gameObject.tag == "OutOfBounds")
		{
			GameController.score -= 1;

			Instantiate(explosionPart, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
    }
}
