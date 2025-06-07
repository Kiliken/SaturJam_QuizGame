using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using Unity.VectorGraphics.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private SVGImage flagDisplay;

    [SerializeField]
    private Button[] buttons;

    private float timer;
    private bool correct = true;
    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( correct )
        {
            currentIndex = UnityEngine.Random.Range(0, Flags.list.Length);
            flagDisplay.sprite = Resources.Load<Sprite>($"Flags/{Flags.list[currentIndex].ToLower()}");

            foreach ( var button in buttons )
            {
                button.gameObject.SetActive(true);
                button.GetComponentInChildren<TextMeshProUGUI>().text = Flags.list[UnityEngine.Random.Range(0, Flags.list.Length)];
            }

            buttons[UnityEngine.Random.Range(0, buttons.Length)].GetComponentInChildren<TextMeshProUGUI>().text = Flags.list[currentIndex];

            correct = false;
        }
    }

    public void CheckButton(int index)
    {
        if(buttons[index].GetComponentInChildren<TextMeshProUGUI>().text == Flags.list[currentIndex])
            correct = true;
        else 
            buttons[index].gameObject.SetActive(false);
    }
}
