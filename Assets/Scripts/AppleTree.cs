using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    //Prefab for instantiating apples
    public GameObject applePrefab;

    public GameObject badApplePrefab;

    //Speed at which the AppleTree moves
    public float speed = 1.2f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 15f;

    //Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    //Seconds between Apples instantiations
    public float appleDropDelay = 1.5f;

    //Seconds between bad Apples instantiations
    public float badAppleDropDelay = 3.7f;

    public int scoreNextLevel = 1000;
    public ScoreCounter scoreCounter;

    void Start()
    {
        //Start dropping apples.
        Invoke("DropApple", 2f);
        //Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Get the ScoreCounter script component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    void DropBadApple()
    {
        GameObject badApple = Instantiate<GameObject>(badApplePrefab);
        badApple.transform.position = transform.position;
        Invoke("DropBadApple", badAppleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);   //Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);  //Move left       
        }

        if(scoreCounter.score == scoreNextLevel)
        {
            scoreNextLevel += 1000;
            speed += 0.01f;
            Debug.Log("Level Up!");
            if (appleDropDelay > 0.1f){
                appleDropDelay -= 0.01f;
            }
            if (badAppleDropDelay > 0.1f)
            {
                badAppleDropDelay -= 0.01f;
            }
            Invoke("DropBadApple", badAppleDropDelay);
        }
    }

    void FixedUpdate()
    {
        //Random direction changes are now time-based due to FixedUpdate()
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }

}
