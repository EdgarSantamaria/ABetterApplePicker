using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //This line enables use of uGUI classes like Text.

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;

    private Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString("#,0"); //This 0 is a zero!
    }
}
