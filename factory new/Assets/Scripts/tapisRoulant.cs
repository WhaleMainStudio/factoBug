using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapisRoulant : MonoBehaviour
{
        private gridManager grid;
        private  Vector3 currentCell;

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        turnManagerData.tapis.Add(this.GetComponent<tapisRoulant>());

         currentCell = grid.getCurrentCellByPosition(this.transform.position);
        flipFlopActive(true);
    }



    private void flipFlopActive(bool active)
    {
        if(active)
        {
               if(this.transform.rotation.eulerAngles.y == 90)
        {
              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z, gridManager.cellBusyState.MovementAddZ, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z, gridManager.cellBusyState.MovementAddZ, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z, gridManager.cellBusyState.MovementAddZ, null);


              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementAddZ, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementAddZ, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementAddZ, null);

              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementAddZ, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementAddZ, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementAddZ, null);
             
        }
                if(this.transform.rotation.eulerAngles.y == 0)
        {
              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z, gridManager.cellBusyState.MovementRemX, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z, gridManager.cellBusyState.MovementRemX, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z, gridManager.cellBusyState.MovementRemX, null);


              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementRemX, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementRemX, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementRemX, null);

              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementRemX, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementRemX, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementRemX, null);
        }
                if(this.transform.rotation.eulerAngles.y == 180)
        {
              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z, gridManager.cellBusyState.MovementAddX, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z, gridManager.cellBusyState.MovementAddX, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z, gridManager.cellBusyState.MovementAddX, null);


              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementAddX, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementAddX, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementAddX, null);

              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementAddX, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementAddX, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementAddX, null);
        }
                if(this.transform.rotation.eulerAngles.y == 270)
        {
              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z, gridManager.cellBusyState.MovementRemZ, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z, gridManager.cellBusyState.MovementRemZ, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z, gridManager.cellBusyState.MovementRemZ, null);


              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementRemZ, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementRemZ, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementRemZ, null);

              grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementRemZ, null);
              grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementRemZ, null);
              grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementRemZ, null);
        }
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
}
