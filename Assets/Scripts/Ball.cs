using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody ballRb;
    [SerializeField] private float initialVelocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
      ballRb = GetComponent<Rigidbody>();
        Launch();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Launch()
    {
        float xvelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yvelocity = Random.Range(0, 2) == 0 ? 1 : -1;

        ballRb.velocity = new Vector3(xvelocity, yvelocity, 0) * initialVelocity;

        /*La sintaxis de los Random.Range hace que cuando salga 0, el valor sea 1 positivo y 
         si no, 1 negativo; conformando así las cuatro cordeenadas posibles entre las cuales
        puede lanzarse la pelota al inicio del juego.*/
    }
}
