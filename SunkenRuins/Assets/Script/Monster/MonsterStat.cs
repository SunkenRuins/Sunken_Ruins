using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunkenRuins
{
    public class MonsterStat : MonoBehaviour, IDamageable
    {
        [Header("Stat")]
        public int monsterMaxHealth;
        public int monsterCurrentHealth;

        [Header("Movement")]
        public float initialMoveSpeed = 5f;
        public float turnAcceleration = 60f;
        public float moveAcceleration = 30f;
        public float moveDecceleration = 50f;
        public TeamType teamType { get; set; }

        private void Start()
        {
            // teamType을 Monster로 해서 Damage 받을 때 구분 가능하게 함
            // 근데 솔직히 layer 쓸 거면 이렇게 enum 안 써도 될 듯?
            teamType = TeamType.Monster;
            monsterCurrentHealth = monsterMaxHealth;
        }

        public void Damage(TeamType other)
        {
            if(other == TeamType.Player) Debug.Log("몬스터가 피해를 입습니다.");
        }
    }
}