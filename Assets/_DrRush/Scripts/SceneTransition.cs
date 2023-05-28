using System;
using System.Collections;
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
        }

        public void StartMainSceneTransition()
        {
            StartCoroutine(TransitionToMainScene());
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
    }
}