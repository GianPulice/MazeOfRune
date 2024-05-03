using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRune2 : ICommand
{

    private string[] _inputs;

    public AddRune2(string[] inputs)
    {
        _inputs = inputs;
    }

    public void Execute()
    {
        for (int i = 0; i < _inputs.Length; i++)
        {
            if (string.IsNullOrEmpty(_inputs[i]))
            {
                _inputs[i] = "Oscuirdad";
                break; 
            }
        }
    }
}
