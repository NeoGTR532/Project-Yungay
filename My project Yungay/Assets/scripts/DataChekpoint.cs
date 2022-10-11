using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataChekpoint : MonoBehaviour
{
    public List<DataEnemys> dataEnemys = new List<DataEnemys>();
    public GameObject[] enemigos;
    public void Check()
    {
        dataEnemys.Clear();
        enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemysSingle in enemigos)
        {
            Debug.Log(enemysSingle.name);
            dataEnemys.Add(new DataEnemys(enemysSingle.GetComponent<Transform>().position, enemysSingle.GetComponent<EnemyHealth>().life));
        }
    }

    public void FixEnemy()
    {
        for(int i = 0; i < enemigos.LongLength; i++)
        {
            enemigos[i].transform.position = dataEnemys[i].position;
            enemigos[i].GetComponent<EnemyHealth>().life = dataEnemys[i].health;
        }
    }

    [System.Serializable]

    public class DataEnemys
    {
        public Vector3 position;
        public float health;

        public DataEnemys(Vector3 pos, float health)
        {
            this.position = pos;
            this.health = health;
        }
    }
}
