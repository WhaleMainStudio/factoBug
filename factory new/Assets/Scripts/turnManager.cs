using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class turnManager : MonoBehaviour
{

    void Start()
    {
        // foreach (GameObject item in GameObject.FindGameObjectsWithTag("piston"))
        // {
        //     turnManagerData.pistons.Add(item.GetComponent<piston>());
        //     turnManagerData.pistonAction.Add(item.GetComponent<piston>(), false);
        // }

        //     foreach (GameObject item in GameObject.FindGameObjectsWithTag("spawner"))
        // {
        //     turnManagerData.spawners.Add(item.GetComponent<baseCubesSpawner>());
        //     turnManagerData.spawnerAction.Add(item.GetComponent<baseCubesSpawner>(), false);
        // }

        //         foreach (GameObject item in GameObject.FindGameObjectsWithTag("movingCube"))
        // {
        //     turnManagerData.cubes.Add(item.GetComponent<spawnedCube>());
        //     turnManagerData.cubesAction.Add(item.GetComponent<spawnedCube>(), false);
        // }

        //         foreach (GameObject item in GameObject.FindGameObjectsWithTag("fusion"))
        // {
        //     turnManagerData.fusions.Add(item.GetComponent<cubesFusion>());
        //     turnManagerData.fusionAction.Add(item.GetComponent<cubesFusion>(), false);
        // }


     //   turnManagerData.spawnerAction[turnManagerData.spawners.First()] = true;
        //         foreach (GameObject item in GameObject.FindGameObjectsWithTag("piston"))
        // {
        //     turnManagerData.validator.Add(item.GetComponent<validator>());
        //     turnManagerData.pistonAction.Add(item.GetComponent<validator>(), false);
        // }
    }
 public void nextTurnRoutine(string _object, int index)
 {
    switch (_object)
    {
       case "spawner":
                if(turnManagerData.cubes.Count > 0)
                { 
                    turnManagerData.cubesAction[turnManagerData.cubes.First()] = true;
                }
                else if(turnManagerData.pistons.Count > 0)
                {
                    turnManagerData.pistonAction[turnManagerData.pistons.First()] = true;
                }   
                else if(turnManagerData.fusions.Count > 0)
                {
                    turnManagerData.fusionAction[turnManagerData.fusions.First()] = true;
                    turnManagerData.fusions.First().addCubes();
                }
                else if(turnManagerData.spawners.Count > 0)
                {
                    turnManagerData.spawnerAction[turnManagerData.spawners.First()] = true;
                }

       break;
        
       case "piston":
                if(turnManagerData.fusions.Count > 0)
                {
                    turnManagerData.fusionAction[turnManagerData.fusions.First()] = true;
                    turnManagerData.fusions.First().addCubes();
                }
                else if(turnManagerData.cubes.Count > 0)
                { 
                    turnManagerData.cubesAction[turnManagerData.cubes.First()] = true;
                }
                else if(turnManagerData.pistons.Count > 0)
                {
                    turnManagerData.pistonAction[turnManagerData.pistons.First()] = true;
                }   
                else if(turnManagerData.spawners.Count > 0)
                {
                    turnManagerData.spawnerAction[turnManagerData.spawners.First()] = true;
                }    
       break;

       case "cube":

                if(turnManagerData.pistons.Count > 0)
                {
                    turnManagerData.pistonAction[turnManagerData.pistons.First()] = true;
                }   
                else if(turnManagerData.fusions.Count > 0)
                {
                    turnManagerData.fusionAction[turnManagerData.fusions.First()] = true;
                    turnManagerData.fusions.First().addCubes();
                }
                else if(turnManagerData.spawners.Count > 0)
                {
                    turnManagerData.spawnerAction[turnManagerData.spawners.First()] = true;
                }
                else if(turnManagerData.cubes.Count > 0)
                { 
                    turnManagerData.cubesAction[turnManagerData.cubes.First()] = true;
                }
       break;

       case "fusion":
                if(turnManagerData.spawners.Count > 0)
                {
                    turnManagerData.spawnerAction[turnManagerData.spawners.First()] = true;
                }  
                else if(turnManagerData.cubes.Count > 0)
                { 
                    turnManagerData.cubesAction[turnManagerData.cubes.First()] = true;
                }
                else if(turnManagerData.pistons.Count > 0)
                {
                    turnManagerData.pistonAction[turnManagerData.pistons.First()] = true;
                }   
                else if(turnManagerData.fusions.Count > 0)
                {
                    turnManagerData.fusionAction[turnManagerData.fusions.First()] = true;
                    turnManagerData.fusions.First().addCubes();
                }
      
       break;
    }
 }







  public void nextTurn(string _object, int index)
 {
    switch (_object)
    {
       case "spawner":         
                turnManagerData.spawnerAction[turnManagerData.spawners[index + 1]] = true;
       break;
        
       case "piston":
                turnManagerData.pistonAction[turnManagerData.pistons[index + 1]] = true;              
       break;

       case "cube":
                turnManagerData.cubesAction[turnManagerData.cubes[index + 1]] = true;
       break;

       case "fusion":
                turnManagerData.fusionAction[turnManagerData.fusions[index + 1]] = true;
                turnManagerData.fusions[index + 1].addCubes();        
       break;
    }
 }
}