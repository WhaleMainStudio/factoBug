using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using Unity.PlasticSCM.Editor.WebApi;
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

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
      
        Vector3 spawnCell = grid.getCurrentCellByPosition(this.transform.position);
         curentCell = grid.getCurrentCellByPosition(this.transform.position);
       
        checkCurrentCell();
        cacheCellState = grid.checkCellBusy(curentCell);
        grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, null);
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
           
                if(grid.checkCellBusyObject(curentCell) != null)
                {
                     waitForFusion = false;
                    GameObject cubesFusion = grid.checkCellBusyObject(curentCell);
                   // Debug.Log(cubesFusion.name);
                    cubesFusion.GetComponent<cubesFusion>().addCube(this.gameObject.transform.parent.gameObject);
                }
        }


    }


    public void moveToCell(int _x, int _y, int _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }


    IEnumerator moveCube() 
{
    
    while(canMove)
    {
        yield return new WaitForSeconds(0.1f);

        if(grid.checkCellBusy(x,y,z) != gridManager.cellBusyState.Collider)
        {
        transform.position = Vector3.MoveTowards(transform.position, grid.getCurrentPositionByCell(x,y,z), moveSpeed);
        }

        if(transform.position == grid.getCurrentPositionByCell(x,y,z))
            {
            grid.setCellBusy(curentCell, cacheCellState, null);
            checkCurrentCell();
             curentCell = grid.getCurrentCellByPosition(this.transform.position);
            cacheCellState = grid.checkCellBusy(curentCell);
             grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, null);
            
            }
    }
}
}





