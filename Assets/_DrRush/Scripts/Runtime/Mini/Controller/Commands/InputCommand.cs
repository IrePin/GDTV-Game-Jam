using RMC.Core.Architectures.Mini.Controller.Commands;
using UnityEngine;

namespace _DrRush.Scripts.Runtime.Mini.Controller.Commands
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------

    /// <summary>
    /// This Command is a stand-alone object containing
    /// a value of data.
    /// </summary>
    public class InputCommand: ValueCommand<Vector3>
    {
        //  Properties ------------------------------------
        
        
        //  Fields ----------------------------------------
        
        
        //  Initialization  -------------------------------
        public InputCommand(Vector3 value) : 
            base(value)
        {
        }
    }
}