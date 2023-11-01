using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class cubesFusion : MonoBehaviour
{
    public List<Material> _materials = new List<Material>();
    private gridManager grid;
    private  Vector3 currentCell;
    private List<GameObject> cubesInZone = new List<GameObject>();
    private bool canHit = true;
    private bool flipFlop = false;

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        turnManagerData.fusions.Add(this);
        turnManagerData.fusionAction.Add(this, false);
        currentCell = grid.getCurrentCellByPosition(this.transform.position);
    }

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
        }
        endTurn();
    }
}
    IEnumerator hit() 
{
    while(canHit)
    {  
            yield return new WaitForSeconds(1f);
            hitEvent();  
    }
}
    public void fusionBlocs()
    {
        bool canFusion = false;
        foreach (GameObject cube in cubesInZone)
        {
              cubesInZone[0].gameObject.GetComponent<MeshRenderer>().material = _materials[0];
              if(cube != cubesInZone[0])
              {    
                  canFusion = true;
                  cube.transform.SetParent(cubesInZone[0].transform);
                  cube.GetComponent<MeshRenderer>().material = _materials[0];
              }
        }

        if(canFusion)
        {
        canHit = true;
        StartCoroutine(hit());
        canFusion = false;
        }
        else
        {
            canHit = false;
            endTurn();
        }
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

    private void hitEvent()
    {
        if(flipFlop)
        {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y+1, this.transform.localPosition.z);    
        canHit = false;
        StopCoroutine(hit());
        endTurn();
        flipFlop = false; 
        }
        else
        {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y-1, this.transform.localPosition.z);
        flipFlop = true;
        }
    }
}
