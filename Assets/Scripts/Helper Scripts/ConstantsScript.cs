using System.Collections.Generic;

namespace Constants
{


    public class CompWorldConstants
    {
        public enum worldStates { noMatchInProgress, matchInProgress };
    }

    public class FrameWorldConstants
    {
        public enum worldStates { noMatchInProgress, matchInProgress };

        
    }

    public class CharacterConstants
    {
        public enum type { Player };

        private static readonly IDictionary<type, string> prefabNames = new Dictionary<type, string>
        {
            {type.Player,"Player"}
        };
        public static IDictionary<type, string> PREFAB_NAMES { get { return prefabNames; } }

        
        private static readonly IDictionary<type, string> gameobjectNames= new Dictionary<type, string>
        {
            {type.Player,"Player"}
        };
        public static IDictionary<type, string> GAMEOBJECT_NAMES { get { return gameobjectNames; } }
    }
}