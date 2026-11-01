using UnityEngine;

public class HitDetected : MonoBehaviour
{
    private Material material;

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
    }
    private void OnCollisionEnter(Collision collider) {
        Debug.Log("Tocou");
        //pega o colider busca dentro dele o gameObject e depois busca a tag
        if (collider.gameObject.CompareTag("Player") && !collider.gameObject.CompareTag("Collided"))
        {
            Debug.Log("Tocou Player");
            material.color = Color.red;
        }
    }

    //Bonus: fizemos uma funcao que a cor volta ao normal apos player parar de tocar
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Collided"))
        {
            material.color = Color.blue;
        }
    }
}
