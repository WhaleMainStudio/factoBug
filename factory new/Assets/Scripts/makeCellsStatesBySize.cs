using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeCellsStatesBySize : MonoBehaviour
{
        private gridManager grid;
    [SerializeField] private Vector3 sizeInGrid;
    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();

  for (int x = 0; x < sizeInGrid.x; x++)
        {
            for (int y = 0; y < sizeInGrid.y; y++)
            {
                for (int z = 0; z < sizeInGrid.z; z++)
                {
                    if(grid != null)
                    {
                    Vector3 cellCenter = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(this.transform.position));
                    grid.setCellBusy(new Vector3(x,y,z), gridManager.cellBusyState.Collider, this.gameObject);
                    }
                }
            }
        }
//x
// for (int i = 0; i < sizeInGrid.x; i++)
// {
//     Vector3 curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(i,0,0);
//     grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

//      curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(-i,0,0);
//     grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
// }
// for (int i = 0; i < sizeInGrid.y; i++)
// {
//     Vector3 curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(0,i,0);
//     grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

//      curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(0,-i,0);
//     grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
// }
// for (int i = 0; i < sizeInGrid.z; i++)
// {
//     Vector3 curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(0,0,i);
//     grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

//      curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(0,0,-i);
//     grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
// }
       // for (int i = -1; i < 2; i++)
      //  {
        //    curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(1,0,0);
        //   grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

        //              curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(-1,0,0);
        //   grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

        //              curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(0,0,0);
        //   grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);



        //              curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(0,0,1);
        //   grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

        //              curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(0,0,-1);
        //   grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

        //                        curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(-1,0,-1);
        //   grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

        //                        curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(1,0,-1);
        //   grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

        //                        curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(1,0,1);
        //   grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);

        //                        curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(-1,0,1);
        //   grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);


       // }

        // for (int i = -1; i < 2; i++)
        // {
        //   Vector3 curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(0,i,0);
        //   grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
        // }

        // for (int i = -1; i < 2; i++)
        // {
        //   Vector3 curentCell = grid.getCurrentCellByPosition(this.transform.position) + new Vector3(0,0,i);
        //   grid.setCellBusy(curentCell, gridManager.cellBusyState.Collider, this.gameObject);
        // }
        
    }

      private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        for (int x = 0; x < sizeInGrid.x; x++)
        {
            for (int y = 0; y < sizeInGrid.y; y++)
            {
                for (int z = 0; z < sizeInGrid.z; z++)
                {
                    if(grid != null)
                    {
                    Vector3 cellCenter = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(this.transform.position));
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireCube(cellCenter, new Vector3(sizeInGrid.x, sizeInGrid.y, sizeInGrid.z));
                    }
                }
            }
        }
    }
}
