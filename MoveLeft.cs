using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 20.0f;
    private float currentSpeed;
    private PlayerController playerControllerScript;
    private int boostAmount = 2;
    private int boostDuration = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
      

        if (playerControllerScript.gameOver == false) {
            transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
                }



        // let the player dash on D press

        if (Input.GetKeyDown(KeyCode.D))
        {
            ApplySpeedBoost(boostAmount, boostDuration);
        }



    }

    // Function to apply temporary speed increase
    public void ApplySpeedBoost(float boostAmount, float boostDuration)
    {
        currentSpeed = speed * boostAmount;
        StartCoroutine(RemoveSpeedBoost(boostDuration));
        
    }



    // Coroutine to revert speed back to normal after the duration
    private IEnumerator RemoveSpeedBoost(float boostDuration)
    {
        yield return new WaitForSeconds(boostDuration);
        currentSpeed = speed;
    }


}
