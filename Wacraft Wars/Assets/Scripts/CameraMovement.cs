using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
/*	public GameObject HighLHex;
	Vector3 HPos;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		HPos = HighLHex.transform.position;

		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			transform.RotateAround(HPos, Vector3.up, 60);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			transform.RotateAround(HPos, Vector3.down, 60);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			transform.RotateAround(HPos, Vector3.right, 10);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			transform.RotateAround(HPos, Vector3.left, 10);
		}*/

			public Transform target;
			public float distance = 5.0f;
			public float xSpeed = 120.0f;
			public float ySpeed = 120.0f;
			
			public float yMinLimit = -20f;
			public float yMaxLimit = 80f;
			
			public float distanceMin = .5f;
			public float distanceMax = 15f;
			
			public float smoothTime = 2f;
			
			float rotationYAxis = 0.0f;
			float rotationXAxis = 0.0f;
			
			float velocityX = 0.0f;
			float velocityY = 0.0f;
			
			// Use this for initialization
			void Start()
			{
				Vector3 angles = transform.eulerAngles;
				rotationYAxis = angles.y;
				rotationXAxis = angles.x;
				
/*				// Make the rigid body not change rotation
				if (rigidbody)
				{
					Rigidbody.freezeRotation = true;
				}*/
			}
			
			void LateUpdate()
			{
				if (target)
				{
					if (Input.GetMouseButton(1))
					{
						velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
						velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
					}
					
					rotationYAxis += velocityX;
					rotationXAxis -= velocityY;
					
					rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
					
					Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
					Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
					Quaternion rotation = toRotation;
					
					distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
					
					RaycastHit hit;
					if (Physics.Linecast(target.position, transform.position, out hit))
					{
						distance = hit.distance - .05f;
					}
					Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
					Vector3 position = rotation * negDistance + target.position;
					
					transform.rotation = rotation;
					transform.position = position;
					
					velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
					velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
				}
				
			}
			
			public static float ClampAngle(float angle, float min, float max)
			{
				if (angle < -360F)
					angle += 360F;
				if (angle > 360F)
					angle -= 360F;
				return Mathf.Clamp(angle, min, max);
			}
}
