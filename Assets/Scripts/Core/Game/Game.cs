using System;
using UnityEngine;

[System.Serializable]
public class Game
{
    public IGameState state;
    public LevelManager levelManager;
    public UIManager uiManager;
    public PlayerMovement player;
    public AIMovement[] oppenentList;
    public Game(LevelManager _levelManager, UIManager _uiManager)
    {
        this.levelManager = _levelManager;
        this.uiManager = _uiManager;
    }

    public void InitLevel(PlayerMovement _player, AIMovement[] _opponentList)
    {
        this.player = _player;
        
        if(oppenentList != null )
        {
            for (int i = 0; i < oppenentList.Length; i++)
            {
                oppenentList[i] = _opponentList[i];
            }
        }
        else
        {
            this.oppenentList = _opponentList;
        }

    }
    public void UpdatePlayerPlace()
    {
        int place = 1;
        foreach (var opponent in oppenentList)
        {
            if (opponent.transform.position.z - player.transform.position.z > 0)
                place++;
        }
        player.place = place;

        uiManager.UpdatePlace(player.place, oppenentList.Length+1);
    }

    public void UpdateWallPercentage(float percentage)
    {
        uiManager.UpdateWallPercentage(percentage);
    }

    public void InitGame(IGameState initialGameState)
    {
        state = initialGameState;
    }

    public void FinishRace()
    {
        player.rb.MovePosition(new Vector3(0, player.transform.position.y, player.transform.position.z));
        if (player.place < 4)
            Win();
        else
            Fail();
    }

    public void Win()
    {
        this.state.Win();
    }

    public void Fail()
    {
        this.state.Fail();
    }

    public void Play()
    {
        this.state.Play();
    }

    public void BackToMenu()
    {
        this.state.BackToMenu();
    }
}

