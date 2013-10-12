using System.Collections.Generic;

namespace Constants
{

    public class GlobalConstants
    {
        public enum type { GlobalController, GamepadInfo };

        private static readonly IDictionary<type, string> prefabNames = new Dictionary<type, string>
        {
            {type.GlobalController,"GlobalController"},
            {type.GamepadInfo, "Handlers/GamepadInfo"}
        };
        public static IDictionary<type, string> PREFAB_NAMES { get { return prefabNames; } }
    }

    public class CompWorldConstants
    {
        public enum worldStates { noMatchInProgress, matchInProgress, intermission };
        public static int foddyFrames = 240;
    }

    public class FrameWorldConstants
    {
        public enum worldStates { noMatchInProgress, matchInProgress };
    }

    public class CharacterConstants
    {
        public enum buttons { a, b, x, y, LeftJoy, RightJoy, back, start, LB, RB }
        
        public enum type { Player };

        private static readonly IDictionary<type, string> prefabNames = new Dictionary<type, string>
        {
            {type.Player,"Player"},
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
        public static float PlasmaGunCooldown = 0.25f;
        public static float ShieldDefaultArea = 4.0f;
        public static float ShieldDefaultLifetime = 0.5f;
        public static float ShieldDefaultCooldown = 2.0f;

        public enum type { PlasmaBullet, Shield };

        private static readonly IDictionary<type, string> prefabNames = new Dictionary<type, string>
        {
            {type.PlasmaBullet,"Abilities/PlasmaBullet"},
            {type.Shield,"Abilities/Shield"}
        };
        public static IDictionary<type, string> PREFAB_NAMES { get { return prefabNames; } }

    }
}