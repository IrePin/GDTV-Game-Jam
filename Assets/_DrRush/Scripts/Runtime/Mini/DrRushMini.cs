using System;
using _DrRush.Scripts.Runtime.Mini.Controller;
using _DrRush.Scripts.Runtime.Mini.Model;
using _DrRush.Scripts.Runtime.Mini.Service;
using _DrRush.Scripts.Runtime.Mini.View;
using RMC.Core.Architectures.Mini.Context;

namespace _DrRush.Scripts.Runtime.Mini
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------

    /// <summary>
    /// This Command is a stand-alone object containing
    /// a value of data.
    /// </summary>
    public class DrRushMini : IMiniMvcs
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public bool IsInitialized { get { return _isInitialized;} }
        public RMC.Core.Architectures.Mini.Context.Context Context { get { return _context;} }
        public DrRushModel DrRushModel { get { return _drRushModel;} }
        public InputView InputView { get { return _inputView;} }
        public PlayerView PlayerView { get { return _playerView;} }
        public ShooterView ShooterView { get { return _shooterView;} }
        public UIView UIView { get { return _uiView;} }
        public DrRushController DrRushController { get { return _drRushController;} }
        //public AudioController AudioController { get { return _audioController;} }
        public DrRushService DrRushService { get { return _drRushService;} }
        
        //  Fields ----------------------------------------
 
        private bool _isInitialized = false;
        
        //Context
        private RMC.Core.Architectures.Mini.Context.Context _context;
        
        //Model
        private DrRushModel _drRushModel;
        
        //View
        private InputView _inputView;
        private PlayerView _playerView;
        private ShooterView _shooterView;
        private UIView _uiView;
        
        //Controller
        private DrRushController _drRushController;
        //private AudioController _audioController;
        
        //Service
        private DrRushService _drRushService;


        //  Initialization  -------------------------------
        public DrRushMini(InputView inputView, PlayerView playerView, UIView uiView, ShooterView shooterView)
        {
            _inputView = inputView;
            _playerView = playerView;
            _shooterView = shooterView;
            _uiView = uiView;
        }
        
        
        //  Initialization --------------------------------
        public void Initialize()
        {
            if (!IsInitialized)
            {
                _isInitialized = true;
                
                //Context
                _context = new RMC.Core.Architectures.Mini.Context.Context();
                
                //Model
                _drRushModel = new DrRushModel();
   
                //Service
                _drRushService = new DrRushService();
                
                //Controller
                _drRushController = new DrRushController(
                    _drRushModel, 
                    _inputView, 
                    _playerView, 
                    _shooterView,
                    _uiView,
                    _drRushService);
            
                //Model
                _drRushModel.Initialize(_context);
                
                //View
                _inputView.Initialize(_context);
                _playerView.Initialize(_context);
                _shooterView.Initialize(_context);
                _uiView.Initialize(_context);
                
                //Service
                _drRushService.Initialize(_context);
                
                //Demo - Mini supports arbitrary actors (e.g. a second Controller)
                //_audioController = new AudioController();
                //_audioController.Initialize(_context);
                
                //Controller (Init this main controller last)
                _drRushController.Initialize(_context);
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
    }
}