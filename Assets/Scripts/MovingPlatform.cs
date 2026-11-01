using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointA;
    [SerializeField] private float waitingTime = 0f;
    [SerializeField] private float movingSpeed = 2f;



    
    private Transform targetPoint; private float waitTimer;
    private bool isWaiting;
    private void Start()
    {
        // mover para direção do pointB sem tempo de espera
        targetPoint = pointB;
        waitTimer = 0f;
        isWaiting = false;
    }
    private void Update()
    {
        if (isWaiting)
        {

            waitTimer += Time.deltaTime;
            // Verifica se o tempo decorrido atingiu o tempo de espera configurado
            if (waitTimer >= waitingTime)
            {
                // também podemos fazer assim "targetPoint = (targetPoint == pointA) ? pointB : pointA; "só que ainda não connhecimento ainda 
                if (targetPoint == pointA)
                {
                    targetPoint = pointB;
                }
                else
                {
                    targetPoint = pointA;
                }
                isWaiting = false;
            }
        }
        else
        {

            if (Vector3.Distance(transform.position, targetPoint.position) < 0.01f)
            {
                transform.position = targetPoint.position;
                isWaiting = true;
                waitTimer = 0f;
            }
        }
    }


}
