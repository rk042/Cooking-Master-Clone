using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CookingMaster
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] Player[] players;
        [SerializeField] TextMeshProUGUI[] txtPlayers;
        [SerializeField] Item[] items;

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

        public Item GenerateNewItemRandom()
        {
            var ran = new System.Random();
            var item = items[ran.Next(items.Length)];
            Item itemtemp = new Item(item);
            
            return itemtemp;
        }

        public Item GenerateItem(Item item)
        {
            Item itemtemp = new(item);
            return itemtemp;
        }

        public Player GetRandomPlayerForOder()
        {
            var rant = new System.Random();

            return players[rant.Next(players.Length)];
        }
    }
}
