using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    public DetectionSettings detectionSettings;
    public LayerMask playerLayer;
    public Light2D detectionLight;

    private bool isPlayerDetected = false;
    private float detectionTimer = 0f;
    private Color originalColor;

    private void Start()
    {
        originalColor = detectionLight.color;
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionSettings.range, playerLayer);
        isPlayerDetected = false;

        foreach (Collider2D collider in colliders)
        {
            castRunes runesComponent = collider.GetComponent<castRunes>();
            if (runesComponent != null && !runesComponent.hide)
            {
                isPlayerDetected = true;
                detectionTimer += Time.deltaTime;

                if (detectionTimer >= detectionSettings.time)
                {
                    SceneManager.LoadScene("Atrapado");
                    break;
                }
            }
        }

        if (isPlayerDetected)
        {
            detectionLight.color = Color.red;
        }
        else
        {
            detectionLight.color = originalColor;
        }

        if (!isPlayerDetected)
        {
            detectionTimer = 0f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionSettings.range);
    }
}
