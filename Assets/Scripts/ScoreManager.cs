using System;
using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int scoreP1;
    private int scoreP2;
    private static ScoreManager instance;
    private bool readyToSpawn = false;


    public float respawnDelay;
    public GameObject ballPrefab;
    public TextMeshProUGUI textScore;
    public Shaker Shaker;

    void Awake(){
        if (ScoreManager.instance == null)
            ScoreManager.instance = this;
        else {
            Destroy(this.gameObject);
            return;
        }
        StartCoroutine(RespawnBall());
        Canvas myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        myCanvas.worldCamera = Camera.main;
        myCanvas.sortingLayerName = "Score";
        myCanvas.sortingOrder = 1;

    }

    public void AjouterPoint(string player){
        switch (player){
            case "P1":
                this.scoreP1++;
                Shaker.shake();
                UpdateScore();
                break;
            case "P2":
                this.scoreP2++;
                Shaker.shake();
                UpdateScore();
                break;
        }
        StartCoroutine(RespawnBall());
    }

    private void Update() {
        if (readyToSpawn) {
            SpawnBall();
            readyToSpawn = false;
        }
    }

    private IEnumerator RespawnBall() {
        yield return new WaitForSeconds(respawnDelay);
        readyToSpawn = true;
    }

    private void SpawnBall(){
        Instantiate(ballPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    private void UpdateScore(){
        String t1;
        String t2;
        if (this.scoreP1 < 10) {
            t1 = "0" + this.scoreP1;
        } else {
            t1 = this.scoreP1.ToString();
        }

        if(this.scoreP2 < 10) {
            t2 = "0" + this.scoreP2;
        } else {
            t2 = this.scoreP2.ToString();
        }

        this.textScore.text = t1 + " - " + t2;
    }
}
