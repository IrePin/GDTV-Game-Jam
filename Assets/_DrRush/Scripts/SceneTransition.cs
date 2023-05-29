using System;
using System.Collections;
using _DrRush.Scripts.FMOD;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _DrRush.Scripts
{
    public class SceneTransition : MonoBehaviour
    {
        //public string MadHospital; // Назва основної сцени

        private Scene _currentScene;
        private void Awake()
        {
            _currentScene = SceneManager.GetActiveScene();
            if(_currentScene.name == "CutSceneOne")
                StartCoroutine(TransitionToShooterScene());
            if(_currentScene.name == "CutSceneTwo")
                StartCoroutine(TransitiontoCreditsScene());
            
        }

        public void StartMainSceneTransition()
        {
            StartCoroutine(TransitionToMainScene());
        }

        public void StartCutTwoTransition()
        {
            StartCoroutine(TransitionFromShooterScene());
        }
        
        public void StartGameOverTransition()
        {
            StartCoroutine(TransitiontoGameOver());
        }

        private IEnumerator TransitionToMainScene()
        {
            SceneManager.LoadScene("CutSceneOne");
            yield return new WaitForSeconds(1f);
        }

        private IEnumerator TransitionToShooterScene()
        {
            yield return new WaitForSeconds(7f);

            SceneManager.LoadScene("ShooterScene");
        }

        private IEnumerator TransitionFromShooterScene()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("CutSceneTwo");
        }

        private IEnumerator TransitiontoCreditsScene()
        {
            
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Credits");
        }
        
        private IEnumerator TransitiontoGameOver()
        {
            
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("GameOver");
            
        }
    }
}