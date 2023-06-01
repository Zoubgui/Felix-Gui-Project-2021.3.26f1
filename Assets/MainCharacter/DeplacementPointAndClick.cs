using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeplacementPointAndClick : MonoBehaviour
{
    public Camera cam; // R�f�rence � la cam�ra
    public NavMeshAgent agent; // R�f�rence � l'agent de navigation
    public LayerMask groundLayer; // Couche du sol
    public bool isSelected = false;
    bool rayCast;
    private Vector3 mousePosition;
    public GameObject fire;

    
    void Update()
    {
        Debug.DrawLine(transform.position, Vector3.back);

        mousePosition = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePosition); // Cr�e un rayon � partir de la position de la souris
        RaycastHit hit;   // Variable pour stocker les informations sur l'intersection avec le sol
        rayCast = Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer);
        agent.SetDestination(gameObject.transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            isSelected = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSelected = false;
            agent.destination = gameObject.transform.localPosition;
        }

        if (rayCast == false)
        {
            agent.destination = gameObject.transform.localPosition;
        }

        if (isSelected && rayCast)
        {
            Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer); // Lance un rayon et v�rifie s'il intersecte le sol
            agent.SetDestination(hit.point); // D�finit la destination de l'agent de navigation sur le point d'intersection
        }

        //attack

        if (Input.GetKeyDown(KeyCode.A))
        {
            fire.SetActive(true);

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            fire.SetActive(false);
            Debug.Log("Attack");

        }

       

    }
}

