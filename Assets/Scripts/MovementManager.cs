using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private Vector2 positionP1;
    private Vector2 positionP2;

    private Transform player1;
    private Transform player2;

    [SerializeField]
    private float speed = 4;

    public float limit = 4f;

    void Start(){
        positionP1 = this.transform.GetChild(0).transform.position;
        positionP2 = this.transform.GetChild(1).transform.position;
        player1 = this.transform.GetChild(0).transform;
        player2 = this.transform.GetChild(1).transform;
    }

    void Update(){
        if (Input.GetKey(KeyCode.Z))
            MoveUp("P1");

        if (Input.GetKey(KeyCode.S))
            MoveDown("P1");

        if (Input.GetKey(KeyCode.UpArrow))
            MoveUp("P2");

        if (Input.GetKey(KeyCode.DownArrow))
            MoveDown("P2");
    }

    void MoveUp(string player){
        this.positionP1 = this.player1.position;
        this.positionP2 = this.player2.position;
        switch (player){
            case "P1":
                positionP1.y += speed * Time.deltaTime;
                positionP1.y = Mathf.Clamp(positionP1.y, -limit, limit);
                this.player1.position = positionP1;
                break;

            case "P2":
                positionP2.y += speed * Time.deltaTime;
                positionP2.y = Mathf.Clamp(positionP2.y, -limit, limit);
                this.player2.position = positionP2;
                break;
        }
    }

    void MoveDown(string player){
        this.positionP1 = this.player1.position;
        this.positionP2 = this.player2.position;
        switch (player) {
            case "P1":
                positionP1.y -= speed * Time.deltaTime;
                positionP1.y = Mathf.Clamp(positionP1.y, -limit, limit);
                this.player1.position = positionP1;
                break;

            case "P2":
                positionP2.y -= speed * Time.deltaTime;
                positionP2.y = Mathf.Clamp(positionP2.y, -limit, limit);
                this.player2.position = positionP2;
                break;
        }
    }
}
