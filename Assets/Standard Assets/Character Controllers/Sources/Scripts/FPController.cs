using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class FPController : MonoBehaviour {
	public float speed = 5;
	private float originalSpeeed;
	public float sprintSpeed = 15;
	public static float mouseSensitivity = 5;
	//public float upDownRange = 60;
	float verticalRotation = 0;
	public float upDownRange = 60;
	float verticalVelocity = 0;
	public float jumpSpeed = 5;
	CharacterController cc;
	private Vector3 idleAcceleration;
	// Use this for initialization
	void Start () {
		idleAcceleration = new Vector3 (0, 0, 0);
		originalSpeeed = speed;
		//Screen.lockCursor = true;
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		//rotation

		//float rotX = Input.GetAxis("Mouse X") * mouseSensitivity;
		//float rotY = Input.GetAxis("Mouse Y");
		//transform.Rotate(new Vector3(0,rotX,0));

		//verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		//verticalRotation = Mathf.Clamp(verticalRotation,-upDownRange,upDownRange);
		//Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(verticalRotation,0,0));
		
		

		//movement

		float forwardSpeed = -(Input.acceleration.z - idleAcceleration.z ) * speed;//Input.GetAxis("Vertical") * speed;
		float sideSpeed = (Input.acceleration.x - idleAcceleration.x) * speed;//Input.GetAxis("Horizontal") * speed;

		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		if(Input.GetButtonDown("Jump") && cc.isGrounded){
			verticalVelocity = jumpSpeed;

		}

		Vector3 rotSpeed = new Vector3(sideSpeed ,verticalVelocity ,forwardSpeed);

		rotSpeed = transform.rotation * rotSpeed;



		cc.Move(rotSpeed * Time.deltaTime);
		//cc.SimpleMove(rotSpeed);




	}
	public void Calibrate(){
		idleAcceleration = Input.acceleration;
	
	}
	public void SetMouseSpeed(float speed){
		mouseSensitivity = speed;

	}

}
