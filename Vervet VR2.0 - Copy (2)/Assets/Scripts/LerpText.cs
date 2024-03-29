using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LerpText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.currentColor = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, 1));
        this.currentColor = Color.Lerp(color2, color1, Mathf.PingPong(Time.time, 1));
        this.text.color = currentColor;
    }

    private float speed = 1f;
	private Color currentColor = Color.red;
    [SerializeField] private TextMeshPro text;
    public Color color1;
    public Color color2;
}
