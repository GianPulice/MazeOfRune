using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Image enemyDetectionPanel; // Agregar esta línea para el panel de detección de enemigos
    public float detectionRange = 10f; // Rango de detección de enemigos
    public LayerMask enemyLayer; // Capa de los enemigos
    public float fillSpeed = 0.5f; // Velocidad de incremento del fillAmount

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange, enemyLayer);
        
        // Nueva lógica para incrementar fillAmount
        if (colliders.Length > 0) // Si hay enemigos en el rango
        {
            enemyDetectionPanel.fillAmount += Time.deltaTime * fillSpeed; // Aumentar fillAmount por segundo
            enemyDetectionPanel.fillAmount = Mathf.Clamp(enemyDetectionPanel.fillAmount, 0, 1); // Limitar entre 0 y 1
        }
        else
        {
            enemyDetectionPanel.fillAmount = 0; // Reiniciar si no hay enemigos
        }
    }
}
