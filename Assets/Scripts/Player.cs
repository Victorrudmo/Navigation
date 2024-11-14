using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public LayerMask layerFloor;
    public Transform routeFather;
    int indexChildren;
    Vector3 destination;

    public Vector3 min, max;
    private void Start()
    {
        //destination = routeFather.GetChild(indexChildren).position;
        destination = RandomDestination();
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }
    private void Update()
    {   
        #region movimiento por click
        //if(Input.GetButtonDown("Fire1"))
        //{
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit = new RaycastHit();
            //if(Physics.Raycast(ray, out hit, 1000, layerFloor))
            //{
                //GetComponent<NavMeshAgent>().SetDestination(hit.point);
            //}
        //}
        #endregion
        #region movimiento por puntos de control    
        //if(Vector3.Distance(transform.position, destination) < 2.5f)
        //{
            //indexChildren = Random.Range(0, routeFather.childCount);
            //destination = routeFather.GetChild(indexChildren).position;
            //GetComponent<NavMeshAgent>().SetDestination(destination);
        //}
        #endregion
        #region movimiento delimitado
        //if(Vector3.Distance(transform.position, destination) < 2.5f)
        //{
            //destination = RandomDestination();
            //GetComponent<NavMeshAgent>().SetDestination(destination);
        //}
        #endregion

        if(Vector3.Distance(transform.position, destination) < 2.5f)
        {   
            Vector3 randomPoint = Random.insideUnitSphere * 50;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomPoint, out hit, 50, 1);
            destination = hit.position;
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
    }

    Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
    }
}

