using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Controller : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] private Vector3 rightTargetPosition;
    [SerializeField] private Vector3 leftTargetPosition;
    [SerializeField] private float lerpDuration;
    [SerializeField] private AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
       startPosition = transform.position;

        StartCoroutine(MovementLerp(startPosition, rightTargetPosition, leftTargetPosition,lerpDuration));
    }

    // Update is called once per frame

    IEnumerator MovementLerp(Vector3 startPosition, Vector3 rightTargetPosition, Vector3 leftTargetPosition, float lerpDuration)
    {
        while (true)

        {
            float timeElapsed = 0f;

            while (timeElapsed < lerpDuration)
            {
                transform.position = Vector3.Lerp(startPosition, rightTargetPosition, curve.Evaluate(timeElapsed / lerpDuration));
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = rightTargetPosition;

            //Plataforma va desde el centro hasta la derecha

            yield return new WaitForSeconds(1);

            startPosition = transform.position;
            timeElapsed = 0f;

            while (timeElapsed < lerpDuration)
            {
                transform.position = Vector3.Lerp(startPosition, leftTargetPosition, curve.Evaluate(timeElapsed / lerpDuration));
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = leftTargetPosition;

            //Desde la derecha, hacia la izquierda. 

            yield return new WaitForSeconds(1);

            
            startPosition = transform.position;
            /*Al reiniciar el while, la plataforma partirá desde la izquierda hacia la derecha y viceversa.
             El bucle se repetirá hasta el final*/
        }
    }
}
