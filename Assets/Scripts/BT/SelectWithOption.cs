using UnityEngine;

namespace AI
{
    public abstract class SelectWithOption : Node
    {
        [SerializeField]
        protected Node successTree;

        [SerializeField]
        protected Node failTree;

        public abstract bool Check();

        public override void Execute()
        {
            if (Check())
            {
                successTree.Execute();
            }
            else
            {
                failTree.Execute();
            }
        }
    }
}