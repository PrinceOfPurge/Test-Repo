using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float PlayerSpeed;
    [SerializeField] public Text _text;
    private Rigidbody2D rb;
    public GameObject[] diseaseCubesArray;
    public int DiseaseCubes;
    int nextPosIndex;
    Transform nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = Positions[0];
        rb = GetComponent<Rigidbody2D>();
        diseaseCubesArray = GameObject.FindGameObjectsWithTag("DiseaseCube");

    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();
    }
    
    //class for the movement of player
    void MoveGameObject()
    {
        if (Input.GetKeyDown(KeyCode.Space))

        {
            if (transform.position == nextPos.position)
            {
                nextPosIndex++;
                if (nextPosIndex >= Positions.Length)
                {
                    nextPosIndex = 0;
                }

                nextPos = Positions[nextPosIndex];
            }
        }
//call the action player makes
        transform.position = Vector3.MoveTowards(transform.position, nextPos.position, PlayerSpeed * Time.deltaTime);
    }

//disease cube interaction and prompt update     
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (DiseaseCubes > 0)
        {
            if (other.gameObject.CompareTag("DiseaseCube")) ;
            {
                DiseaseCubes--;
                Destroy(other.gameObject);
                _text.text = "Removed disease cubes Remaining:  " + DiseaseCubes.ToString();

            }
        }

    }
    
}
