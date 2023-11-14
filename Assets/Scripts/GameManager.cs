using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CookingMaster
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] Player[] players;
        [SerializeField] TextMeshProUGUI[] txtPlayers;

        public static GameManager instance { get; private set; }

        public EventHandler<Player> OnScoreUpdate;

        private void Awake()
        {
            instance = this;
        }

        private void OnEnable()
        {
            Timer.instance.OnTimerOver += OnTimerOver;
            OnScoreUpdate += PlayerScoreUpdate;
        }


        private void OnDisable()
        {
            Timer.instance.OnTimerOver -= OnTimerOver;
            OnScoreUpdate -= PlayerScoreUpdate;
        }

        private void PlayerScoreUpdate(object sender, Player e)
        {
            txtPlayers[e.PlayerId].text = $"Player {e.PlayerId} Score : {e.Score.ToString("00")}";
        }
        
        private void OnTimerOver()
        {
            if (players[0].Score < players[1].Score)
            {
                Debug.Log("Player 0 is lose");
                Debug.Log("Player 1 is win");
            }

            if (players[0].Score > players[1].Score)
            {
                Debug.Log("Player 0 is win");
                Debug.Log("Player 1 is lose");
            }
            if (players[0].Score == players[1].Score)
            {
                Debug.Log(" == Game Is Draw == ");
            }
        }

    }
}
