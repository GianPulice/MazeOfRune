using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text manaText;
    void Start()
    {


        player = GameObject.FindGameObjectWithTag("Player");

    }


    void Update()
    {

        UpdateManaText();

        if (mana <= maxMana)
        {
            manaIncres(1);
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

        // Cambia el sprite del jugador a negro
        player.GetComponent<SpriteRenderer>().color = Color.black;


        yield return new WaitForSeconds(3f);


        player.GetComponent<SpriteRenderer>().color = Color.white;
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
                return new string[2];
            case "OscuirdadLuz":
                Debug.Log(" Oscuridad + Luz");
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

    void UpdateManaText()
    {
        if (manaText != null) 
        {
            manaText.text = "Mana: " + Mathf.RoundToInt(mana); 
        }
    }
}