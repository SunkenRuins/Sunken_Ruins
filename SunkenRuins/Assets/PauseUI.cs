using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunkenRuins {
    public class PauseUI : MonoBehaviour
    {
        public void OnPause (){
            Pause();
        }
        public void OnClickResume() {
            gameObject.SetActive(false);
            Unpause();
        }
        public void OnQuit(){
            Debug.Log("quit");
            //quit
        }
        private void Pause() {
            Time.timeScale = 0f;
        }
        private void Unpause(){
            Time.timeScale = 1f;
        }
    }
}