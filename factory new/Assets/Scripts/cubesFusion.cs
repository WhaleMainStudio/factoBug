using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class cubesFusion : MonoBehaviour
{
    private gridManager grid;
    private  Vector3 currentCell;
    private List<GameObject> cubesInZone = new List<GameObject>();
    private bool lockk = false;

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        currentCell = grid.getCurrentCellByPosition(this.transform.position);
        flipFlopActive(true);
    }


     private void flipFlopActive(bool active)
    {
        if(active)
        {
              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z, gridManager.cellBusyState.Fusion, this.gameObject);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z, gridManager.cellBusyState.Fusion, this.gameObject);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z, gridManager.cellBusyState.Fusion, this.gameObject);


              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.Fusion, this.gameObject);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.Fusion, this.gameObject);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.Fusion, this.gameObject);

              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.Fusion, this.gameObject);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.Fusion, this.gameObject);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.Fusion, this.gameObject);
        }
        else
        {
              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z, gridManager.cellBusyState.Void, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z, gridManager.cellBusyState.Void, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z, gridManager.cellBusyState.Void, null);

              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.Void, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.Void, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.Void, null);

              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.Void, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.Void, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.Void, null);

        }
    }

public void addCube(GameObject cubeRef)
{
    // Debug.Log(cubeRef.name);
     cubesInZone.Add(cubeRef);
     if(cubesInZone.Count >= 2)
     {
         fusionBlocs();
     }
}
    public void fusionBlocs()
    {

        foreach (GameObject cube in cubesInZone)
        {
            //Destroy(cube);
              if(cube != cubesInZone[0])
              {     
                cube.GetComponent<spawnedCube>().moveSpeed = 0f;
                  cube.transform.SetParent(cubesInZone[0].transform);
              }
        }
        cubesInZone.Clear();
    }


    
}
