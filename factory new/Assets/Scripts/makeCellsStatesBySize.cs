using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeCellsStatesBySize : MonoBehaviour
{
    private gridManager grid;
    [SerializeField] private Vector3 sizeInGrid;
    private Vector3 startPos;
    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        startPos = this.transform.position;

       // sizeInGrid = this.transform.localScale;
       // sizeInGrid -= new Vector3(1,1,1);
        for (int x = 0; x < sizeInGrid.x; x++)
        {
            for (int y = 0; y < sizeInGrid.y; y++)
            {
                for (int z = 0; z < sizeInGrid.z; z++)
                {
                    Vector3 curentCell = new Vector3(grid.getCurrentCellByPosition(startPos).x + x, grid.getCurrentCellByPosition(startPos).y + y, grid.getCurrentCellByPosition(startPos).z + z);
                    grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.transform.parent.gameObject);
                     curentCell = new Vector3(grid.getCurrentCellByPosition(startPos).x + x, grid.getCurrentCellByPosition(startPos).y - y, grid.getCurrentCellByPosition(startPos).z + z);
                    grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.transform.parent.gameObject);
                }
            }
        }
    }

  void Destroy()
  {
    if(grid != null)
    {
     for (int x = 0; x < sizeInGrid.x; x++)
        {
            for (int y = 0; y < sizeInGrid.y; y++)
            {
                for (int z = 0; z < sizeInGrid.z; z++)
                {
                    Vector3 curentCell = new Vector3(grid.getCurrentCellByPosition(startPos).x + x, grid.getCurrentCellByPosition(startPos).y + y, grid.getCurrentCellByPosition(startPos).z + z);
                    grid.setCellBusy(curentCell, gridManager.cellBusyState.Void, null);
                     curentCell = new Vector3(grid.getCurrentCellByPosition(startPos).x + x, grid.getCurrentCellByPosition(startPos).y - y, grid.getCurrentCellByPosition(startPos).z + z);
                    grid.setCellBusy(curentCell, gridManager.cellBusyState.Void, null);
                }
            }
        }
  }
  }
}
