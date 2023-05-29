using System;
using _DrRush.Scripts.Runtime.Components;
using _DrRush.Scripts.Runtime.Mini.Controller.Commands;
using _DrRush.Scripts.Runtime.Mini.Model;
using _DrRush.Scripts.Runtime.Mini.Service;
using _DrRush.Scripts.Runtime.Mini.View;
using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.Mini.Controller;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _DrRush.Scripts.Runtime.Mini.Controller
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------

    /// <summary>
    /// The Controller coordinates everything between
    /// the <see cref="IConcern"/>s and contains the core app logic 
    /// </summary>
    public class DrRushController : IController  
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public bool IsInitialized { get { return _isInitialized;} }
        public IContext Context { get { return _context;} }
        
        //  Fields ----------------------------------------
        private bool _isInitialized = false;
        
        //Context
        private IContext _context;
        
        //Model
        private DrRushModel _model;
        
        //View
        private PlayerView _playerView;
        private UIView _uiView;
        private InputView _inputView;
        private ShooterView _shooterView;
        
        //Controller
        //private AudioController _audioController;
        
        //Service
        private DrRushService _service;
        
        //  Initialization  -------------------------------
        public DrRushController(
            DrRushModel model, 
            InputView inputView, 
            PlayerView playerView, 
            ShooterView shooterView,
            UIView uiView, 
            DrRushService service)
        {
            _model = model;
            _inputView = inputView;
            _playerView = playerView;
            _shooterView = shooterView;
            _uiView = uiView;
            _service = service;
            
        }

        public void Initialize(IContext context)
        {
            if (!IsInitialized)
            {
                _isInitialized = true;
                _context = context;
                
                //Model
                _model.Score.OnValueChanged.AddListener(Model_Score_OnValueChanged);
                _model.ScoreMax.OnValueChanged.AddListener(Model_ScoreMax_OnValueChanged);
                _model.StatusText.OnValueChanged.AddListener(Model_StatusText_OnValueChanged);
                _model.StatusText.Value = "Loading...";
                
                //View
                _inputView.OnInput.AddListener(InputView_OnInput);
                _uiView.OnRestart.AddListener(UIView_OnRestart);
                _uiView.OnPlay.AddListener(UIView_OnPlay);
                //_playerView.OnPickup.AddListener(PlayerView_OnPickup);
                _shooterView.OnPickup.AddListener(ShooterView_OnPickup);
                
                //Service
                _service.OnLoaded.AddListener(Service_OnLoaded);
                _service.Load();
            }
        }


        public void RequireIsInitialized()
        {
            if (!_isInitialized)
            {
                throw new Exception("MustBeInitialized");
            }
        }
        
        
        //  Methods ---------------------------------------


        //  Event Handlers --------------------------------
        private void UIView_OnRestart(DialogView dialogViewPrefab)
        {
            //Pause
            _model.IsGamePaused.Value = true;
            
            // Show Prompt
            DialogView dialogView = GameObject.Instantiate(dialogViewPrefab);
            dialogView.Initialize(Context);
            
            dialogView.OnCancel.AddListener(() =>
            {
                GameObject.Destroy(dialogView.gameObject);
                
                //Unpause
                _model.IsGamePaused.Value = false;
                
            });
            
            dialogView.OnConfirm.AddListener(() =>
            {
                GameObject.Destroy(dialogView.gameObject);
                SceneManager.LoadScene("MadHospital");
                
                //Unpause
                _model.IsGamePaused.Value = false;
            });
        }

        private void UIView_OnPlay()
        {
             SceneManager.LoadScene("MadHospital");
        }
        


        private void Service_OnLoaded()
        {
            RequireIsInitialized();

            _model.Score.Value = 0;
            _model.ScoreMax.Value = _service.ScoreMax;
            _model.StatusText.Value = "Use A and D Keys";
        }
        
        private void InputView_OnInput(Vector3 input)
        {
            RequireIsInitialized();
            
            if (_model.IsGameOver.Value || _model.IsGamePaused.Value)
            {
                return;
            }
            
            Context.CommandManager.InvokeCommand(new InputCommand(input));
        }
        
        public void ShooterView_OnPickup(PickupComponent pickupComponent)
        {
            RequireIsInitialized();

            if (_model.IsGameOver.Value)
            {
                return;
            }
            
            pickupComponent.gameObject.SetActive (false);
            
            Context.CommandManager.InvokeCommand(
                new PlayAudioClipCommand("AudioClips/Bounce01"));
            
            if (++_model.Score.Value >= _model.ScoreMax.Value)
            {
                _model.IsGameOver.Value = true;
                _model.StatusText.Value = "You Win!";
            }
        }
        
        private void Model_Score_OnValueChanged(int previousValue, int currentValue)
        {
            RequireIsInitialized();
            
            Context.CommandManager.InvokeCommand(
                new ScoreChangedCommand(currentValue));
        }
        
        private void Model_ScoreMax_OnValueChanged(int previousValue, int currentValue)
        {
            RequireIsInitialized();
            
            Context.CommandManager.InvokeCommand(
                new ScoreMaxChangedCommand(currentValue));
        }
        
        private void Model_StatusText_OnValueChanged(string previousValue, string currentValue)
        {
            RequireIsInitialized();
            
            Context.CommandManager.InvokeCommand(
                new StatusChangedCommand(currentValue));
        }
    }
}