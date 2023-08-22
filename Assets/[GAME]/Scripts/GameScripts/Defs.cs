namespace Scripts
{
    public static class Defs
    {
        #region Scene Names
        
        public static readonly string SCENE_NAME_LOADER = "Loader";

        #endregion

        #region Save Keys
        
        public static readonly string SAVE_KEY_SCENE_LOADER_TOOL = "LoaderTool";
        public static readonly string SAVE_KEY_LEVEL = "Level";
        #endregion

        #region Ui Keys

        public static readonly string UI_KEY_NOT_IMPLEMENTED = "NOT_IMPLEMENTED";

        public static readonly string UI_KEY_START_SCREEN = "StartScreen";
        public static readonly string UI_KEY_GENERIC_SCREEN = "GenericScreen";
        public static readonly string UI_KEY_GAMEPLAY_SCREEN = "GamePlayScreen";
        public static readonly string UI_KEY_WIN_SCREEN = "WinScreen";
        public static readonly string UI_KEY_LOSE_SCREEN = "LoseScreen";
        
        public static readonly string UI_KEY_LOADING_SCREEN = "LoadingScreen";
        public static readonly string UI_KEY_LEVEL_SUCCESS_PANEL = "SuccessPanel";
        public static readonly string UI_KEY_LEVEL_FAILED_PANEL = "FailPanel";

        public static readonly string UI_KEY_FLOATING_JOYSTICK = "FloatingJoystick";

        #endregion
        
        #region Game States

        public static readonly string GAME_STATE_START = "GameStateStart";
        public static readonly string GAME_STATE_PLAYING = "GameStatePlaying";
        public static readonly string GAME_STATE_LOSE = "GameStateLose";
        public static readonly string GAME_STATE_WIN = "GameStateWin";

        #endregion

        #region Layers

        public static readonly string LAYER_INTERACT_WITH_NOTHING = "InteractNothing";

        #endregion

        #region Others

        public static readonly string DEFINE_SYMBOLS_ENABLE_LOG = "EnableLog";

        #endregion
    }
}