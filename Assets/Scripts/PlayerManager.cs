using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
	private SpriteRenderer sr;

    void Start()
    {
		sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
    }

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log ("error");
		// ENEMY minus score if hits player
		if (coll.gameObject.tag == "Enemy") {
			
			StartCoroutine (ShowDamage(sr));
		} 
	}

	IEnumerator ShowDamage(SpriteRenderer sr){
		Debug.Log ("started");
		//yield return new WaitForSeconds (5);
		for(var n = 0; n < 5; n++)
		{
			sr.color = new Color (255,0,0);
			sr.enabled = true;
			yield return new WaitForSeconds(.1f);
			sr.enabled = false;
			yield return new WaitForSeconds(.1f);
		}
		sr.enabled = true;
		sr.color = new Color (255,255,255);

	}
    
}