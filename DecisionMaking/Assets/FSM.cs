using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    private WaitForSeconds wait = new WaitForSeconds(0.05f);   // 1 / 20
    delegate IEnumerator State();
    private State state;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        state = Wander;
        while (enabled)
        {
            yield return StartCoroutine(state());
        }

    }

    IEnumerator Wander()
    {
        Debug.Log("Wander state");

        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 5);
        int walkTime = Random.Range(1, 6);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }

    IEnumerator Hiding()
    {
        Debug.Log("Hiding state");
    }

    IEnumerator Approach()
    {
        Debug.Log("Approach state");
    }

        // Update is called once per frame
    void Update()
    {
        
    }

    //Coroutine that executes 20 times per second and goes forever

    //Explicit every state change with Debub.Log

    //First behaviour is slowly wander

    //When the cop walks away from the treasure he has to approach quickly to steal it

    //If the cop comes back he returns to wander slowly and so on

    //If the robbery is successful (the treasure must disappear), he begins to permanently hide in the obstacle closest to the cop

}
