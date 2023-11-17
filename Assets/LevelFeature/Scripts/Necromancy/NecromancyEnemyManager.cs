using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.AI;

namespace Unity.FPS.Game
{
    public class NecromancyEnemyManager : MonoBehaviour
    {
        public Health health;
        public Skill[] necromancySkills;
        [SerializeField]
        private float radius = 20f;
        [SerializeField]
        private float damage = 15f;
        public GameObject Player;
        public EnemyManager enemyManager;
        public EnemyController enemyController;
        public DetectionModule detectionModule;
        public Vector3 enemyRebornPoint;
        private void Awake()
        {
            Player = GameObject.Find("Player");
            enemyManager = FindObjectOfType< EnemyManager>();
            enemyRebornPoint = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(0.5f, 2.5f), Random.Range(-2.5f, 2.5f));

            if (necromancySkills[0].state == Skill.State.Activated)
            {
                health.OnDie += Explode;
            }
            if (necromancySkills[2].state == Skill.State.Activated)
            {
                health.rebornAvailable = true;
                health.OnReborn += EnemyReborn;
            }
        }
        
        private void Update()
        {
            if (necromancySkills[2].state == Skill.State.Activated && health.rebornAvailable == false)
            {
                transform.position = Player.transform.position + enemyRebornPoint;
                Debug.Log("Following Player");
            }
        }
        void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            Debug.Log("Wow, mum I exploded");
            if (colliders.Length > 0)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject.GetComponent<Actor>() != null)
                    {
                        if (colliders[i].gameObject.GetComponent<Actor>().Affiliation == 0)
                        {
                            Debug.Log("Look mum, I hit something!");
                            colliders[i].gameObject.GetComponent<Health>().TakeDamage(damage, this.gameObject);
                        }
                    }
                    
                }
            }
            
        }
        void EnemyReborn()
        {
            this.GetComponent<Actor>().Affiliation = 1;
            
            Debug.Log("Enemy Reborn");
            health.rebornAvailable = false;
            health.CurrentHealth = health.MaxHealth;
            enemyManager.UnregisterEnemy(enemyController);
            detectionModule.OnLostTarget();
        }
    }
}

