using UnityEngine;

public class mover_bumper_player : MonoBehaviour, Bumper_Interface
{
    // Start is called before the first frame update
    [SerializeField]
    float velocity = 1f;
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {

            go_up();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            go_down();
        }
    }

    public void go_up()
    {
        transform.position += transform.right * velocity * Time.deltaTime;
    }

    public void go_down()
    {
        transform.position += -transform.right * velocity * Time.deltaTime;
    }
}
