using System.Collections.Generic;

namespace Constants
{
    public class GlobalConstants
    {
        public static int frameRateTarget = 240;
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
    }

    public class FrameWorldConstants
    {
        public enum worldStates { noMatchInProgress, matchInProgress };
    }

    public class CharacterConstants
    {
        public enum buttons { a, b, x, y, LeftJoy, RightJoy, back, start, LB, RB }
        public enum type { Player };
        //public enum names { John, Bob, Sally, Betty };

        private static readonly IDictionary<int, string> playerNames = new Dictionary<int, string>
        {
            {0, "Betty"},
            {1, "Bob"},
            {2, "John"},
            {3, "Sally"}
        };
        public static IDictionary<int, string> PLAYER_NAMES { get { return playerNames; } }

        private static readonly IDictionary<type, string> prefabNames = new Dictionary<type, string>
        {
            {type.Player,"Player"}
        };
        public static IDictionary<type, string> PREFAB_NAMES { get { return prefabNames; } }


        private static readonly IDictionary<type, string> gameobjectNames = new Dictionary<type, string>
        {
            {type.Player,"Player"}
        };
        public static IDictionary<type, string> GAMEOBJECT_NAMES { get { return gameobjectNames; } }
    }

    public class AbilityConstants
    {
        public static float PlasmaGunCooldown = 0.25f;
        public static float shieldDefaultArea = 4.0f;
        public static float shieldDefaultCooldown = 1.0f;
        public static float shieldDefaultLifetime = 4.0f;

        public enum properties { Knockback, OnFire, Frozen }

        public enum type { Shield, PlasmaBullet };

        private static readonly IDictionary<type, string> prefabNames = new Dictionary<type, string>
        {
            {type.Shield,"Abilities/Shield"},
            {type.PlasmaBullet, "Abilities/PlasmaBullet"}
        };
        public static IDictionary<type, string> PREFAB_NAMES { get { return prefabNames; } }
    }
}