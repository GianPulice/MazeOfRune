using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRune1 : ICommand
{
    private string[] _inputs;

    public AddRune1(string[] inputs)
    {
        _inputs = inputs;
    }

    public void Execute()
    {
        for (int i = 0; i < _inputs.Length; i++)
        {
            if (string.IsNullOrEmpty(_inputs[i]))
            {
                _inputs[i] = "h1";
                break; 
            }
        }
    }
}
