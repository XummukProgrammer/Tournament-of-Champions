using System;
using System.Collections.Generic;

public class MiniGamesManager
{
    private EntryPoint _entryPoint;
    private List<MiniGame> _miniGames = new List<MiniGame>();

    public void Init(EntryPoint entryPoint)
    {
        _entryPoint = entryPoint;
    }

    public void Deinit()
    {
        foreach (var game in _miniGames)
        {
            game.Deinit();
        }

        _miniGames.Clear();
    }

    public void Update()
    {
        foreach (var game in _miniGames)
        {
            if (game.State != MiniGameState.Disable)
            {
                game.Update();
            }
        }
    }

    public T CreateAndAddMiniGame<T>(GameComponents components) where T : MiniGame
    {
        var miniGame = Activator.CreateInstance<T>();
        AddMiniGame(miniGame, components);
        return miniGame;
    }

    private void AddMiniGame(MiniGame miniGame, GameComponents components)
    {
        miniGame.Init(_entryPoint, components);
        _miniGames.Add(miniGame);

        miniGame.PostInit();
    }

    public T GetMiniGame<T>() where T : MiniGame
    {
        foreach (var miniGame in _miniGames)
        {
            if (miniGame is T)
            {
                return miniGame as T;
            }
        }
        return null;
    }

    public void StartMiniGame<T>() where T : MiniGame
    {
        // TODO: Реализовать переход в мини-игру с помощью загрузочного экрана и очереди действий

        var miniGame = GetMiniGame<T>();
        if (miniGame != null)
        {
            miniGame.Start();
        }
    }
}
