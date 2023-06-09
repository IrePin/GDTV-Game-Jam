using System;
using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.Mini.Service;
using UnityEngine;
using UnityEngine.Events;

namespace _DrRush.Scripts.Runtime.Mini.Service
{
    //  Namespace Properties ------------------------------
    public class LoadedUnityEvent : UnityEvent {}

    //  Class Attributes ----------------------------------

    /// <summary>
    /// The Service handles external data 
    /// </summary>
    public class DrRushService : BaseService  // Extending 'base' is optional
    {
        //  Events ----------------------------------------
        public readonly LoadedUnityEvent OnLoaded = new LoadedUnityEvent();

        //  Properties ------------------------------------
        public int ScoreMax { get { return _scoreMax;} }
        
        //  Fields ----------------------------------------
        private int _scoreMax;

        //  Initialization  -------------------------------
        public override void Initialize(IContext context)
        {
            if (!IsInitialized)
            {
                base.Initialize(context);
                _scoreMax = 0;
            }
        }

        //  Methods ---------------------------------------
        public void Load ()
        {
            RequireIsInitialized();

            TextAsset textAsset = Resources.Load<TextAsset>("Texts/DrRushText"); //txt file

            if (textAsset == null)
            {
                Debug.LogError("Error: LoadAsync failed.");
            }
            else
            {
                _scoreMax = Int32.Parse(textAsset.ToString());
                OnLoaded.Invoke();
            }
           
        }
        
        //  Event Handlers --------------------------------

    }
}