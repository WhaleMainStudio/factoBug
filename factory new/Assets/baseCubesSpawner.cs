using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseCubesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject spawnpoint;
        private gridManager grid;
    private float spawnTime = 1f;
    private bool spawnCubes = true;
    

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        StartCoroutine(spawnCube());

        //         grid = GameObject.Find("grid").GetComponent<gridManager>();
        // Vector3 spawnCell = grid.getCurrentCellByPosition(this.transform.position);
        
        // Instantiate(cube, grid.getCurrentPositionByCell((int)spawnCell.x, (int)spawnCell.y, (int)spawnCell.z), Quaternion.identity);
        
    }

IEnumerator spawnCube() 
{
    while(spawnCubes)
    {
        yield return new WaitForSeconds(spawnTime);

        if(grid.checkCellBusy(grid.getCurrentCellByPosition(spawnpoint.transform.position)) != gridManager.cellBusyState.Collider)
        {
            Instantiate(cube, spawnpoint.transform.position, Quaternion.identity);
           // Debug.Log("spawn");
        }
        
    }
}
}
