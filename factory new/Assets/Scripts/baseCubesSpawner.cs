using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class baseCubesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject spawnpoint;
        private gridManager grid;
    [SerializeField] private float spawnTime = 0.1f;
    private bool spawnCubes = true;
    private turnManager _turnManager;
    

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        _turnManager = GameObject.Find("Managers").GetComponent<turnManager>();
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
        yield return new WaitForSeconds(spawnTime);

        if(grid.checkCellBusy(grid.getCurrentCellByPosition(spawnpoint.transform.position)) != gridManager.cellBusyState.Collider && (grid.checkCellBusy(grid.getCurrentCellByPosition(spawnpoint.transform.position - new Vector3(0,1,0))) != gridManager.cellBusyState.Void))
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
                         }
                        _turnManager.nextTurnRoutine("spawner", turnManagerData.spawners.IndexOf(this));
                    }
                    else
                    {
                        _turnManager.nextTurn("spawner", turnManagerData.spawners.IndexOf(this));
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
                        _turnManager.nextTurnRoutine("spawner", turnManagerData.spawners.IndexOf(this));
                     }
                    else
                     {
                        _turnManager.nextTurn("spawner", turnManagerData.spawners.IndexOf(this));
                     }
            }
        }
    }
}


    // void Update()
    // {
    //             if(turnManagerData.spawners.Contains(this))
    //     {
    //     if(turnManagerData.spawnerAction[turnManagerData.spawners[turnManagerData.spawners.IndexOf(this)]] == true)
    //     {
    //     Debug.Log("tour de spawners");
    //     }
    //     }
    // }
}
