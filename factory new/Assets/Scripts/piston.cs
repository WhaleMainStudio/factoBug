using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piston : MonoBehaviour
{
    [SerializeField] private List<GameObject> hitPoints;

   // [SerializeField] private GameObject Cubee;
        private gridManager grid;
    private float hitTime = 1f;
    private bool canHit = true;
    private bool flipFlop = false;
    

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
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x-1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
        }
        flipFlop = false;
        }
        else
        {
        foreach (var hitPoint in hitPoints)
        {
            
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x+1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
            hitCubes(hitPoint, grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(hitPoint.transform.position)));
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x+1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
            hitCubes(hitPoint,  grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(hitPoint.transform.position)));
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x+1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
            hitCubes(hitPoint,  grid.getCurrentPositionByCell(grid.getCurrentCellByPosition(hitPoint.transform.position)));
        }
        flipFlop = true;
        }

    }

    private void hitCubes(GameObject _hitPoint, Vector3 worldPos)
    {
        //Debug.Log(worldPos);
     // Instantiate(Cubee, _hitPoint.transform);
     //  worldPos = worldPos + new Vector3(1f,1f,0f);
       if(grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos)).tag == "movingCube")
       {
       // Destroy(grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos)));
       //if(grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos)).tag == "movingCube")
       // {
          //  grid.setCellBusy(grid.getCurrentCellByPosition(worldPos), gridManager.cellBusyState.Void, null);
           //  Debug.Log(grid.checkCellBusyObject(grid.getCurrentCellByPosition(_hitPoint.transform.position)).tag);
             GameObject _hitCube = grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos)).transform.parent.gameObject;
         //    Destroy(_hitCube);
            _hitCube.transform.position = new Vector3(_hitCube.transform.position.x, _hitCube.transform.position.y, _hitCube.transform.position.z-1);
          //  _hitPoint.GetComponent<spawnedCube>().
       //}
       }

    }
}
