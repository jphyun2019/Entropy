
using UnityEngine;
using System.Collections;

public class CameraScr : MonoBehaviour
{

	// Class Variables

	public Transform target;
	public Player player;

	public float distance;
	public float height;
	public float heightDamping;
	public float rotationDamping;

	public Camera cam;
	public float fov;
	public meteor meteor1;
	public meteor meteor2;



    private void Start()
    {
		fov = 60;
    }



    // Called after every frame
    void LateUpdate()
	{
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;

		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;


		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

		transform.LookAt(target);

		cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, 0.01f);




	}

	public void check()
    {
		height = 10;
		distance = 10;
		heightDamping = 30f;
		fov = 30;
		
    }
	public void unCheck()
    {
		height = 5;
		distance = 12;
		heightDamping = 20f;
		fov = 60;

    }

	


}