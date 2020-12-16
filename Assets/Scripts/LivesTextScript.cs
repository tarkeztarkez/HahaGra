using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = GameHandler.lives.ToString();
        if(GameHandler.immortalityTimer.GetTimeRemaining() > 0)
        {
            GetComponent<Text>().color = Color.green;
        }
        else
        {
            GetComponent<Text>().color = Color.black;
        }

    }
}
