using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CookingMaster
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] int GameTimer;
        [SerializeField] TextMeshProUGUI txtTimer;
        
        public static Timer instance { get; private set; }

        public event System.Action OnTimerOver;

        private void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(CorTimer());
        }

        private IEnumerator CorTimer()
        {
            for (int i = GameTimer; i >= 0; i--) { 
            
                yield return new WaitForSecondsRealtime(1);

                txtTimer.text = $"Timer : {i:00}";
            }

            //timer over

            Debug.Log(" == game over == ");
            OnTimerOver?.Invoke();
        }
    }
}
