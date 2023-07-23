using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvas_manager : MonoBehaviour
{
    public static canvas_manager thisinstance = null;
    // Start is called before the first frame update
    public TMPro.TextMeshProUGUI player_score;
    public TMPro.TextMeshProUGUI ai_score;
    public TMPro.TextMeshProUGUI counter;
    static public bool conteo = false;

    static public string winner = "";
    void Start()
    {
        if (thisinstance == null){
            thisinstance = this;
        }

    }

    // Update is called once per frame
    void Update()   
    {
        int[] scores = mover.get_scores();
        if (scores[0] == 5 || scores[1] == 5){
            set_winner();
        }
        player_score.text = scores[0].ToString();
        ai_score.text = scores[1].ToString();
        if (conteo == true) { five_second_wait();conteo = false;}
    }

    void five_second_wait()
    {
        StartCoroutine(wait_1_second());
    }

    IEnumerator wait_1_second()
    {
        GameObject ball = GameObject.Find("Ball");
        ball.GetComponentInChildren<mover>().enabled = false; //quitar el movimiento de la pelota
        //ball.transform.position = new Vector3(0.0f, 0.0f, -0.1f);
        //ball.transform.rotation = Quaternion.identity;
        for (int count = 5; count >= 1; count--)
        {
            counter.text = count.ToString();
            yield return new WaitForSecondsRealtime(1.0f);
        }
        ball.GetComponentInChildren<mover>().enabled = true;
        counter.text = "";
    }

    public static void set_conteo()
    {
        conteo = true;
    }

    //al ganar marcar el jugador ganador(string) y pasar a la siguient escena que contiene los elementos de juego terminado.
    public void set_winner()
    {
        winner = GameObject.Find("Ball").GetComponent<mover>().get_last_touched();
        SceneManager.LoadScene("GameOver");
    }
}
