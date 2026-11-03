using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HitDetected : MonoBehaviour
{
    private Material material;
    private bool tocado = false;
    [SerializeField] private int pontos = 1;
    [SerializeField] private Pontos texto;


    private void Awake()
    {
        texto.PontosTotal = 0;
        material = GetComponent<MeshRenderer>().material;
    }
    private void OnCollisionEnter(Collision collider) {
        
        //pega o colider busca dentro dele o gameObject e depois busca a tag
        if (collider.gameObject.CompareTag("Player") && !collider.gameObject.CompareTag("Collided"))
        {
            if (!tocado)
            {
                texto.PontosTotal += pontos;
                Debug.Log("Pontos: " + texto.PontosTotal);
                tocado = true;
            }   
            material.color = Color.red;
        }
    }

    
}
