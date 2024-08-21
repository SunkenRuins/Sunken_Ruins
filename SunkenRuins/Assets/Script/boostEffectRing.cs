using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostEffectRing : MonoBehaviour
{
    [SerializeField] float lifeTime;
    float lifeTimer;

    [HideInInspector] public AnimationCurve scaleCurve;
    [HideInInspector] public AnimationCurve colorCurve;

    SpriteRenderer spr;
    Color initColor;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);

        initColor = spr.color; //�ʱ� ����, ���İ� ������
        //spr.color = new Color(initColor.r, initColor.g, initColor.b, 0); //�� ó������ ����ȭ

        lifeTimer = 0f; //Ÿ�̸� �ʱ�ȭ 
    }

    void Update()
    {
        scaleEdit();
    }

    void scaleEdit()
    {
        if(lifeTimer > lifeTime)
        {
            Destroy(gameObject); //�ð� ������ �ı�
        }

        lifeTimer += Time.deltaTime;
        transform.localScale = new Vector3(1, 1, 1) * scaleCurve.Evaluate(lifeTimer / lifeTime); //ũ�� ����
        spr.color = new Color(initColor.r, initColor.g, initColor.b, colorCurve.Evaluate(lifeTimer / lifeTime)); //���� ���� 
    }
}
