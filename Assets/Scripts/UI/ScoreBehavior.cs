using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class ScoreBehavior : MonoBehaviour
{
    private Text _text;

    private void Start() {
        _text = GetComponent<Text>();
    }
    
    private void Update()
    {
        _text.text = "Score: " + GameManager.Instance.Score.ToString(); 
    }
}
