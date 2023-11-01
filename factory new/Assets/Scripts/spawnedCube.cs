using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class spawnedCube : MonoBehaviour
{
    private gridManager grid;
    public float moveSpeed = 2f;
    public bool canMove = false;
    public int x;
     public int y;
     public int z;
    private Vector3 curentCell;
    private gridManager.cellBusyState cacheCellState;
    private bool waitForFusion = true;
    private GameObject cacheCellobject;
    private bool move = false;
    private Vector3 cache2;
    private gridManager.cellBusyState cacheCellState2;
    private float delayBetweenMoves = 0.001f;
    private int numberCellsByMove = 1;
    private Vector3 lastMove;
    private bool doubleTurn = false;

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        turnManagerData.cubes.Add(this);


      //  if(turnManagerData.cubes.First() == this)
       // {
       //     turnManagerData.cubesAction.Add(this, true);             
       // }
       // else
      //  {
             turnManagerData.cubesAction.Add(this, false);
       // }
         
      
        Vector3 spawnCell = grid.getCurrentCellByPosition(this.transform.position);
         curentCell = grid.getCurrentCellByPosition(this.transform.position);
       
        checkCurrentCell();
        cacheCellState = grid.checkCellBusy(curentCell);
        cacheCellobject = grid.checkCellBusyObject(curentCell);
        grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
        StartCoroutine(moveCube());
        
    }
public void coroutineFlipFlop(bool active)
{
    if(active)
    {
        StartCoroutine(moveCube());
    }
    else
    {
        StopCoroutine(moveCube());
    }
}

public void pistonned(Vector3 offset, Vector3 cellToMove, Vector3 cellFrom0, Vector3 cellFrom1, Vector3 cellFrom2)
{
    if(grid.checkCellBusy(cellToMove) != gridManager.cellBusyState.Collider && grid.checkCellBusy(cellToMove) != gridManager.cellBusyState.Void)
    {
        if(curentCell == cellFrom0 ||curentCell == cellFrom1 || curentCell == cellFrom2)
        {

     grid.setCellBusy(curentCell, cacheCellState, cacheCellobject);
      moveToCell((int)cellToMove.x, (int)cellToMove.y,(int)cellToMove.z);
     if(this.transform.parent != null)
     {
        this.transform.parent.transform.position = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(this.transform.parent.transform.position) + offset);
     }
     else
     {
        this.transform.position = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(this.transform.position) + offset);
     }
       
     curentCell = grid.getCurrentCellByPosition(this.transform.position);

    checkCurrentCell();
     cacheCellState = grid.checkCellBusy(curentCell);
     cacheCellobject = grid.checkCellBusyObject(curentCell);
     grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

        }
    }
    else
    {
    }

}

    public void checkCurrentCell()
    {
        // if(this.transform.childCount > 0)
        // {
        //     numberCellsByMove = this.transform.childCount + 1;
        // }
        // else
        // {
        //     numberCellsByMove = 1;
        // }

        Vector3 currentCell = grid.getCurrentCellByPosition(this.transform.position);
        
        if(grid.checkCellBusy((int)currentCell.x, (int)currentCell.y, (int)currentCell.z) == gridManager.cellBusyState.MovementAddY)
        {
            if(this.transform.childCount == 1)
            {
            moveToCell((int)currentCell.x, (int)currentCell.y+5, (int)currentCell.z);
            lastMove = new Vector3(0, 6, 0);
            canMove = true;

           // Application.Quit();
            //checkCurrentCell();
             }
            // else
            // {
                 if(this.transform.childCount > 1)
                 {
                     foreach (Transform child in this.transform)
                     {
                         child.gameObject.GetComponent<spawnedCube>().destroyCube();
                     }
                     destroyCube();
                 }
                 if(this.transform.parent != null)
                 {
                    Debug.Log(" parent");
                     this.transform.parent.GetComponent<spawnedCube>().destroyCube();
                     destroyCube();
                 }
                 if(this.transform.parent == null)
                 {
                    Debug.Log("pas de parent");
                    destroyCube();
                 }
            //     destroyCube();
            // }

        }
            if(grid.checkCellBusy((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z) != gridManager.cellBusyState.Collider || grid.checkCellBusy((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z) != gridManager.cellBusyState.MovementAddY)
            {
            moveToCell((int)currentCell.x, (int)currentCell.y-1, (int)currentCell.z);
          //  lastMove = new Vector3(0, -1, 0);
            canMove = true;
            }
        
        if(grid.checkCellBusy((int)currentCell.x, (int)currentCell.y, (int)currentCell.z) == gridManager.cellBusyState.MovementAddX)
        {
            moveToCell((int)currentCell.x+1, (int)currentCell.y, (int)currentCell.z);
            lastMove = new Vector3(1, 0, 0);
            canMove = true;
        }
        if(grid.checkCellBusy((int)currentCell.x, (int)currentCell.y, (int)currentCell.z) == gridManager.cellBusyState.MovementAddZ)
        {
            moveToCell((int)currentCell.x, (int)currentCell.y, (int)currentCell.z+1);
            lastMove = new Vector3(0, 0, 1);
            canMove = true;
        }
        if(grid.checkCellBusy((int)currentCell.x, (int)currentCell.y, (int)currentCell.z) == gridManager.cellBusyState.MovementRemX)
        {
            moveToCell((int)currentCell.x-1, (int)currentCell.y, (int)currentCell.z);
            lastMove = new Vector3(-1, 0, 0);
            canMove = true;
        }
        if(grid.checkCellBusy((int)currentCell.x, (int)currentCell.y, (int)currentCell.z) == gridManager.cellBusyState.MovementRemZ)
        {
            moveToCell((int)currentCell.x, (int)currentCell.y, (int)currentCell.z-1);
            lastMove = new Vector3(0, 0, -1);
            canMove = true;
        }
         if(grid.checkCellBusy((int)currentCell.x, (int)currentCell.y, (int)currentCell.z) == gridManager.cellBusyState.Win)
        {
            Debug.Log("quit");
            Debug.Log("quit");
            Debug.Log("quit");
            Debug.Log("quit");
            Debug.Log("quit");
            Debug.Log("quit");
            Debug.Log("quit");
            Debug.Log("quit");
            Debug.Log("quit");
            Time.timeScale = 0;
            Application.Quit();
        }
        
    }

    private void destroyCube()
    {
        grid.setCellBusy(curentCell, cacheCellState, cacheCellobject);
         Vector3 currentCell = grid.getCurrentCellByPosition(this.transform.position);
      grid.setCellBusy(currentCell, gridManager.cellBusyState.MovementAddY, null);
       endTurn();
     //
       // turnManagerData.cubes.RemoveAt(turnManagerData.cubes.IndexOf(this));
       // turnManagerData.cubesAction.Remove(this);

    //      foreach (spawnedCube item in turnManagerData.cubes)
    //  {
    //          turnManagerData.cubes[ turnManagerData.cubes.IndexOf(item)];
    //  }
       // turnManagerData.cubes.Sort();
      //  turnManagerData.cubesAction.Sort
        
      //  grid.setCellBusy(currentCell, gridManager.cellBusyState.MovementAddY, null);
      //  Debug.Log(grid.checkCellBusy(currentCell));
       // Debug.Log(grid.checkCellBusy(curentCell));
      // foreach (spawnedCube _cube in turnManagerData.cubes)
       //{
       // turnManagerData.cubes.RemoveAt(turnManagerData.cubes.IndexOf(_cube));
       // turnManagerData.cubes.Add(_cube);
      // }


       // this.gameObject.SetActive(false);
      //  Destroy(this.gameObject);
    }

    public void moveToCell(int _x, int _y, int _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }

        public void moveToCell(Vector3 cellToMove)
    {
        x = (int)cellToMove.x;
        y = (int)cellToMove.y;
        z = (int)cellToMove.z;
    }


    IEnumerator moveCube() 
{
    
    while(canMove)
    {
        yield return new WaitForSeconds(0.005f);

        if(grid.checkCellBusy(x,y,z) != gridManager.cellBusyState.Collider)
        {
            if(this.transform.childCount > 0)
            {

            }

             if(turnManagerData.cubesAction[this] == true)
             {
                if(this.transform.parent == null)
                {
                this.transform.position = Vector3.MoveTowards(this.transform.position, grid.getCurrentPositionByCell(x,y,z), 30* Time.deltaTime);
                }
                else
                {
                grid.setCellBusy(curentCell, cacheCellState, cacheCellobject);
                checkCurrentCell();
                
                curentCell = grid.getCurrentCellByPosition(this.transform.position);
                cacheCellState = grid.checkCellBusy(curentCell);
                cacheCellobject = grid.checkCellBusyObject(curentCell);
                grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
                endTurn();
                }
             }
        }
        else
        {
            if(turnManagerData.cubesAction[this] == true)
            {
            endTurn();
            }
        }

       if(this.transform.position == grid.getCurrentPositionByCell(x,y,z) && turnManagerData.cubesAction[this] == true)
            {
            grid.setCellBusy(curentCell, cacheCellState, cacheCellobject);
            checkCurrentCell();
            
            curentCell = grid.getCurrentCellByPosition(this.transform.position);
            cacheCellState = grid.checkCellBusy(curentCell);
            cacheCellobject = grid.checkCellBusyObject(curentCell);
            grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

            endTurn();

            }
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
                    Vector3 cellCenter = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(this.transform.position));
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireCube(cellCenter, new Vector3(1, 1, 1));
                    }
                }
            }
        }
    }

    private void endTurn()
    {
         Debug.Log("end turn " + grid.getCurrentCellByPosition(this.transform.position) + "   " + grid.checkCellBusy(grid.getCurrentCellByPosition(this.transform.position)));
         Vector3 currentCell = grid.getCurrentCellByPosition(this.transform.position);

        if(this.transform.childCount > 0)
        {
            if(doubleTurn == false)
            {
           
            moveToCell(currentCell + lastMove);
            canMove = true;
            doubleTurn = true;
            return;
            }
            if(doubleTurn == true)
            {
                 turnManagerData.cubesAction[this] = false;
                    if(turnManagerData.cubes.Last() == this)
                    {
                        Debug.Log("last cube");
                        if(turnManagerData.pistons.Count > 0)
                        {               
                          turnManagerData.pistonAction[turnManagerData.pistons.First()] = true;
                        }
                        else
                        {
                        //  turnManagerData.cubesAction[turnManagerData.cubes.First()] = true;
                        }
                    }
                    else
                    {
                    turnManagerData.cubesAction[turnManagerData.cubes[turnManagerData.cubes.IndexOf(this) + 1]] = true;
                    }
                    doubleTurn = false;
            }
        }
        else
        {
                    turnManagerData.cubesAction[this] = false;
                    if(turnManagerData.cubes.Last() == this)
                    {
                        Debug.Log("last cube");
                        if(turnManagerData.pistons.Count > 0)
                        {               
                          turnManagerData.pistonAction[turnManagerData.pistons.First()] = true;
                        }
                        else
                        {
                        //  turnManagerData.cubesAction[turnManagerData.cubes.First()] = true;
                        }
                    }
                    else
                    {
                    turnManagerData.cubesAction[turnManagerData.cubes[turnManagerData.cubes.IndexOf(this) + 1]] = true;
                    }
        }
                   
    }

    void Update()
    {
        if(turnManagerData.cubesAction[this] == true)
        {
     //  Debug.Log(grid.getCurrentCellByPosition(this.transform.position) + "   " + grid.checkCellBusy(grid.getCurrentCellByPosition(this.transform.position)));
        }
    }
}