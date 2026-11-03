using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpaltura;
    private float jumpalturaatual = 0;

    private bool jump = true;
    private void MovePlayer()
    {
        float yMoveValue = 0f;
        if(jump == true && !(Input.GetAxis("Jump") == 0))
        {
            jumpalturaatual = transform.position.y + jumpaltura;
            jump = false;
        }

        if(transform.position.y < jumpalturaatual)
        {
            yMoveValue = Input.GetAxis("Jump") * Time.deltaTime * speed;
        }
        float xMoveValue = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float zMovevalue = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        //this function have the objetive for the moviment the player controller
        transform.Translate(xMoveValue, yMoveValue, zMovevalue);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    //bunos: Limitar pular
    private void OnCollisionEnter(Collision collision)
    {

        ContactPoint ContatoDeColisao = collision.contacts[0];
        if (ContatoDeColisao.point.y < transform.position.y)
        {
            jump = true;
        }
    }

}