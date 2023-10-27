using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piston : MonoBehaviour
{
    [SerializeField] private List<GameObject> hitPoints;
        private gridManager grid;
    private float hitTime = 1f;
    private bool canHit = true;
    private bool flipFlop = false;
    

    void Start()
    {
        grid = GameObject.Find("grid").GetComponent<gridManager>();
        StartCoroutine(hit());

        //         grid = GameObject.Find("grid").GetComponent<gridManager>();
        // Vector3 spawnCell = grid.getCurrentCellByPosition(this.transform.position);
        
        // Instantiate(cube, grid.getCurrentPositionByCell((int)spawnCell.x, (int)spawnCell.y, (int)spawnCell.z), Quaternion.identity);
        
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
            hitCubes(hitPoint, hitPoint.transform.position);
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x+1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
            hitCubes(hitPoint, hitPoint.transform.position);
            hitPoint.transform.localPosition = new Vector3(hitPoint.transform.localPosition.x+1, hitPoint.transform.localPosition.y, hitPoint.transform.localPosition.z);
           
        }
        flipFlop = true;
        }

    }

    private void hitCubes(GameObject _hitPoint, Vector3 worldPos)
    {
      
        //worldPos = worldPos + new Vector3(1f,0f,0f);
       if(grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos)) != null)
        {
             Debug.Log(grid.checkCellBusyObject(grid.getCurrentCellByPosition(_hitPoint.transform.position)).tag);
             GameObject _hitCube = grid.checkCellBusyObject(grid.getCurrentCellByPosition(worldPos));
             Destroy(_hitCube);
          //  _hitCube.transform.position = new Vector3(_hitPoint.transform.position.x+10, _hitPoint.transform.position.y, _hitPoint.transform.position.z);
          //  _hitPoint.GetComponent<spawnedCube>().
       }
    }
}
