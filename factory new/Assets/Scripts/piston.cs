using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class piston : MonoBehaviour
{
    [SerializeField] private List<GameObject> hitPoints;

   // [SerializeField] private GameObject Cubee;
        private gridManager grid;
    private float hitTime = 1f;
    private bool canHit = true;
    private bool flipFlop = false;
    private Dictionary<Vector3, gridManager.cellBusyState> cachesStates = new  Dictionary<Vector3, gridManager.cellBusyState>();
    

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        turnManagerData.pistons.Add(this);
        turnManagerData.pistonAction.Add(this, false);
        StartCoroutine(hit());
    }

public void coroutineFlipFlop(bool active)
{
    if(active)
    {
        StartCoroutine(hit());
    }
    else
    {
        StopCoroutine(hit());
    }
}

IEnumerator hit() 
{
    while(canHit)
    {  
            yield return new WaitForSeconds(0.5f);
                  if(turnManagerData.pistonAction[this] == true)
                  {
                        hitEvent();  
                  }
    }
}

    private void hitEvent()
    {
        if(flipFlop)
        {
        foreach (var hitPoint in hitPoints)
        {
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x-1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x-1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
           // hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x-1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
        }
        turnManagerData.pistonAction[this] = false;
        if(turnManagerData.pistons.Last() == this)
        {
            if(turnManagerData.fusions.Count > 0)
            {
                turnManagerData.fusionAction[turnManagerData.fusions.First()] = true;
                turnManagerData.fusions.First().addCubes();
            }
            else
            {
             //   turnManagerData.pistonAction[turnManagerData.pistons.First()] = true;
            }
        }
        else
        {
           turnManagerData.pistonAction[turnManagerData.pistons[turnManagerData.pistons.IndexOf(this) + 1]] = true;
        }
        flipFlop = false;
        
        
        }
        else
        {
        
        foreach (var hitPoint in hitPoints)
        {
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x+1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
            flipFlopActive(true, grid.getCurrentCellByPosition(hitPoint.transform.position));
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x+1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
           flipFlopActive(true, grid.getCurrentCellByPosition(hitPoint.transform.position));
        }
        flipFlop = true;
        
        }

    }

      private void flipFlopActive(bool active, Vector3 newpos)
    {
        if(active)
        {
                if(grid.checkCellBusyObject(newpos) != null)
                {
                    if(grid.checkCellBusyObject(newpos).tag == "movingCube")
                    {
                        spawnedCube _cube = grid.checkCellBusyObject(newpos).GetComponent<spawnedCube>();

                                    if(this.transform.rotation.eulerAngles.y == 270)
                                {
                                  _cube.pistonned(new Vector3(0,0,1),newpos + new Vector3(0,0,1), grid.getCurrentCellByPosition(hitPoints[0].transform.position), grid.getCurrentCellByPosition(hitPoints[1].transform.position), grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                                   _cube.pistonned(new Vector3(0,0,1),newpos + new Vector3(0,0,1), grid.getCurrentCellByPosition(hitPoints[0].transform.position), grid.getCurrentCellByPosition(hitPoints[1].transform.position), grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                                }
                                        if(this.transform.rotation.eulerAngles.y == 180)
                                {
                                   _cube.pistonned(new Vector3(-1,0,0),newpos - new Vector3(1,0,0), grid.getCurrentCellByPosition(hitPoints[0].transform.position), grid.getCurrentCellByPosition(hitPoints[1].transform.position), grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                                   _cube.pistonned(new Vector3(-1,0,0),newpos - new Vector3(1,0,0), grid.getCurrentCellByPosition(hitPoints[0].transform.position), grid.getCurrentCellByPosition(hitPoints[1].transform.position), grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                                }
                                        if(this.transform.rotation.eulerAngles.y == 0)
                                {
                                    _cube.pistonned(new Vector3(1,0,0),newpos + new Vector3(1,0,0), grid.getCurrentCellByPosition(hitPoints[0].transform.position), grid.getCurrentCellByPosition(hitPoints[1].transform.position), grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                                    _cube.pistonned(new Vector3(1,0,0),newpos + new Vector3(1,0,0), grid.getCurrentCellByPosition(hitPoints[0].transform.position), grid.getCurrentCellByPosition(hitPoints[1].transform.position), grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                                }
                                        if(this.transform.rotation.eulerAngles.y == 90)
                                {
                                    _cube.pistonned(new Vector3(0,0,-1),newpos - new Vector3(0,0,1), grid.getCurrentCellByPosition(hitPoints[0].transform.position), grid.getCurrentCellByPosition(hitPoints[1].transform.position), grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                                    _cube.pistonned(new Vector3(0,0,-1),newpos - new Vector3(0,0,1), grid.getCurrentCellByPosition(hitPoints[0].transform.position), grid.getCurrentCellByPosition(hitPoints[1].transform.position), grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                                }
                    }
                }
        }
        else
        {  

        }
    }


     private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        for (int x = 0; x < 1; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                for (int z = 0; z < 1; z++)
                {
                    if(grid != null)
                    {
                    Vector3 cellCenter = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(hitPoints[0].transform.position));
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireCube(cellCenter, new Vector3(1, 1, 1));

                    Vector3 cellCenter2 = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(hitPoints[1].transform.position));
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireCube(cellCenter2, new Vector3(1, 1, 1));

                    Vector3 cellCenter3 = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireCube(cellCenter3, new Vector3(1, 1, 1));
                    }

                }
            }
        }
    }


        void Update()
    {
        if(turnManagerData.pistonAction[this] == true)
        {
     //  Debug.Log(grid.getCurrentCellByPosition(this.transform.position) + "   " + grid.checkCellBusy(grid.getCurrentCellByPosition(this.transform.position)));
        }
    }
}
