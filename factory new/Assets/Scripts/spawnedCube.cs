using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
      
        Vector3 spawnCell = grid.getCurrentCellByPosition(this.transform.parent.transform.position);
         curentCell = grid.getCurrentCellByPosition(this.transform.parent.transform.position);
       
        checkCurrentCell();
        cacheCellState = grid.checkCellBusy(curentCell);
        cacheCellobject = grid.checkCellBusyObject(curentCell);
        grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
       StartCoroutine(moveCube());
        
    }


public void pistonned(Vector3 cellToMove, Vector3 cellFrom0, Vector3 cellFrom1, Vector3 cellFrom2)
{
    if(grid.checkCellBusy(cellToMove) != gridManager.cellBusyState.Collider)
    {
        if(curentCell == cellFrom0 ||curentCell == cellFrom1 || curentCell == cellFrom2)
        {
      //  moveSpeed = 100;
     //   moveToCell(cellToMove);
      //  moveSpeed = 2;
     grid.setCellBusy(curentCell, cacheCellState, cacheCellobject);
     this.transform.parent.transform.position = grid.getCurrentPositionByCell(cellToMove);
     curentCell = grid.getCurrentCellByPosition(this.transform.parent.transform.position);

    checkCurrentCell();
     cacheCellState = grid.checkCellBusy(curentCell);
     cacheCellobject = grid.checkCellBusyObject(curentCell);
     grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

        }

    
    }
    else
    {
      //  grid.checkCellBusyObject(cellToMove).GetComponent<spawnedCube>().transform.parent.transform.position = grid.getCurrentPositionByCell(cellToMove + new Vector3(1,0,0));
    }

            
            //  curentCell = grid.getCurrentCellByPosition(this.transform.position);
            // cacheCellState = grid.checkCellBusy(curentCell);
            // cacheCellobject = grid.checkCellBusyObject(curentCell);
            //  grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
   
}

    public void checkCurrentCell()
    {
         Vector3 currentCell = grid.getCurrentCellByPosition(this.transform.parent.transform.position);
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
       
        }
    }

    private void fusion()
    {
        

        if(waitForFusion == true)
        {
           
                if(grid.checkCellBusyObject(curentCell).tag == "fusion")
                {
                     waitForFusion = false;
                    GameObject cubesFusion = grid.checkCellBusyObject(curentCell);
                   // Debug.Log(cubesFusion.name);
                    cubesFusion.GetComponent<cubesFusion>().addCube(this.gameObject);
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
        yield return new WaitForSeconds(0.001f);

        if(grid.checkCellBusy(x,y,z) != gridManager.cellBusyState.Collider)
        {
        this.transform.parent.transform.position = Vector3.MoveTowards(this.transform.parent.transform.position, grid.getCurrentPositionByCell(x,y,z), moveSpeed * Time.deltaTime);
        }
       // else
       // {
       //     checkCurrentCell();
       // }

        if(this.transform.parent.transform.position == grid.getCurrentPositionByCell(x,y,z))
            {
           //  move = false;
          //   grid.setCellBusy(cache2, cacheCellState2, null);
            grid.setCellBusy(curentCell, cacheCellState, cacheCellobject);
            checkCurrentCell();
            
             curentCell = grid.getCurrentCellByPosition(this.transform.parent.transform.position);
            cacheCellState = grid.checkCellBusy(curentCell);
            cacheCellobject = grid.checkCellBusyObject(curentCell);
             grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
            
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
                    Vector3 cellCenter = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(this.transform.parent.transform.position));
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireCube(cellCenter, new Vector3(1, 1, 1));
                    }
                }
            }
        }
    }
}