using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharactermoov : MonoBehaviour
{
    [SerializeField] float MooveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal"); // Obtient l'entrée horizontale (touches A et D ou les flèches gauche et droite)
        float deplacementVertical = Input.GetAxis("Vertical"); // Obtient l'entrée verticale (touches W et S ou les flèches haut et bas)

        // Calcule le vecteur de déplacement
        Vector3 deplacement = new Vector3(deplacementHorizontal, 0f, deplacementVertical) * MooveSpeed * Time.deltaTime;

        // Applique le déplacement à la position de l'objet
        transform.Translate(deplacement);
    }
}
