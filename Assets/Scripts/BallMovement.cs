using System;
using UnityEngine;

public class BallMovement : MonoBehaviour{

    private ScoreManager scoreManager;
    private new AudioManager audio;
    private Transform player1Position;
    private Transform player2Position;

    public GameObject goalParticules;

    [NonSerialized]
    public Vector2 p1Init = new Vector2(-6.15f, 0f);
    [NonSerialized]
    public Vector2 p2Init = new Vector2(6.15f, 0f);
    public Rigidbody2D rb;

    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    [Range(0f,1f)]
    private float angle = 0f;


    void Awake(){
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        player1Position = GameObject.Find("Joueur1").transform;
        player2Position = GameObject.Find("Joueur2").transform;
        audio = FindObjectOfType<AudioManager>();   

        int rdm1 = UnityEngine.Random.Range(0, 2);

        Vector2 rdmDir = new Vector2(1f, UnityEngine.Random.Range(-angle, angle)).normalized;

        if (rdm1 == 0) {
            rdmDir.x = -1f;
            rb.velocity = rdmDir * speed ;
        } 
        else {
            rb.velocity = rdmDir * speed ;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        string goName = col.gameObject.name;
        switch (goName) {
            case "Mur1":
                Vector3 rotation = new Vector3(0, 0, -90);
                Instantiate(goalParticules, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
                scoreManager.AjouterPoint("P2");
                audio.Play("Goal");
                resetPlayersPositions();
                Destroy(this.gameObject);
                break;
            case "Mur2":
                Instantiate(goalParticules, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                scoreManager.AjouterPoint("P1");
                audio.Play("Goal");
                resetPlayersPositions();
                Destroy(this.gameObject);
                break;
            case "Joueur1":
                audio.Play("Ping");
                Vector2 invertedDir1 = (Vector2)transform.position - ((Vector2)player1Position.position + Vector2.left);
                invertedDir1 = invertedDir1.normalized;
                rb.velocity = invertedDir1 * rb.velocity.magnitude;
                break;
            case "Joueur2":
                audio.Play("Pong");
                Vector2 invertedDir2 = (Vector2)transform.position - ((Vector2)player2Position.position + Vector2.right);
                invertedDir2 = invertedDir2.normalized;
                rb.velocity = invertedDir2 * rb.velocity.magnitude;
                break;
        }
    }

    private void resetPlayersPositions() {
        this.player1Position.position = this.p1Init;
        this.player2Position.position = this.p2Init;
    }

}
