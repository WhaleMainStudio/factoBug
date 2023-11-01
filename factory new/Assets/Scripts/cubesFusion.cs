using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class cubesFusion : MonoBehaviour
{
    private gridManager grid;
    private  Vector3 currentCell;
    private List<GameObject> cubesInZone = new List<GameObject>();
    private bool lockk = false;

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        turnManagerData.fusions.Add(this);
        turnManagerData.fusionAction.Add(this, false);
        currentCell = grid.getCurrentCellByPosition(this.transform.position);
        //flipFlopActive(true);
    }


    //  private void flipFlopActive(bool active)
    // {
    //     if(active)
    //     {
    //           grid.setCellBusy(currentCell.x, currentCell.y-1, currentCell.z, gridManager.cellBusyState.Fusion, this.gameObject);
    //           grid.setCellBusy(currentCell.x+1, currentCell.y-1, currentCell.z, gridManager.cellBusyState.Fusion, this.gameObject);
    //           grid.setCellBusy(currentCell.x-1, currentCell.y-1, currentCell.z, gridManager.cellBusyState.Fusion, this.gameObject);


    //           grid.setCellBusy(currentCell.x, currentCell.y-1, currentCell.z+1, gridManager.cellBusyState.Fusion, this.gameObject);
    //           grid.setCellBusy(currentCell.x+1, currentCell.y-1, currentCell.z+1, gridManager.cellBusyState.Fusion, this.gameObject);
    //           grid.setCellBusy(currentCell.x-1, currentCell.y-1, currentCell.z+1, gridManager.cellBusyState.Fusion, this.gameObject);

    //           grid.setCellBusy(currentCell.x, currentCell.y-1, currentCell.z-1, gridManager.cellBusyState.Fusion, this.gameObject);
    //           grid.setCellBusy(currentCell.x+1, currentCell.y-1, currentCell.z-1, gridManager.cellBusyState.Fusion, this.gameObject);
    //           grid.setCellBusy(currentCell.x-1, currentCell.y-1, currentCell.z-1, gridManager.cellBusyState.Fusion, this.gameObject);
    //     }
    //     else
    //     {
    //           grid.setCellBusy(currentCell.x, currentCell.y-1, currentCell.z, gridManager.cellBusyState.Void, null);
    //           grid.setCellBusy(currentCell.x+1, currentCell.y-1, currentCell.z, gridManager.cellBusyState.Void, null);
    //           grid.setCellBusy(currentCell.x-1, currentCell.y-1, currentCell.z, gridManager.cellBusyState.Void, null);

    //           grid.setCellBusy(currentCell.x, currentCell.y-1, currentCell.z+1, gridManager.cellBusyState.Void, null);
    //           grid.setCellBusy(currentCell.x+1, currentCell.y-1, currentCell.z+1, gridManager.cellBusyState.Void, null);
    //           grid.setCellBusy(currentCell.x-1, currentCell.y-1, currentCell.z+1, gridManager.cellBusyState.Void, null);

    //           grid.setCellBusy(currentCell.x, currentCell.y-1, currentCell.z-1, gridManager.cellBusyState.Void, null);
    //           grid.setCellBusy(currentCell.x+1, currentCell.y-1, currentCell.z-1, gridManager.cellBusyState.Void, null);
    //           grid.setCellBusy(currentCell.x-1, currentCell.y-1, currentCell.z-1, gridManager.cellBusyState.Void, null);

    //     }
    // }

public void addCubes()
{
    cubesInZone.Clear();


   



    if(grid.checkCellBusyObject((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z) != null && grid.checkCellBusyObject((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z).transform.parent == null && grid.checkCellBusyObject((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z).transform.childCount == 0)
    {
        cubesInZone.Add(grid.checkCellBusyObject((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z));
    }

        if(grid.checkCellBusyObject((int)currentCell.x+1, (int)currentCell.y-1, (int)currentCell.z) != null && grid.checkCellBusyObject((int)currentCell.x+1, (int)currentCell.y-1, (int)currentCell.z).transform.parent == null && grid.checkCellBusyObject((int)currentCell.x+1, (int)currentCell.y-1, (int)currentCell.z).transform.childCount == 0) 
    {
cubesInZone.Add(grid.checkCellBusyObject((int)currentCell.x+1, (int)currentCell.y-1, (int)currentCell.z));
    }

        if(grid.checkCellBusyObject((int)currentCell.x-1, (int)currentCell.y-1, (int)currentCell.z) != null && grid.checkCellBusyObject((int)currentCell.x-1, (int)currentCell.y-1, (int)currentCell.z).transform.parent == null && grid.checkCellBusyObject((int)currentCell.x-1, (int)currentCell.y-1, (int)currentCell.z).transform.childCount == 0)
    {
cubesInZone.Add(grid.checkCellBusyObject((int)currentCell.x-1, (int)currentCell.y-1, (int)currentCell.z));
    }

        if(grid.checkCellBusyObject((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z+1) != null && grid.checkCellBusyObject((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z+1).transform.parent == null && grid.checkCellBusyObject((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z+1).transform.childCount == 0)
    {
cubesInZone.Add(grid.checkCellBusyObject((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z+1));
    }

        if(grid.checkCellBusyObject((int)currentCell.x+1, (int)currentCell.y-1, (int)currentCell.z+1) != null && grid.checkCellBusyObject((int)currentCell.x+1, (int)currentCell.y-1, (int)currentCell.z+1).transform.parent == null && grid.checkCellBusyObject((int)currentCell.x+1, (int)currentCell.y-1, (int)currentCell.z+1).transform.childCount == 0)
    {
cubesInZone.Add(grid.checkCellBusyObject((int)currentCell.x+1, (int)currentCell.y-1, (int)currentCell.z+1));
    }

        if(grid.checkCellBusyObject((int)currentCell.x-1, (int)currentCell.y-1, (int)currentCell.z+1) != null && grid.checkCellBusyObject((int)currentCell.x-1, (int)currentCell.y-1, (int)currentCell.z+1).transform.parent == null && grid.checkCellBusyObject((int)currentCell.x-1, (int)currentCell.y-1, (int)currentCell.z+1).transform.childCount == 0)
    {
cubesInZone.Add(grid.checkCellBusyObject((int)currentCell.x-1, (int)currentCell.y-1, (int)currentCell.z+1));
    }

        if(grid.checkCellBusyObject((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z-1) != null && grid.checkCellBusyObject((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z-1).transform.parent == null && grid.checkCellBusyObject((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z-1).transform.childCount == 0)
    {
cubesInZone.Add(grid.checkCellBusyObject((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z-1));
    }

        if(grid.checkCellBusyObject((int)currentCell.x+1, (int)currentCell.y-1, (int)currentCell.z-1) != null && grid.checkCellBusyObject((int)currentCell.x+1, (int)currentCell.y-1, (int)currentCell.z-1).transform.parent == null && grid.checkCellBusyObject((int)currentCell.x+1, (int)currentCell.y-1, (int)currentCell.z-1).transform.childCount == 0)
    {
cubesInZone.Add(grid.checkCellBusyObject((int)currentCell.x+1, (int)currentCell.y-1, (int)currentCell.z-1));
    }

        if(grid.checkCellBusyObject((int)currentCell.x-1, (int)currentCell.y-1, (int)currentCell.z-1) != null && grid.checkCellBusyObject((int)currentCell.x-1, (int)currentCell.y-1, (int)currentCell.z-1).transform.parent == null && grid.checkCellBusyObject((int)currentCell.x-1, (int)currentCell.y-1, (int)currentCell.z-1).transform.childCount == 0)
    {
cubesInZone.Add(grid.checkCellBusyObject((int)currentCell.x-1, (int)currentCell.y-1, (int)currentCell.z-1));
    }
    

    if(cubesInZone.Count >= 2)
    {
        fusionBlocs();
    }
    else
    {
        if(cubesInZone.Count == 1)
        {
      //  Destroy(cubesInZone[0]);
        }
        endTurn();
    }
}
    public void fusionBlocs()
    {

        foreach (GameObject cube in cubesInZone)
        {
              if(cube != cubesInZone[0])
              {    
                  cube.transform.SetParent(cubesInZone[0].transform);
              }
        }
        endTurn();
    }

    private void endTurn()
    {
        turnManagerData.fusionAction[this] = false;

                    if(turnManagerData.fusions.Last() == this)
                    {

                        if(turnManagerData.spawners.Count > 0)
                        {               
                          turnManagerData.spawnerAction[turnManagerData.spawners.First()] = true;
                        }
                       // else
                       //{
                       // turnManagerData.fusionAction[turnManagerData.fusions.First()] = true;
                       //}
                    }
                    else
                    {
                            if(turnManagerData.fusions.Count > 0)
                         {
                            turnManagerData.fusionAction[turnManagerData.fusions[turnManagerData.fusions.IndexOf(this) + 1]] = true;
                            turnManagerData.fusions[turnManagerData.fusions.IndexOf(this) + 1].addCubes();
                         }
                    }
    }

        void Update()
    {
        if(turnManagerData.fusionAction[this] == true)
        {
     //  Debug.Log(grid.getCurrentCellByPosition(this.transform.position) + "   " + grid.checkCellBusy(grid.getCurrentCellByPosition(this.transform.position)));
        }
    }
}
