using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class castRunes : MonoBehaviour
{

    private GameObject player;
    public int maxMana = 60;
    public float mana = 60;
    private string[] inputs = new string[2];

    private Queue<ICommand> commandQueue = new Queue<ICommand>();

    public Camera mainCamera;
    public Camera otherCamera;
    public float cameraSwitchDuration = 2f;

    public bool hide = false;

    public GameObject keyAsset;
    public float OnTime = 1f;
    public float detectionRange = 2f;
    public LayerMask doorLayer;

    public GameObject fire;
    public LayerMask pieceLayer;

    public Image manaPanel; // Cambiar de Image a RectTransform para el panel

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        // Asegúrate de que el tipo de imagen sea "Filled"
        if (manaPanel != null)
        {
            manaPanel.type = Image.Type.Filled; // Establecer el tipo de imagen a "Filled"
            manaPanel.fillMethod = Image.FillMethod.Vertical; // Método de llenado vertical
        }
    }


    void Update()
    {
        UpdateManaBar(); // Llamar a la función para actualizar la barra de mana

        if (mana <= maxMana)
        {
            manaIncres(5);
        }



        if (mana >= 20)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                commandQueue.Enqueue(new AddRune1(inputs));
                mana -= 20;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                commandQueue.Enqueue(new AddRune2(inputs));
                mana -= 20;
            }
        }


        while (commandQueue.Count > 0)
        {
            ICommand command = commandQueue.Dequeue();
            command.Execute();
            inputs = Combination(inputs);

        }
    }

    public void manaIncres(float cant)
    {
        mana += cant * Time.deltaTime;
    }


    IEnumerator SwitchToOtherCamera()
    {
        otherCamera.enabled = true;
        mainCamera.enabled = false;
        yield return new WaitForSeconds(cameraSwitchDuration);
        otherCamera.enabled = false;
        mainCamera.enabled = true;
    }

    IEnumerator ChangePlayerSprite()
    {

        Sprite originalSprite = player.GetComponent<SpriteRenderer>().sprite;

        player.GetComponent<SpriteRenderer>().color = Color.black;
        hide = true;

        yield return new WaitForSeconds(4f);


        player.GetComponent<SpriteRenderer>().color = Color.white;
        hide = false;
    }

    void DisableDoor()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange, doorLayer);

        foreach (Collider2D collider in colliders)
        {
            collider.gameObject.SetActive(false);
        }
    }

    void FirePiece()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange, pieceLayer);

        foreach (Collider2D collider in colliders)
        {
            collider.gameObject.SetActive(false);
        }
    }

    IEnumerator Key()
    {
        keyAsset.SetActive(true); 
        yield return new WaitForSeconds(OnTime); 
        keyAsset.SetActive(false);

        Debug.Log("key on");
    }


    IEnumerator Fire()
    {
        fire.SetActive(true);
        yield return new WaitForSeconds(OnTime);
        fire.SetActive(false);

        Debug.Log("fire on");
    }

    string[] Combination(string[] inputs)
    {
        string combination = inputs[0] + inputs[1];

        switch (combination)
        {
            case "LuzLuz":
                Debug.Log("Luz + Luz");
                StartCoroutine(SwitchToOtherCamera());
                return new string[2];

            case "LuzOscuirdad":
                Debug.Log(" Luz + Oscuridad");
                DisableDoor();
                StartCoroutine(Key());
                return new string[2];

            case "OscuirdadLuz":
                Debug.Log(" Oscuridad + Luz");
                FirePiece();
                StartCoroutine(Fire());
                return new string[2];

            case "OscuirdadOscuirdad":
                Debug.Log("Oscuridad + Oscuridad");
                StartCoroutine(ChangePlayerSprite());
                return new string[2];

            default:
                Debug.Log("no reconocida");
                return inputs;
        }
    }

    void UpdateManaBar() // Nueva función para actualizar el panel de mana
    {
        if (manaPanel != null)
        {
            manaPanel.fillAmount = mana / maxMana;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
