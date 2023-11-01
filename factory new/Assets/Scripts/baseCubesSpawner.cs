using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        turnManagerData.spawners.Add(this);

        if(turnManagerData.spawners.First() == this)
        {
            turnManagerData.spawnerAction.Add(this, true);             
        }
        else
        {
             turnManagerData.spawnerAction.Add(this, false);
        }
        StartCoroutine(spawnCube());
    }

IEnumerator spawnCube() 
{
    while(spawnCubes)
    {
        yield return new WaitForSeconds(0.1f);

        if(grid.checkCellBusy(grid.getCurrentCellByPosition(spawnpoint.transform.position)) != gridManager.cellBusyState.Collider)
        {
            if(turnManagerData.spawnerAction[this] == true)
            {
                turnManagerData.spawnerAction[this] = false;
                Instantiate(cube, spawnpoint.transform.position, Quaternion.identity);
                if(turnManagerData.spawners.Last() == this)
                    {
                        if(turnManagerData.cubes.Count > 0)
                        {    
                          turnManagerData.cubesAction[turnManagerData.cubes.First()] = true;
                          Debug.Log("next first cube");
                        }
                        else
                        {
                          turnManagerData.spawnerAction[turnManagerData.spawners.First()] = true;
                        }
                    }
                    else
                    {
                    turnManagerData.spawnerAction[turnManagerData.spawners[turnManagerData.spawners.IndexOf(this) + 1]] = true;
                    }
            }
        }
        else
        {
            if(turnManagerData.spawnerAction[this] == true)
            {
                turnManagerData.spawnerAction[this] = false;
                if(turnManagerData.spawners.Last() == this)
                    {
                        if(turnManagerData.cubes.Count > 0)
                        {               
                          turnManagerData.cubesAction[turnManagerData.cubes.First()] = true;
                          Debug.Log("next first cube");
                        }
                        else
                        {
                          turnManagerData.spawnerAction[turnManagerData.spawners.First()] = true;
                        }
                    }
                    else
                    {
                    turnManagerData.spawnerAction[turnManagerData.spawners[turnManagerData.spawners.IndexOf(this) + 1]] = true;
                    }
            }
        }
    }
}

        void Update()
    {
        if(turnManagerData.spawnerAction[this] == true)
        {
      // Debug.Log(grid.getCurrentCellByPosition(this.transform.position) + "   " + grid.checkCellBusy(grid.getCurrentCellByPosition(this.transform.position)));
        }
    }
}
