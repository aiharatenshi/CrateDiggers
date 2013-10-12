using System.Collections.Generic;

namespace Constants
{


    public class CompWorldConstants
    {
        public enum worldStates { noMatchInProgress, matchInProgress, intermission };
    }

    public class FrameWorldConstants
    {
        public enum worldStates { noMatchInProgress, matchInProgress };
    }

    public class CharacterConstants
    {
        public enum buttons { a, b, x, y, LB, RB, back, start, LJoy, RJoy }
        
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

    public class AbilityConstants
    {
        public enum properties { Knockback, OnFire, Frozen }
        public static float PlasmaGunCooldown = 1.0f;
    }
}