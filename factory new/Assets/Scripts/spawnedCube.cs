using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnedCube : MonoBehaviour
{
    private gridManager grid;
    public float moveSpeed = 2f;
    private bool canMove = false;
    private int x;
    private int y;
    private int z;
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
      
        Vector3 spawnCell = grid.getCurrentCellByPosition(this.transform.position);
         curentCell = grid.getCurrentCellByPosition(this.transform.position);
       
        checkCurrentCell();
        cacheCellState = grid.checkCellBusy(curentCell);
        cacheCellobject = grid.checkCellBusyObject(curentCell);
        grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
       StartCoroutine(moveCube());
        
    }

    private void checkCurrentCell()
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


    IEnumerator moveCube() 
{
    
    while(canMove)
    {
        yield return new WaitForSeconds(0.001f);

        if(grid.checkCellBusy(x,y,z) != gridManager.cellBusyState.Collider)
        {
        transform.position = Vector3.MoveTowards(transform.position, grid.getCurrentPositionByCell(x,y,z), moveSpeed * Time.deltaTime);
        }
       // else
       // {
       //     checkCurrentCell();
       // }

        if(transform.position == grid.getCurrentPositionByCell(x,y,z))
            {
           //  move = false;
          //   grid.setCellBusy(cache2, cacheCellState2, null);
            grid.setCellBusy(curentCell, cacheCellState, cacheCellobject);
            checkCurrentCell();
            
             curentCell = grid.getCurrentCellByPosition(this.transform.position);
            cacheCellState = grid.checkCellBusy(curentCell);
            cacheCellobject = grid.checkCellBusyObject(curentCell);
             grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
            
            }
    }
}
}