
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridManager : MonoBehaviour
{
    public int gridSizeX = 5;
    public int gridSizeY = 5;
    public int gridSizeZ = 5;
    public float cellSize = 1f;

    private Dictionary<Vector3, cellBusyState> cellsStates = new Dictionary<Vector3, cellBusyState>();
    private Dictionary<Vector3, GameObject> cellsObjects = new Dictionary<Vector3, GameObject>();

     public enum cellBusyState
    {
        Void,
        MovementAddX,
        MovementRemX,
        MovementAddZ,
        MovementRemZ,
        Fusion,
        Collider
    }

    private Vector3 test;
    public void setCellBusy(float x, float y, float z, cellBusyState state, GameObject gameObjectRef)
    {
        Vector3 cellKey = new Vector3((float)x, (float)y, (float)z);

        if (cellsStates.ContainsKey(cellKey))
        {
            cellsStates[cellKey] = state;

                       if(gameObjectRef != null)
            {
            cellsObjects[cellKey] = gameObjectRef;
            }
        }
        else
        {
            cellsStates.Add(cellKey, state);

                        if(gameObjectRef != null)
            {
            cellsObjects.Add(cellKey, gameObjectRef);
            }
        }

    }

        public void setCellBusy(Vector3 cellID, cellBusyState state, GameObject gameObjectRef)
    {
        Vector3 cellKey = cellID;

        if (cellsStates.ContainsKey(cellKey))
        {
            cellsStates[cellKey] = state;

            if(gameObjectRef != null)
            {
            cellsObjects[cellKey] = gameObjectRef;
            }
        }
        else
        {
            cellsStates.Add(cellKey, state);

            if(gameObjectRef != null)
            {
            cellsObjects.Add(cellKey, gameObjectRef);
            }
            
        }
    }


     public cellBusyState checkCellBusy(int x, int y, int z)
     {
        Vector3 cellKey = new Vector3((float)x, (float)y, (float)z); 
        cellsStates.TryGetValue(cellKey, out cellBusyState cellState);
        return cellState;
     }

          public cellBusyState checkCellBusy(Vector3 _cellKey)
     {
        Vector3 cellKey = _cellKey; 
        cellsStates.TryGetValue(cellKey, out cellBusyState cellState);
        return cellState;
     }

          public GameObject checkCellBusyObject(int x, int y, int z)
     {
        Vector3 cellKey = new Vector3((float)x, (float)y, (float)z); 
        cellsObjects.TryGetValue(cellKey, out GameObject cellObject);
        return cellObject;
     }

          public GameObject checkCellBusyObject(Vector3 _cellKey)
     {
        Vector3 cellKey = _cellKey; 
        cellsObjects.TryGetValue(cellKey, out GameObject cellObject);
        return cellObject;
     }

     


    public Vector3 getCurrentCellByPosition(Vector3 worldPosition)
    {
        Vector3 localPosition = worldPosition - transform.position;
        int x = Mathf.FloorToInt(localPosition.x / cellSize);
        int y = Mathf.FloorToInt(localPosition.y / cellSize);
        int z = Mathf.FloorToInt(localPosition.z / cellSize);

        x = Mathf.Clamp(x, 0, gridSizeX - 1);
        y = Mathf.Clamp(y, 0, gridSizeY - 1);
        z = Mathf.Clamp(z, 0, gridSizeZ - 1);

        return new Vector3(x, y, z);
    }

        public Vector3 getCurrentCellByPosition(int _x, int _y, int _z)
    {
        Vector3 localPosition = (new Vector3(_x,_y,_z)) - transform.position;
        int x = Mathf.FloorToInt(localPosition.x / cellSize);
        int y = Mathf.FloorToInt(localPosition.y / cellSize);
        int z = Mathf.FloorToInt(localPosition.z / cellSize);

        x = Mathf.Clamp(x, 0, gridSizeX - 1);
        y = Mathf.Clamp(y, 0, gridSizeY - 1);
        z = Mathf.Clamp(z, 0, gridSizeZ - 1);

        return new Vector3(x, y, z);
    }

    
    public Vector3 getCurrentPositionByCell(int x, int y, int z)
    {
        float posX = x * cellSize + cellSize / 2;
        float posY = y * cellSize + cellSize / 2;
        float posZ = z * cellSize + cellSize / 2;
        return new Vector3(posX, posY, posZ);
    }

        public Vector3 getCurrentPositionByCell(Vector3 _vector)
    {
        float posX = _vector.x * cellSize + cellSize / 2;
        float posY = _vector.y * cellSize + cellSize / 2;
        float posZ = _vector.z * cellSize + cellSize / 2;
        return new Vector3(posX, posY, posZ);
    }



    public Vector3 WorldToGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / cellSize);
        int y = Mathf.FloorToInt(worldPosition.y / cellSize);
        int z = Mathf.FloorToInt(worldPosition.z / cellSize);

        x = Mathf.Clamp(x, 0, gridSizeX - 1);
        y = Mathf.Clamp(y, 0, gridSizeY - 1);
        z = Mathf.Clamp(z, 0, gridSizeZ - 1);

        return new Vector3(x, y, z);
    }

    public Vector3 GetGridDimensions()
    {
        return new Vector3(gridSizeX, gridSizeY, gridSizeZ);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    Vector3 cellCenter = getCurrentPositionByCell(x, y, z);
                    Gizmos.DrawWireCube(cellCenter, new Vector3(cellSize, cellSize, cellSize));
                }
            }
        }
    }
}
