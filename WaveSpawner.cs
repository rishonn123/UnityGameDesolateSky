﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState{SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave{
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    } 

    public Wave[] waves;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountdown = 0;

    private float searchCountdown = 1f;


    private SpawnState state = SpawnState.COUNTING;

    void Start(){
        waveCountdown = timeBetweenWaves;
    }

    void Update(){

        if(state == SpawnState.WAITING){
            if(!EnemyIsAlive()){
                Debug.Log("Wave Finished");
                return;

            }
            else{
                return;
            }
        }

        if(waveCountdown <= 0){
            if(state != SpawnState.SPAWNING){
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else{
            waveCountdown -= Time.deltaTime;
        }
    }

    bool EnemyIsAlive(){
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f){

            searchCountdown = 1f;
            if(GameObject.FindGameObjectWithTag("Enemy") == null){
                return false;
            }

        }
      
        return true;
    }



    IEnumerator SpawnWave(Wave _wave){
       Debug.Log("Spawn Wave : " + _wave.name);
       state = SpawnState.SPAWNING;

        for(int i = 0; i < _wave.count; i++){
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

       state = SpawnState.WAITING;
       
        yield break;
    }

    void SpawnEnemy(Transform _enemy){

        Debug.Log("Spawning Enemy :" + _enemy.name);
        Instantiate (_enemy , transform.position , transform.rotation);
    }


}
