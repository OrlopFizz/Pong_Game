using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class mover : MonoBehaviour
{
    public float velocity = 0f;
    public Vector3 dir= Vector3.zero;
    private GameObject last_touched;
    private Bounds game_bounds;
    [SerializeField]
    private GameObject player_bumper;
    [SerializeField]
    private GameObject ai_bumper;

    private static int player_points;
    private static int ai_points;
    private Vector3 center = new Vector3(0f, 0f, -0.1f);
    // Start is called before the first frame update
    void Start()
    {
        dir = transform.right;
        game_bounds = GameObject.Find("Pong_Background").GetComponent<SpriteRenderer>().bounds;
        last_touched = ai_bumper;
        player_points = 0; 
        ai_points = 0;

    }

    //Update is called once per frame
    private void Update()
    {
        if (!game_bounds.Contains(transform.position))
        {
            //salio del campo de juego, marcar punto y mandar otra vez la pelota al centro. 
            if (last_touched.name == "Player_Bumper")
            {
                player_points += 1;
            }
            else
            {
                ai_points += 1;
            }
            transform.position = center;
            dir = transform.right;
            player_bumper.transform.position = new Vector3(-11f, 0f, -0.1f);
            ai_bumper.transform.position = new Vector3(10.8f, 0f, -0.1f);
            if (player_points != 5 && ai_points != 5) { 
                last_touched = ai_bumper; 
            }
            canvas_manager.set_conteo();
        }
    }

    private void FixedUpdate()
    {
        transform.position += dir * (velocity * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //el manejo de la colision. si pega arriba del bumper se manda 45 grados para arriba. 
        //si pega abajo, se va para abajo.
        //si pega en el centro. se manda directamente en frente. 

        //primero comparar las posiciones en y de la bola con el bumper. esto con el proposito de saber de que parte de la raqueta estan. 
        //si es positivo, pego arriba.
        //si es negativo, quedo abajo.
        if (collision.gameObject.tag == "Bumper")
        {
            float comp = (transform.position.y - collision.gameObject.transform.position.y)/collision.collider.bounds.size.y;
            if (collision.gameObject.name == "AI_Bumper")
            {
                dir = new Vector3(-1f, comp, 0f).normalized;
            }
            else { dir = new Vector3(1f, comp, 0f).normalized; }
            last_touched = collision.gameObject;
        }
        else
        {
            //aqui entra si esta con una barrera
            dir = new Vector3(dir.x, -dir.y, dir.z);
        }
    }

    public static int[] get_scores()
    {
        int[] scores = { player_points, ai_points };
        return scores;
    }

    public string get_last_touched()
    {
        return last_touched.name;
    }
}
