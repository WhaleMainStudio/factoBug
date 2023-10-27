using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerController : MonoBehaviour
{
	public float MinYaw = -360;
	public float MaxYaw = 360;
	public float MinPitch = -60;
	public float MaxPitch = 60;
	public float LookSensitivity = 1;

	public float MoveSpeed = 10;
	public float SprintSpeed = 30;
	private float currMoveSpeed = 0;

	private CharacterController movementController;
	private Camera playerCamera;

	private bool isControlling;
	private float yaw;
	private float pitch;

	private Vector3 velocity;


	void Start() 
	{

		movementController = GetComponent<CharacterController>();  
		playerCamera = GetComponentInChildren<Camera>();           

		isControlling = true;
		ToggleControl();  
	}

	void Update() 
	{
		Vector3 direction = Vector3.zero;
		direction += transform.forward * Input.GetAxisRaw("Vertical");
		direction += transform.right * Input.GetAxisRaw("Horizontal");

		direction.Normalize();


		if (Input.GetKey(KeyCode.LeftShift)) 
		{  
			currMoveSpeed = SprintSpeed;
		} else 
		{
			currMoveSpeed = MoveSpeed;
		}

		direction += velocity * Time.deltaTime;
		movementController.Move(direction * Time.deltaTime * currMoveSpeed);

		// Camera Look
		yaw += Input.GetAxisRaw("Mouse X") * LookSensitivity;
		pitch -= Input.GetAxisRaw("Mouse Y") * LookSensitivity;

		yaw = ClampAngle(yaw, MinYaw, MaxYaw);
		pitch = ClampAngle(pitch, MinPitch, MaxPitch);

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
	}

	private float ClampAngle(float angle) 
	{
		return ClampAngle(angle, 0, 360);
	}

	private float ClampAngle(float angle, float min, float max) 
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;

		return Mathf.Clamp(angle, min, max);
	}

	private void ToggleControl() 
	{

		playerCamera.gameObject.SetActive(isControlling);

		#if UNITY_5
		Cursor.lockState = (isControlling) ? CursorLockMode.Locked : CursorLockMode.None;
		Cursor.visible = !isControlling;
		#else
		Screen.lockCursor = isControlling;
		#endif

	}

}