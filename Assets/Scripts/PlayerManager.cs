using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
    public float speed = 1f;
    private Vector2 speedVector = new Vector2(1f, 0f);

    //The position you clicked
    public Vector2 targetPosition;
    //That position relative to the players current position (what direction and how far did you click?)
    public Vector2 relativePosition;

    // 2 - Store the movement
    private Vector2 movement;

    private Vector2 touchOrigin = -Vector2.one; //Used to store location of screen touch origin for mobile controls.


    void Start()
    {

		#if UNITY_EDITOR
		Debug.Log("Unity Editor");
		#endif

		#if UNITY_IOS
		Debug.Log("Iphone");
		#endif

		#if UNITY_STANDALONE_OSX
		Debug.Log("Stand Alone OSX");
		#endif

		#if UNITY_STANDALONE_WIN
		Debug.Log("Stand Alone Windows");
		#endif

        speedVector.x = speed;
    }

    void Update()
    {

        // check if we are running either in the Unity editor aor a standalone build

		#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR

		Debug.Log("standAlone");
        // 3 - Retrieve the mouse position
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //4 - Find the relative poistion of the target based upon the current position
        // Update each frame to account for any movement
		relativePosition = new Vector2(targetPosition.x - gameObject.transform.position.x, gameObject.transform.position.y);

		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

        // Check if Input has registered more than zero touches
        if (Input.touchCount > 0)
	    {
			
            //Store the first touch detected.
            Touch myTouch = Input.touches[0];
            
            //Check if the phase of that touch equals Began
            if (myTouch.phase == TouchPhase.Began)
            {
                //If so, set touchOrigin to the position of that touch
				targetPosition = myTouch.position;
               
            }
			relativePosition = new Vector2(targetPosition.x - gameObject.transform.position.x, gameObject.transform.position.y);
        }

		#endif //End of mobile platform dependendent compilation section started above with #elif

    }

    void FixedUpdate()
    {
        // 5 - If you are about to overshoot the target, reduce velocity to that distance
        //      Else cap the Movement by a maximum speed per direction (x then y)

        if (speedVector.x * Time.deltaTime >= Mathf.Abs(relativePosition.x))
        {
            movement.x = relativePosition.x;
        }
        else
        {
            movement.x = speedVector.x * Mathf.Sign(relativePosition.x);
        }
       
        // 6 - Move the game object using the physics engine
        GetComponent<Rigidbody2D>().velocity = movement;

    }
}