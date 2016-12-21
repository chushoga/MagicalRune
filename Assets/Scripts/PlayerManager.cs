using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
    public float speed = 10f;    
	private float halfScreen; // half of the screen width
	private Vector3 clickPos; // clicked or touched position

    void Start()
    {
		/*
		#if UNITY_EDITOR
		Debug.Log("Unity Editor");
		#endif

		#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
		Debug.Log("MOBILE");
		#endif

		#if UNITY_STANDALONE_OSX
		Debug.Log("Stand Alone OSX");
		#endif

		#if UNITY_STANDALONE_WIN
		Debug.Log("Stand Alone Windows");
		#endif

		// set half screen
		halfScreen = Screen.width / 2;
		*/
    }

    void Update()
    {

        // check if we are running either in the Unity editor or a pc build

		#if UNITY_STANDALONE || UNITY_EDITOR 

        // 3 - Retrieve the mouse position
		if (Input.GetMouseButton(0))
        {
			clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // set click position

			//print("test" + halfScreen); // maybe dont need half the screen
			//print("mouse click pos: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));

			// check if greater thatn half the screen. move left if less than and right if greater than.
			if (clickPos.x < 1f){				
				gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
			}
			if (clickPos.x > 1f) {
				gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
			}
				
        }

		// check if mobile or not and if it is the use this input.
		// this checks IOS, ANDROID, and WINDOWS mobile OS type.
		#elif  UNITY_ANDROID || UNITY_IOS

        // Check if Input has registered more than zero touches

		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary){
			Vector2 touchPosition = Input.GetTouch(0).position;

			// Check if it is left or right and go in that direction
			if (touchPosition.x < 1f){
				gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
			} else if(touchPosition.x > 1f){
				gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
			}
		}

		#endif //End of mobile platform dependendent compilation section started above with #elif

    }
    
}