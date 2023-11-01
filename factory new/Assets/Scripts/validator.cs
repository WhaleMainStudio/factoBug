using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class validator : MonoBehaviour
{
    private gridManager grid;
    // Start is called before the first frame update
    void Start()
    {
      //  Time.timeScale = 5;
             grid = GameObject.Find("grid").GetComponent<gridManager>();
            Vector3 currentCell = grid.getCurrentCellByPosition(this.transform.position);
            for (int i = 1; i < 5; i++)
            {
              grid.setCellBusy(currentCell.x, currentCell.y+i, currentCell.z, gridManager.cellBusyState.MovementAddY, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+i, currentCell.z, gridManager.cellBusyState.MovementAddY, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+i, currentCell.z, gridManager.cellBusyState.MovementAddY, null);


              grid.setCellBusy(currentCell.x, currentCell.y+i, currentCell.z+1, gridManager.cellBusyState.MovementAddY, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+i, currentCell.z+1, gridManager.cellBusyState.MovementAddY, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+i, currentCell.z+1, gridManager.cellBusyState.MovementAddY, null);

              grid.setCellBusy(currentCell.x, currentCell.y+i, currentCell.z-1, gridManager.cellBusyState.MovementAddY, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+i, currentCell.z-1, gridManager.cellBusyState.MovementAddY, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+i, currentCell.z-1, gridManager.cellBusyState.MovementAddY, null);
            }  


              grid.setCellBusy(currentCell.x, currentCell.y+7, currentCell.z, gridManager.cellBusyState.Win, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+7, currentCell.z, gridManager.cellBusyState.Win, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+7, currentCell.z, gridManager.cellBusyState.Win, null);

              grid.setCellBusy(currentCell.x, currentCell.y+7, currentCell.z+1, gridManager.cellBusyState.Win, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+7, currentCell.z+1, gridManager.cellBusyState.Win, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+7, currentCell.z+1, gridManager.cellBusyState.Win, null);

              grid.setCellBusy(currentCell.x, currentCell.y+7, currentCell.z-1, gridManager.cellBusyState.Win, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+7, currentCell.z-1, gridManager.cellBusyState.Win, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+7, currentCell.z-1, gridManager.cellBusyState.Win, null);
    }
}
