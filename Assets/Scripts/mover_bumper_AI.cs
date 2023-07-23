using UnityEngine;

public class mover_bumper_AI : MonoBehaviour, Bumper_Interface
{
    // Start is called before the first frame update
    [SerializeField] GameObject ball = null;
    public float velocity = 1.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, ball.transform.position.y, transform.position.z);

        //comparar posiciones entre la bola y el bumper
        float comp = ball.transform.position.y - transform.position.y;
        //si comp es positivo la bola esta arriba, moverse arriba
        if (comp > 0) { go_up(); }
        //si comp es negativo, la bola esta abajo, moverse abajo
        else if (comp < 0) { go_down(); }
    }

    public void go_up()
    {
        transform.position = transform.position += transform.right * velocity * Time.deltaTime;
    }

    public void go_down()
    {
        transform.position += -transform.right * velocity * Time.deltaTime;
    }
}
