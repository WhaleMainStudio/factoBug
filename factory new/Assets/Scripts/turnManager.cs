using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class turnManager : MonoBehaviour
{
    void Start()
    {

            
             
        //     _piston.coroutineFlipFlop(true);

        //         if(turnManagerData.pistons[turnManagerData.pistons.IndexOf(_piston) - 1] != null)
        //         {
        //             piston _piston2 =  turnManagerData.pistons[turnManagerData.pistons.IndexOf(_piston) - 1];
        //             _piston2.coroutineFlipFlop(false); 
        //         }

         



       //  foreach (spawnedCube _cube in turnManagerData.cubes)
       // {
             
           // _cube.coroutineFlipFlop(true);

                // if(turnManagerData.cubes[turnManagerData.cubes.IndexOf(_cube) - 1] != null)
                // {
                //     piston _piston2 =  turnManagerData.cubes[turnManagerData.cubes.IndexOf(_cube) - 1];
                //     _piston2.coroutineFlipFlop(false); 
                // }

      //  }  
    }

    public void pistonTurn()
    {
         
         turnManagerData.pistonAction[turnManagerData.pistons.First()] = false;
            
         
    }

    void Update()
    {
        
    }
}
