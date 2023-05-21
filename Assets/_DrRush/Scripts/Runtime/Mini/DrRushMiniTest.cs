using _DrRush.Scripts.Runtime.Mini.View;
using UnityEngine;

namespace _DrRush.Scripts.Runtime.Mini
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------

    /// <summary>
    /// The Example is the main entry point to the demo
    /// </summary>
    public class DrRushMiniTest : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        
        
        //  Fields ----------------------------------------
        
        [SerializeField] 
        private InputView _inputView;

        [SerializeField] 
        private PlayerView _playerView;

        [SerializeField] 
        private UIView _uiView;

        
        //  Unity Methods  --------------------------------
        protected void Start()
        {
            DrRushMini drRushMini = 
                new DrRushMini(_inputView, _playerView, _uiView);
            
            drRushMini.Initialize();
        }


        //  Methods ---------------------------------------


        //  Event Handlers --------------------------------
    }
}