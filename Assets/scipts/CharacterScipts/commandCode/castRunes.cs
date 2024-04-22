using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class castRunes : MonoBehaviour
{

    private GameObject player;
    private int maxMana = 100;
    public float mana = 100;
    private string[] inputs = new string[2];
    public Slider manaBar;
  
    private Queue<ICommand> commandQueue = new Queue<ICommand>();

    public Camera mainCamera;
    public Camera otherCamera;
    public float cameraSwitchDuration = 2f;

    void Start()
    {
        manaBar.minValue = 0;
        manaBar.maxValue = maxMana;
        manaBar.value = mana;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    
    void Update()
    {
        manaIncres();
        manaBar.value = mana;

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

    void manaIncres()
    {
        mana += 1 * Time.deltaTime;
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
}