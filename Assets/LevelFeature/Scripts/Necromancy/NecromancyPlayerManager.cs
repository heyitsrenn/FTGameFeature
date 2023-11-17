using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Game
{
    public class NecromancyPlayerManager : MonoBehaviour
    {
        public Health health;
        public Skill[] necromancySkills;
        [SerializeField]
        public float divider = 2;
        public Vector3 startingPoint;

        private void Awake()
        {
            if (necromancySkills[1].state == Skill.State.Activated && gameObject.GetComponent<Actor>().Affiliation == 1)
            {
                health.rebornAvailable = true;
                health.OnReborn += PlayerReborn;
            }
        }

        private void Start()
        {
            startingPoint = transform.position;
        }

        void PlayerReborn()
        {
            health.rebornAvailable = false;
            health.CurrentHealth = health.MaxHealth / divider;
            transform.position = startingPoint;
            Debug.Log("look mum I can reborn");
        }
    }
}
