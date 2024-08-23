using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunkenRuins
{
    public class AngryShellManager : EnemyManager
    {
        [SerializeField] private ShellStat shellStat;
        [SerializeField] private ShellCircleDetection shellCircleDetection;
        [SerializeField] private ShellAttackDetection shellAttackDetection;
        private Animator animator;
        
        private int keyPressCount = 0;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        protected override void Start()
        {
            base.Start();
        }

        private void OnEnable()
        {
            EventManager.StartListening(EventType.ShellAbsorb, OnPlayerDetection_AbsorbPlayer);
            EventManager.StartListening(EventType.ShellRelease, OnPlayerEscape_ReleasePlayer);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventType.ShellAbsorb, OnPlayerDetection_AbsorbPlayer);
            EventManager.StopListening(EventType.ShellRelease, OnPlayerEscape_ReleasePlayer);
        }

        private IEnumerator StartTimer()
        {
            float sibal = 0f;
            while (sibal <= shellStat.EngulfTime) {
                sibal += Time.deltaTime;
                yield return null;
            }
            Debug.Log("done");
            StartCoroutine(StopEngulfingCoroutine());
            yield return null;
        }

        private void OnPlayerDetection_AbsorbPlayer(Dictionary<string, object> message)
        {
            animator.SetBool("Absorb", true);
            StartCoroutine(StartTimer());
            shellCircleDetection.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }

        private void OnPlayerDetection_AttackPlayer(Dictionary<string, object> message)
        {
            EventManager.TriggerEvent(EventType.PlayerDamaged, new Dictionary<string, object> { { "amount", shellStat.DamagePerAttack } });
        }

        private void OnPlayerEscape_ReleasePlayer(Dictionary<string, object> message)
        {
        }

        private IEnumerator StopEngulfingCoroutine()
        {
            keyPressCount = 0;
            EventManager.TriggerEvent(EventType.ShellEscape, null);
            
            animator.SetBool("Absorb", false);
            yield return new WaitForSeconds(shellStat.EngulfDelayTime);
            shellCircleDetection.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            yield return null;
        }

        private void PrepareAttack(Dictionary<string, object> message)
        {
            if (timer >= shellStat.AttackCoolTime)
            {
                timer = 0f;
                EventManager.TriggerEvent(EventType.PlayerDamaged, new Dictionary<string, object> { { "amount", shellStat.DamagePerAttack } });
            }

            if (Input.anyKeyDown)
            {
                if (++keyPressCount >= shellStat.TotalKeyAmount)
                {
                    player.GetComponent<PlayerManager>().SetInputEnabled(true);
                    StartCoroutine(StopEngulfingCoroutine());
                }
            }
        }
    }
}