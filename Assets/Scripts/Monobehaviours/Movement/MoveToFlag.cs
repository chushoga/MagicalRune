using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToFlag : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator RemoveFlag(GameObject gm, Vector3 endPoint)
	{

		GameObject flag = gm;

		// first find any movetoflags and remove them.
		GameObject removeGm = GameObject.Find("MoveToFlag");
		if(removeGm == true){
			Debug.Log("found");
			Destroy(removeGm);
		} else {
			Debug.Log("not found");
		}

		// spawn flag here then removit it when it reaches destination
		Quaternion spawnRotation = Quaternion.identity;
		flag = Instantiate(flag, endPoint, spawnRotation);

		SpriteRenderer sr = flag.GetComponent<SpriteRenderer>();

		for(var n = 0; n < 3; n++)
		{
			//sr.color = new Color (255,0,0);
			sr.enabled = true;
			yield return new WaitForSeconds(.1f);
			sr.enabled = false;
			yield return new WaitForSeconds(.1f);
		}
		sr.enabled = true;
		//sr.color = new Color (255,255,255);
		Destroy(flag);
	}
}
