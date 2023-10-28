using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseCubesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject spawnpoint;
        private gridManager grid;
    [SerializeField] private float spawnTime = 2f;
    private bool spawnCubes = true;
    

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        StartCoroutine(spawnCube());
    }

IEnumerator spawnCube() 
{
    while(spawnCubes)
    {
        yield return new WaitForSeconds(spawnTime);

        if(grid.checkCellBusy(grid.getCurrentCellByPosition(spawnpoint.transform.position)) != gridManager.cellBusyState.Collider)
        {
            Instantiate(cube, spawnpoint.transform.position, Quaternion.identity);
        }
    }
}
}
