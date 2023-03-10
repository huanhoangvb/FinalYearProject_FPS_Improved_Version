using UnityEngine;
namespace UniBT.Examples.Scripts.Behavior
{
    public class isCompanionHasResource : Conditional
    {
        protected override bool IsUpdatable()
        {
            return gameObject.GetComponent<Companion_Controller>().resource;
        }

    }
}
