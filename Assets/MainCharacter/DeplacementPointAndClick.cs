using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeplacementPointAndClick : MonoBehaviour
{
    public Camera cam; // Référence à la caméra
    public NavMeshAgent agent; // Référence à l'agent de navigation
    public LayerMask groundLayer; // Couche du sol

    // Fonction appelée à chaque frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Vérifie si le bouton gauche de la souris est enfoncé
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); // Crée un rayon à partir de la position de la souris

            RaycastHit hit; // Variable pour stocker les informations sur l'intersection avec le sol

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer)) // Lance un rayon et vérifie s'il intersecte le sol
            {
                agent.SetDestination(hit.point); // Définit la destination de l'agent de navigation sur le point d'intersection
            }
        }
    }
}

