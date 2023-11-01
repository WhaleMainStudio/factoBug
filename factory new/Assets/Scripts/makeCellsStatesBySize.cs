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
