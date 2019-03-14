using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour // Io gestisco il punteggio
{
    public Text ScoreText;
    float Timer;
    int Score;
    // Update is called once per frame
    void Update()
    {
        ScoreUp(); // Qui è dove aggiorno il punteggio
    }

    void ScoreUp() // Qui aumento il punteggio
    {
        ScoreText.text = ("SCORE:" + Score.ToString()); // Qui visualizzo il punteggio
        Timer += Time.deltaTime; // Qui tengo il tempo per il punteggio
        Score = (int)(Timer * 10); // Qui conteggio il punteggio
    }
}
