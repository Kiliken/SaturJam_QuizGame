using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using Unity.VectorGraphics.Editor;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private SVGImage flagDisplay;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, Flags.list.Length);
        flagDisplay.sprite = Resources.Load<Sprite>($"Flags/{Flags.list[index].ToLower()}");
    }

    // Update is called once per frame
    void Update()
    {
        if( Time.time - timer > 2f )
        {            
            int index = Random.Range(0, Flags.list.Length);
            flagDisplay.sprite = Resources.Load<Sprite>($"Flags/{Flags.list[index].ToLower()}");
            timer = Time.time;
        }
    }
}
