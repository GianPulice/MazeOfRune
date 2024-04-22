using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class castRunes : MonoBehaviour
{
    private int maxMana = 100;
    public float mana = 100;
    private string[] inputs = new string[2];
    public Slider manaBar;
    private Queue<ICommand> commandQueue = new Queue<ICommand>();

   
    void Start()
    {
        manaBar.minValue = 0;
        manaBar.maxValue = maxMana;
        manaBar.value = mana;
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

    string[] Combination(string[] inputs)
    {
        string combination = inputs[0] + inputs[1];

        switch (combination)
        {
            case "h1h1":
                Debug.Log("h1 + h1");
                return new string[2];
            case "h1h2":
                Debug.Log(" h1 + h2");
                return new string[2];
            case "h2h1":
                Debug.Log(" h2 + h1");
                return new string[2];
            case "h2h2":
                Debug.Log("h2 + h2");
                return new string[2];
            default:
                Debug.Log("no reconocida");
                return inputs; 
        }
    }
}