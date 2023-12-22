//// script sourced from Firemind, https://www.youtube.com/watch?v=NWNH9XRtuIc&ab_channel=Firemind
//// Purpose: Spawn enemy at spawn point
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyManager : MonoBehaviour
//{
//    public Transform[] m_SpawnPoints;   // array for spawn points
//    public GameObject m_EnemyPrefab;    // prefab for enemy so it can be duplicated

//    // Start is called before the first frame update
//    void Start()
//    {
//        SpawnEnemy();
//    }

//    void SpawnEnemy()
//    {   // generate enemy at spawn point
//        Instantiate(m_EnemyPrefab, m_SpawnPoints[0].transform.position, Quaternion.identity);
//    }
//}
