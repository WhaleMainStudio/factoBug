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

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        turnManagerData.cubes.Add(this);


        if(turnManagerData.cubes.First() == this)
        {
            turnManagerData.cubesAction.Add(this, true);             
        }
        else
        {
             turnManagerData.cubesAction.Add(this, false);
        }
         
      
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
       // this.transform.position = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(this.transform.position) + offset);
         //this.transform.parent.transform.parent.transform.position = grid.getCurrentPositionByCell(cellToMove);
        // Debug.Log("dsgdsgdsgfdgdfgdfg");
     }
     else
     {
        this.transform.position = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(this.transform.position) + offset);
      //  grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(this.transform.parent.transform.position)) = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(this.transform.parent.transform.position + offset));
    // this.transform.parent.transform.position = new Vector3(grid.getCurrentPositionByCell(cellToMove).x,grid.getCurrentPositionByCell(cellToMove).y,grid.getCurrentPositionByCell(cellToMove).z);
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
      //  grid.checkCellBusyObject(cellToMove).GetComponent<spawnedCube>().pistonned(cellToMove);
       // grid.checkCellBusyObject(cellToMove).GetComponent<spawnedCube>().transform.parent.transform.position = grid.getCurrentPositionByCell(cellToMove + new Vector3(1,0,0));
    }

            
            //  curentCell = grid.getCurrentCellByPosition(this.transform.position);
            // cacheCellState = grid.checkCellBusy(curentCell);
            // cacheCellobject = grid.checkCellBusyObject(curentCell);
            //  grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
   
}

    public void checkCurrentCell()
    {
         Vector3 currentCell = grid.getCurrentCellByPosition(this.transform.position);
         if(grid.checkCellBusy((int)currentCell.x, (int)currentCell.y, (int)currentCell.z) == gridManager.cellBusyState.MovementAddX)
        {
            moveToCell((int)currentCell.x+1, (int)currentCell.y, (int)currentCell.z);
            canMove = true;
        }
                if(grid.checkCellBusy((int)currentCell.x, (int)currentCell.y, (int)currentCell.z) == gridManager.cellBusyState.MovementAddZ)
        {
            moveToCell((int)currentCell.x, (int)currentCell.y, (int)currentCell.z+1);
            canMove = true;
        }
                if(grid.checkCellBusy((int)currentCell.x, (int)currentCell.y, (int)currentCell.z) == gridManager.cellBusyState.MovementRemX)
        {
            moveToCell((int)currentCell.x-1, (int)currentCell.y, (int)currentCell.z);
            canMove = true;
        }
                if(grid.checkCellBusy((int)currentCell.x, (int)currentCell.y, (int)currentCell.z) == gridManager.cellBusyState.MovementRemZ)
        {
            moveToCell((int)currentCell.x, (int)currentCell.y, (int)currentCell.z-1);
            canMove = true;
        }
            if(grid.checkCellBusy((int)currentCell.x, (int)currentCell.y, (int)currentCell.z) == gridManager.cellBusyState.Fusion)
        {
            fusion();
          //  checkCurrentCell();
        }
    }

    private void fusion()
    {
       

        if(waitForFusion == true)
        {
           
                if(grid.checkCellBusyObject(curentCell).tag == "fusion")
                {
                     waitForFusion = false;
                    // moveToCell(grid.getCurrentCellByPosition(this.transform.parent.transform.position));
                    GameObject cubesFusion = grid.checkCellBusyObject(curentCell);
                   // Debug.Log(cubesFusion.name);
                   cubesFusion.GetComponent<cubesFusion>().addCube(this.gameObject);



                    turnManagerData.cubesAction[this] = false;
                if(turnManagerData.cubes.Last() == this)
                {
                    turnManagerData.cubesAction[turnManagerData.cubes.First()] = true;
                }
                else
                    {
                    turnManagerData.cubesAction[turnManagerData.cubes[turnManagerData.cubes.IndexOf(this) + 1]] = true;
                    }
                  //  moveToCell(grid.getCurrentCellByPosition(this.transform.position));
                }
        }


    }


    public void moveToCell(int _x, int _y, int _z)
    {
        x = _x;
        y = _y;
        z = _z;
      //  move = true;
      //  cache2 = new Vector3(x,y,z);
      //  cacheCellState2 = grid.checkCellBusy(cache2);
       // grid.setCellBusy(cache2, gridManager.cellBusyState.Collider, this.gameObject);
        
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
             if(turnManagerData.cubesAction[this] == true)
             {
             this.transform.position = Vector3.MoveTowards(this.transform.position, grid.getCurrentPositionByCell(x,y,z), 3* Time.deltaTime);
             }
        }
        else
        {
            if(turnManagerData.cubesAction[this] == true)
             {
                turnManagerData.cubesAction[this] = false;
                if(turnManagerData.cubes.Last() == this)
                {
                    turnManagerData.cubesAction[turnManagerData.cubes.First()] = true;
                }
                else
                    {
                    turnManagerData.cubesAction[turnManagerData.cubes[turnManagerData.cubes.IndexOf(this) + 1]] = true;
                    }
             }
       //     turnManagerData.cubesAction[this] = true;
       //     checkCurrentCell();
        }
        
        // if(grid.getCurrentCellByPosition(this.transform.parent.transform.position) == new Vector3(x,y,z))
        // {


        // }
       if(this.transform.position == grid.getCurrentPositionByCell(x,y,z))
            {
            grid.setCellBusy(curentCell, cacheCellState, cacheCellobject);
            checkCurrentCell();
            
            curentCell = grid.getCurrentCellByPosition(this.transform.position);
            cacheCellState = grid.checkCellBusy(curentCell);
            cacheCellobject = grid.checkCellBusyObject(curentCell);
            grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

             turnManagerData.cubesAction[this] = false;
                if(turnManagerData.cubes.Last() == this)
                {
                    turnManagerData.cubesAction[turnManagerData.cubes.First()] = true;
                }
                else
                    {
                    turnManagerData.cubesAction[turnManagerData.cubes[turnManagerData.cubes.IndexOf(this) + 1]] = true;
                    }

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


    void Update()
    {
        if(turnManagerData.cubesAction[this] == true)
        {
        Debug.Log(this.name);
        }
    }
}