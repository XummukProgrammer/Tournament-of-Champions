public class WinWindowComponent<T> : WindowComponent<WinWindow, T> where T : MiniGame
{
    protected void OnGameWin()
    {
        Controller.GameWin();
    }
}
