using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeplacementPointAndClick : MonoBehaviour
{
    public Camera cam; // R�f�rence � la cam�ra
    public NavMeshAgent agent; // R�f�rence � l'agent de navigation
    public LayerMask groundLayer; // Couche du sol

    // Fonction appel�e � chaque frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // V�rifie si le bouton gauche de la souris est enfonc�
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); // Cr�e un rayon � partir de la position de la souris

            RaycastHit hit; // Variable pour stocker les informations sur l'intersection avec le sol

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer)) // Lance un rayon et v�rifie s'il intersecte le sol
            {
                agent.SetDestination(hit.point); // D�finit la destination de l'agent de navigation sur le point d'intersection
            }
        }
    }
}

