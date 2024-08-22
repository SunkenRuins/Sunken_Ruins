using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunkenRuins {
    public class ParallaxEffect : MonoBehaviour
    {
        private float xlength, startposX, ylength, startposY;
        public float parallaxFactor; //0�̸� �÷��̾�� ������ z��ǥ�� ����, 1�̸� ���Ѵ��� �Ÿ��� ����
        public GameObject cam;
    
        void Start()
        {
           
        }
    
        void Update()
        {
            parallaxMove();
        }

        void parallaxMove()
        {
            transform.position = parallaxFactor * cam.transform.position;
        }
    }
}

