using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager thisinstance = null;

    public TMPro.TextMeshProUGUI winner_banner;
    public UnityEngine.UI.Button restart_button;

    // Start is called before the first frame update
    void Start()
    {
        //singleton
        if (thisinstance == null)
        {
            thisinstance = this;
        }

        //poner en el banner el ganador
        string winner = canvas_manager.winner;
        if (winner == "Player_Bumper")
        {
            winner = "Player";
        }
        else { winner = "AI"; }
        winner_banner.text= winner+" won!!!";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
