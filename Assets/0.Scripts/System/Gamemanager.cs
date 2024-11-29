using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PLAY,
    PAUSE,
    STOP
}

public class UserData
{

}


public class Gamemanager : Singleton<Gamemanager>
{
    public GameState gameState = GameState.STOP;

    public void ChangeGameState(GameState state)
    {
        gameState = state;
    }
}
