using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class playerController : MonoBehaviour
{
	private gridManager grid;
	private UI_inGame _ui_inGame;
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
	[SerializeField] private GameObject[] objectsSpawnables = new GameObject[5];
	[SerializeField] private GameObject[] ghostSpawnables = new GameObject[5];
	[SerializeField] private Material ghostMat;

	private Vector3 velocity;
	private int objectSelectorIndex = 1;
	private bool selectorLock = false;
	private GameObject objectToSpawn;
	private GameObject ghostToSpawn;
	private GameObject objectSpawned;
	private GameObject ghostSpawnedObject;
	private bool canPlaceObject = true;
	private bool ghostSpawned = false;
	private float lastTimeCalled;
	private bool flipFlopGhost = false;
	private Vector3 cacheSpawnPosition;
	private List<Vector3> __caches = new List<Vector3>();


	void Start() 
	{
		lastTimeCalled = Time.time;
		grid = GameObject.Find("grid").GetComponent<gridManager>();
		movementController = GetComponent<CharacterController>();  
		_ui_inGame = GameObject.Find("UI_inGame").GetComponent<UI_inGame>();
		playerCamera = GetComponentInChildren<Camera>();          
		objectToSpawn = objectsSpawnables[0]; 
		ghostToSpawn = ghostSpawnables[0]; 

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

		yaw += Input.GetAxisRaw("Mouse X") * LookSensitivity;
		pitch -= Input.GetAxisRaw("Mouse Y") * LookSensitivity;

		yaw = ClampAngle(yaw, MinYaw, MaxYaw);
		pitch = ClampAngle(pitch, MinPitch, MaxPitch);

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);




		if(ghostSpawned)
		{
			if(objectToSpawn.name == "baseCubeSpawner" || objectToSpawn.name == "piston")
			{
				ghostSpawnedObject.transform.position = grid.getCurrentPositionByCell(checkPositionToSpawn() + new Vector3(0,1,0));
			}
			 if(objectToSpawn.name != "baseCubeSpawner" && objectToSpawn.name != "piston")
			 {
			 	ghostSpawnedObject.transform.position = grid.getCurrentPositionByCell(checkPositionToSpawn());
			 }
			
		}
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
		Time.timeScale = 1;
		playerCamera.gameObject.SetActive(isControlling);

		// Cursor.lockState = (isControlling) ? CursorLockMode.Locked : CursorLockMode.None;
		// Cursor.visible = !isControlling;
        Cursor.visible = false;
		Screen.lockCursor = true; 

	}
	
	
IEnumerator lockSelectorCoroutine() 
{
    while(true)
    {
        yield return new WaitForSeconds(0.4f);
		selectorLock = false;
		StopCoroutine(lockSelectorCoroutine());
	}
}

	private void changeSelectedObject()
	{
		selectorLock = true;
		StartCoroutine(lockSelectorCoroutine());

		switch(objectSelectorIndex)
		{
			//conveyor
			case 1: GameObject.Find("Image_selectedObjectBorder").transform.localPosition = new Vector3(-250,GameObject.Find("Image_selectedObjectBorder").transform.localPosition.y,0);
			objectToSpawn = objectsSpawnables[0];
			ghostToSpawn = ghostSpawnables[0];
			break;

			//validator
			case 2: GameObject.Find("Image_selectedObjectBorder").transform.localPosition = new Vector3(-125,GameObject.Find("Image_selectedObjectBorder").transform.localPosition.y,0);
			objectToSpawn = objectsSpawnables[1];
			ghostToSpawn = ghostSpawnables[1];
			break;

			//piston
			case 3: GameObject.Find("Image_selectedObjectBorder").transform.localPosition = new Vector3(0,GameObject.Find("Image_selectedObjectBorder").transform.localPosition.y,0);
			objectToSpawn = objectsSpawnables[2];
			ghostToSpawn = ghostSpawnables[2];
			break;

			//fusion
			case 4: GameObject.Find("Image_selectedObjectBorder").transform.localPosition = new Vector3(125,GameObject.Find("Image_selectedObjectBorder").transform.localPosition.y,0);
			objectToSpawn = objectsSpawnables[3];
			ghostToSpawn = ghostSpawnables[3];
			break;

			//spawners
			case 5: GameObject.Find("Image_selectedObjectBorder").transform.localPosition = new Vector3(250,GameObject.Find("Image_selectedObjectBorder").transform.localPosition.y,0);
			objectToSpawn = objectsSpawnables[4];
			ghostToSpawn = ghostSpawnables[4];
			break;
		}
		
	}

	public void PlaceObject()
    {
		if (Time.time - lastTimeCalled > 0.2f)
        {
		if(SceneManager.GetActiveScene().name == "mapLibre")
		{
		spawnGhost();
		}
		lastTimeCalled = Time.time;
		}		
    }

	public void rotateObject()
    {
		if(ghostSpawned && Time.time - lastTimeCalled > 0.2f)
		{
			lastTimeCalled = Time.time;
			switch(ghostSpawnedObject.transform.eulerAngles.y)
		{
			case 0: ghostSpawnedObject.transform.eulerAngles = new Vector3(0,90,0);
			break;
			case 90: ghostSpawnedObject.transform.eulerAngles = new Vector3(0,180,0);
			break;
			case 180: ghostSpawnedObject.transform.eulerAngles = new Vector3(0,270,0);
			break;
			case 270: ghostSpawnedObject.transform.eulerAngles = new Vector3(0,0,0);
			break;
		}  
		}
    }

	public void destroyObject()
    {
		if(grid.checkCellBusyObject(checkPositionToSpawn()) != null)
		{
		// Debug.Log(grid.checkCellBusyObject(checkPositionToSpawn()).tag);
		// 	if(grid.checkCellBusyObject(checkPositionToSpawn()).tag != "sol")
		// 	{
				if(grid.checkCellBusyObject(checkPositionToSpawn()).tag == "conveyor")
				{
		// 			Destroy(grid.checkCellBusyObject(checkPositionToSpawn()).gameObject);
		// 		}
		// 		else
		// 		{
					if(grid.checkCellBusyObject(checkPositionToSpawn()).GetComponent<tapisRoulant>().conveyorActive)
					{
					grid.checkCellBusyObject(checkPositionToSpawn()).GetComponent<tapisRoulant>().flipFlopActive(false);
					}
					else
					{
						Debug.Log("trueeeeeeeeeeeeeee");
					grid.checkCellBusyObject(checkPositionToSpawn()).GetComponent<tapisRoulant>().flipFlopActive(true);
					}
		 		}
		// 	}	
		}
    }

    public void NextObject()
    {	
		if(SceneManager.GetActiveScene().name == "mapLibre")
		{
		if(selectorLock == false && ghostSpawned == false)
		{
			if(objectSelectorIndex < 5)
			{
			objectSelectorIndex ++;
			changeSelectedObject();
			}
			else
			{
			objectSelectorIndex = 1;
			changeSelectedObject();
			}
		}
		}
		
    }

    public void PreviousObject()
    {
		if(SceneManager.GetActiveScene().name == "mapLibre")
		{
		if(selectorLock == false && ghostSpawned == false)
		{
			if(objectSelectorIndex > 1)
			{
			objectSelectorIndex --;
			changeSelectedObject();
			}
			else
			{
			objectSelectorIndex = 5;
			changeSelectedObject();
			}
		}
		}
    }

	public void timeSpeedAdd()
    {
		if(Time.timeScale < 10)
		{
		Time.timeScale ++;
		_ui_inGame.updateTimeSpeedSlider((int)Time.timeScale);
		}

	//	Debug.Log("dfsdsfdfs");
    }

	public void timeSpeedRem()
    {
		if(Time.timeScale > 1)
		{
			Time.timeScale --;
			_ui_inGame.updateTimeSpeedSlider((int)Time.timeScale);
		}
    }

	private void spawnGhost()
	{

			if(flipFlopGhost == false)
			{
			if(ghostToSpawn.name == "baseCubeSpawner" || ghostToSpawn.name == "piston")
			{
				ghostSpawnedObject = Instantiate(ghostToSpawn, grid.getCurrentPositionByCell(checkPositionToSpawn() + new Vector3(0,1,0)), Quaternion.identity);
				cacheSpawnPosition = checkPositionToSpawn() + new Vector3(0,1,0);
			}
			else
			{
				ghostSpawnedObject = Instantiate(ghostToSpawn, grid.getCurrentPositionByCell(checkPositionToSpawn()), Quaternion.identity);
				cacheSpawnPosition = checkPositionToSpawn();
			}
			ghostSpawned = true;
			flipFlopGhost = true;
			}
			else
			{
			flipFlopGhost = false;
			ghostSpawned = false;
			spawnObject();
			Destroy(ghostSpawnedObject);	
			
			}


    }


	private void spawnObject()
	{
		Vector3 point = checkPositionToSpawn();
		Vector3 sizeInGrid = objectToSpawn.transform.GetChild(0).transform.localScale;
		canPlaceObject = true;

 		for (int x = 0; x < sizeInGrid.x; x++)
        {
            for (int y = 0; y < sizeInGrid.y; y++)
            {
                for (int z = 0; z < sizeInGrid.z; z++)
                {
                    Vector3 curentCell = new Vector3(point.x + x, point.y + y, point.z + z);
					if(grid.checkCellBusy(curentCell) == gridManager.cellBusyState.Collider || curentCell == new Vector3(0,0,0))
					{
						canPlaceObject = false;
					}
                }
            }
        }

		if(canPlaceObject == true || objectToSpawn.name == "cubesFusion")
		{
		if(objectToSpawn.name == "baseCubeSpawner" || objectToSpawn.name == "piston")
		{
			objectSpawned = Instantiate(objectToSpawn, grid.getCurrentPositionByCell(checkPositionToSpawn() + new Vector3(0,1,0)), ghostSpawnedObject.transform.rotation);
		}
		if(objectToSpawn.name != "baseCubeSpawner" && objectToSpawn.name != "piston")
		{
			if(objectToSpawn.name == "cubesFusion")
			{
				if(grid.checkCellBusyObject(checkPositionToSpawn()) != null)
				{
				if(grid.checkCellBusyObject(checkPositionToSpawn()).name != "piston" || grid.checkCellBusyObject(checkPositionToSpawn()).name != "baseCubeSpawner")
				{
					 objectSpawned = Instantiate(objectToSpawn, grid.getCurrentPositionByCell(checkPositionToSpawn()), ghostSpawnedObject.transform.rotation);
				}
				}
				else
				{
					 objectSpawned = Instantiate(objectToSpawn, grid.getCurrentPositionByCell(checkPositionToSpawn()), ghostSpawnedObject.transform.rotation);
				}

			}
			else
			{
			 objectSpawned = Instantiate(objectToSpawn, grid.getCurrentPositionByCell(checkPositionToSpawn()), ghostSpawnedObject.transform.rotation);
			}
		}
		}
	}

	private Vector3 checkPositionToSpawn()
	{
        Vector3 rayDirection = playerCamera.transform.forward;
        RaycastHit hit;
        float maxRaycastDistance = 100f;
        if (Physics.Raycast(playerCamera.transform.position, rayDirection, out hit, maxRaycastDistance))
        {
			return grid.getCurrentCellByPosition(hit.point);
        }
        else
        {
            return new Vector3(0,0,0);
        }
	}

	public void goMainMenu()
	{
    SceneManager.LoadScene("mainMenu");
	}
	// private Vector3 checkPositionToRay()
	// {
    //     Vector3 rayDirection = playerCamera.transform.forward;
    //     RaycastHit hit;
    //     float maxRaycastDistance = 100f;
    //     if (Physics.Raycast(playerCamera.transform.position, rayDirection, out hit, maxRaycastDistance))
    //     {
	// 		return hit.point;
    //     }
    //     else
    //     {
    //         return new Vector3(0,0,0);
    //     }
	// }
	


}