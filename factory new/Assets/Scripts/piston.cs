// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;

// public class piston : MonoBehaviour
// {
//     [SerializeField] private List<GameObject> hitPoints;

//    // [SerializeField] private GameObject Cubee;
//         private gridManager grid;
//     private float hitTime = 1f;
//     private bool canHit = true;
//     private bool flipFlop = false;
//     private Dictionary<Vector3, gridManager.cellBusyState> cachesStates = new  Dictionary<Vector3, gridManager.cellBusyState>();
    

//     void Start()
//     {
//         grid = GameObject.Find("grid").GetComponent<gridManager>();
//         StartCoroutine(hit());
//     }

// IEnumerator hit() 
// {
//     while(canHit)
//     {
//         yield return new WaitForSeconds(hitTime);
//         hitEvent();  
//     }
// }

//     private void hitEvent()
//     {
//         if(flipFlop)
//         {
//         foreach (var hitPoint in hitPoints)
//         {
//           //  Debug.Log("1 " + grid.getCurrentCellByPosition(hitPoint.transform.position));
//             hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x-1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
//          //   Debug.Log("2 " + grid.getCurrentCellByPosition(hitPoint.transform.position));
//             flipFlopActive(false,grid.getCurrentCellByPosition(hitPoint.transform.position));
//             hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x-1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
//           //  Debug.Log("3 " + grid.getCurrentCellByPosition(hitPoint.transform.position));
//             flipFlopActive(false,grid.getCurrentCellByPosition(hitPoint.transform.position));
//            // hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x-1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
//         }
//         flipFlop = false;
//         }
//         else
//         {
//         foreach (var hitPoint in hitPoints)
//         {
//           //  Debug.Log("4 " + grid.getCurrentCellByPosition(hitPoint.transform.position));
//             hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x+1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
//             hitCubes(hitPoint, grid.getCurrentCellByPosition(hitPoint.transform.position));
//            // Debug.Log("5 " + grid.getCurrentCellByPosition(hitPoint.transform.position));
//             flipFlopActive(true, grid.getCurrentCellByPosition(hitPoint.transform.position));
//             hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x+1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
//             hitCubes(hitPoint,  grid.getCurrentCellByPosition(hitPoint.transform.position));
//          //   Debug.Log("6 " + grid.getCurrentCellByPosition(hitPoint.transform.position));
//              flipFlopActive(true, grid.getCurrentCellByPosition(hitPoint.transform.position));
             
//            // hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x+1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
//            // hitCubes(hitPoint,  grid.getCurrentCellByPosition(hitPoint.transform.position));
//         }
//         flipFlop = true;
//         }

//     }

//     private void hitCubes(GameObject _hitPoint, Vector3 worldPos)
//     {
//         //Debug.Log(worldPos);
//      // Instantiate(Cubee, _hitPoint.transform);
//      //  worldPos = worldPos + new Vector3(1f,1f,0f);
//      if(grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos)) != null)
//      {
//        if(grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos)).tag == "movingCube")
//        {
//     //   spawnedCube t = grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos)).GetComponent<spawnedCube>();
//     //   t.checkCurrentCell();
//    // Vector3 cell = grid.getCurrentCellByPosition(worldPos);
//    //    t.moveToCell((int)cell.x*-1,(int)cell.y,(int)cell.z*-1);
//      }
//      }
//        // grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos)).GetComponent<spawnedCube>().moveToCell();
//        // Destroy(grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos)));
//        //if(grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos)).tag == "movingCube")
//        // {
//           //  grid.setCellBusy(grid.getCurrentCellByPosition(worldPos), gridManager.cellBusyState.Void, null);
//            //  Debug.Log(grid.checkCellBusyObject(grid.getCurrentCellByPosition(_hitPoint.transform.position)).tag);
//          //    GameObject _hitCube = grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos)).transform.parent.gameObject;
//          //    Destroy(_hitCube);
//           //  _hitCube.transform.position = new Vector3(_hitCube.transform.position.x, _hitCube.transform.position.y, _hitCube.transform.position.z-1);
//           //  _hitPoint.GetComponent<spawnedCube>().
       
//      //  }

//     }




//       private void flipFlopActive(bool active, Vector3 newpos)
//     {
//         if(active)
//         {
//             cachesStates.Clear();
            
//             Vector3 currentCell = grid.getCurrentCellByPosition(this.transform.position);
//                if(this.transform.rotation.eulerAngles.y == 270)
//         {
//             cachesStates.Add(newpos + new Vector3(0,0,0), grid.checkCellBusy(newpos));
//            // cachesStates.Add(newpos + new Vector3(0,0,0), grid.checkCellBusy(newpos));
//            // cachesStates.Add(newpos + new Vector3(0,0,0), grid.checkCellBusy(newpos));
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z, gridManager.cellBusyState.MovementAddZ, null);
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z-1, gridManager.cellBusyState.MovementAddZ, null);
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z+1, gridManager.cellBusyState.MovementAddZ, null);


//             //  grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementAddZ, null);
//             //  grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementAddZ, null);
//              // grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementAddZ, null);

//             //  grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementAddZ, null);
//             //  grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementAddZ, null);
//              // grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementAddZ, null);
             
//         }
//                 if(this.transform.rotation.eulerAngles.y == 180)
//         {
//               cachesStates.Add(newpos, grid.checkCellBusy(newpos));
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z, gridManager.cellBusyState.MovementRemX, null);
//               cachesStates.Add(newpos - new Vector3(0,0,1), grid.checkCellBusy(newpos - new Vector3(0,0,1)));
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z-1, gridManager.cellBusyState.MovementRemX, null);
//               cachesStates.Add(newpos + new Vector3(0,0,1), grid.checkCellBusy(newpos + new Vector3(0,0,1)));
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z+1, gridManager.cellBusyState.MovementRemX, null);

//         //    Debug.Log(grid.checkCellBusy(newpos));
//             //  grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementRemX, null);
//            //  grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementRemX, null);
//             //  grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementRemX, null);

//             //  grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementRemX, null);
//             //  grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementRemX, null);
//             //  grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementRemX, null);
//         }
//                 if(this.transform.rotation.eulerAngles.y == 0)
//         {
//             cachesStates.Add(newpos + new Vector3(0,0,0), grid.checkCellBusy(newpos));
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z, gridManager.cellBusyState.MovementAddX, null);
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z-1, gridManager.cellBusyState.MovementAddX, null);
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z+1, gridManager.cellBusyState.MovementAddX, null);


//             //  grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementAddX, null);
//              // grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementAddX, null);
//              // grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementAddX, null);

//             //  grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementAddX, null);
//            //  grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementAddX, null);
//              // grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementAddX, null);
//         }
//                 if(this.transform.rotation.eulerAngles.y == 90)
//         {
//               cachesStates.Add(newpos + new Vector3(0,0,0), grid.checkCellBusy(newpos));
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z, gridManager.cellBusyState.MovementRemZ, null);
//               cachesStates.Add(newpos - new Vector3(0,0,1), grid.checkCellBusy(newpos));
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z-1, gridManager.cellBusyState.MovementRemZ, null);
//               cachesStates.Add(newpos + new Vector3(0,0,1), grid.checkCellBusy(newpos));
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z+1, gridManager.cellBusyState.MovementRemZ, null);


//             //  grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementRemZ, null);
//             //  grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementRemZ, null);
//              // grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.MovementRemZ, null);

//             //  grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementRemZ, null);
//             //  grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementRemZ, null);
//             //  grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.MovementRemZ, null);
//         }
//         }
//         else
//         {
            
//              Vector3 currentCell = grid.getCurrentCellByPosition(this.transform.position);
//              gridManager.cellBusyState test;
//               cachesStates.TryGetValue(newpos, out test);
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z, test, null);

//              // newpos = newpos - new Vector3(0,0,1);
//               cachesStates.TryGetValue(newpos - new Vector3(0,0,1), out test);
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z-1, test, null);

//             //  newpos = newpos + new Vector3(0,0,2);
//               cachesStates.TryGetValue(newpos + new Vector3(0,0,1), out test);
//               grid.setCellBusy(newpos.x, newpos.y, newpos.z+1, test, null);
//            //  newpos = newpos;
//             //  cachesStates.TryGetValue(newpos, out test);
//             //  grid.setCellBusy(newpos.x, newpos.y, newpos.z, test, null);

//             //  newpos = newpos -  new Vector3(0,0,1);
//             //  cachesStates.TryGetValue(newpos, out test);
//             //  grid.setCellBusy(newpos.x, newpos.y, newpos.z, test, null);

//             // newpos = newpos + new Vector3(0,0,2);
//             //  cachesStates.TryGetValue(newpos, out test);
//             //  grid.setCellBusy(newpos.x, newpos.y, newpos.z, test, null);
//             //  cachesStates.TryGetValue(newpos, out test);
//              // grid.setCellBusy(newpos.x, newpos.y, newpos.z, gridManager.cellBusyState.Void, null);
//             //  cachesStates.TryGetValue(newpos, out test);
//             //  grid.setCellBusy(newpos.x, newpos.y, newpos.z, gridManager.cellBusyState.Void, null);

//              // grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.Void, null);
//              // grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.Void, null);
//             //  grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z+1, gridManager.cellBusyState.Void, null);

//              // grid.setCellBusy(currentCell.x, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.Void, null);
//              // grid.setCellBusy(currentCell.x+1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.Void, null);
//             //  grid.setCellBusy(currentCell.x-1, currentCell.y+1, currentCell.z-1, gridManager.cellBusyState.Void, null);

//         }
//     }
// }



using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class piston : MonoBehaviour
{
    [SerializeField] private List<GameObject> hitPoints;

   // [SerializeField] private GameObject Cubee;
        private gridManager grid;
    private float hitTime = 1f;
    private bool canHit = true;
    private bool flipFlop = false;
    private Dictionary<Vector3, gridManager.cellBusyState> cachesStates = new  Dictionary<Vector3, gridManager.cellBusyState>();
    

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        StartCoroutine(hit());
    }

IEnumerator hit() 
{
    while(canHit)
    {
        yield return new WaitForSeconds(hitTime);
        hitEvent();  
    }
}

    private void hitEvent()
    {
        if(flipFlop)
        {
        foreach (var hitPoint in hitPoints)
        {
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x-1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x-1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
        }
        flipFlop = false;
        }
        else
        {
        foreach (var hitPoint in hitPoints)
        {
            
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x+1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
            flipFlopActive(true, grid.getCurrentCellByPosition(hitPoint.transform.position));
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x+1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
           flipFlopActive(true, grid.getCurrentCellByPosition(hitPoint.transform.position));
        }
        flipFlop = true;
        }

    }

      private void flipFlopActive(bool active, Vector3 newpos)
    {
        if(active)
        {
                if(grid.checkCellBusyObject(newpos) != null)
                {
                    if(grid.checkCellBusyObject(newpos).tag == "movingCube")
                    {
                        spawnedCube _cube = grid.checkCellBusyObject(newpos).GetComponent<spawnedCube>();

                                    if(this.transform.rotation.eulerAngles.y == 270)
                                {
                                  // _cube.transform.parent.transform.position += new Vector3(0,0,1);
                                   _cube.pistonned(newpos + new Vector3(0,0,1), grid.getCurrentCellByPosition(hitPoints[0].transform.position), grid.getCurrentCellByPosition(hitPoints[1].transform.position), grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                                }
                                        if(this.transform.rotation.eulerAngles.y == 180)
                                {
                                  // _cube.transform.position = grid.getCurrentPositionByCell(newpos - new Vector3(1,0,0));
                                  //  _cube.canMove = false;
                                   //_cube.moveToCell(newpos - new Vector3(1,0,0));
                                   _cube.pistonned(newpos - new Vector3(1,0,0), grid.getCurrentCellByPosition(hitPoints[0].transform.position), grid.getCurrentCellByPosition(hitPoints[1].transform.position), grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                                   // _cube.canMove = false;
                                   //_cube.checkCurrentCell();
                                  // _cube.canMove = true;
                                }
                                        if(this.transform.rotation.eulerAngles.y == 0)
                                {
                                    _cube.pistonned(newpos + new Vector3(1,0,0), grid.getCurrentCellByPosition(hitPoints[0].transform.position), grid.getCurrentCellByPosition(hitPoints[1].transform.position), grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                                //  _cube.transform.parent.transform.position += new Vector3(1,0,0);
                                }
                                        if(this.transform.rotation.eulerAngles.y == 90)
                                {
                                    _cube.pistonned(newpos - new Vector3(0,0,1), grid.getCurrentCellByPosition(hitPoints[0].transform.position), grid.getCurrentCellByPosition(hitPoints[1].transform.position), grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                                  //  _cube.transform.parent.transform.position += new Vector3(1,0,0);
                                }
                    }
                }
        }
        else
        {  

        }
    }


     private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        for (int x = 0; x < 1; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                for (int z = 0; z < 1; z++)
                {
                    if(grid != null)
                    {
                    Vector3 cellCenter = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(hitPoints[0].transform.position));
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireCube(cellCenter, new Vector3(1, 1, 1));

                                        Vector3 cellCenter2 = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(hitPoints[1].transform.position));
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireCube(cellCenter2, new Vector3(1, 1, 1));

                                        Vector3 cellCenter3 = grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(hitPoints[2].transform.position));
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireCube(cellCenter3, new Vector3(1, 1, 1));
                    }

                }
            }
        }
    }
}
