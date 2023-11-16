using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;
using Random = UnityEngine.Random;

namespace CookingMaster
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] TextMeshPro txtOderTimerUI;
        [SerializeField] TextMeshPro txtOderPlayerName;
        [SerializeField] private SpriteRenderer[] oderItemRenderer;

        const string pathSpriteResporce = "OF166L0";

        private Sprite[] customerIcons = new Sprite[] { };

        private List<Item> itemCustomer=new();

        private bool hasItems = false;

        private Player playerOder;

        private void Awake()
        {
            customerIcons = Resources.LoadAll<Sprite>(pathSpriteResporce);
        }
        private void Start()
        {
            GenerateNewOder();
        }

        private void CustomerGenerate()
        {
            spriteRenderer.sprite = customerIcons[Random.Range(0, customerIcons.Length)];
        }
        private void GenerateNewOder()
        {
            spriteRenderer.sprite = null;

            txtOderPlayerName.text = string.Empty;

            foreach (var item in oderItemRenderer)
            {
                item.sprite = null;
            }

            itemCustomer.Clear();


            Invoke(nameof(_GenerateNewOder), Random.Range(3, 10));
        }
        private void _GenerateNewOder()
        {
            
            playerOder = GameManager.instance.GetRandomPlayerForOder();
            txtOderPlayerName.text = $"Oder : {playerOder.name}";

            CustomerGenerate();

            int length = Random.Range(0,2);

            float totalItemCookTime = 0;
            
            for (int i = 0; i <= length; i++)
            {
                var itemToadd = GameManager.instance.GenerateNewItemRandom();
                itemCustomer.Add(itemToadd);
                totalItemCookTime += itemCustomer[i].ChoopingSpeed;
                oderItemRenderer[i].sprite = itemCustomer[i].sprite;
            }

            totalItemCookTime += Random.Range(20, 40);

            //Debug.Log($"Generate New Oder {name} __ {playerOder.name}",this);
            foreach (var item in itemCustomer)
            {
                Debug.Log(item.ItemFood);
            }
            StartCoroutine(Cor_CustomerLeft(totalItemCookTime));
        }

        private IEnumerator Cor_CustomerLeft(float time)
        {
            for (float i = time; i >= 0; i--)
            {
                yield return new WaitForSecondsRealtime(1f);
                txtOderTimerUI.text = $"TimeLeft : {i:00}";
            }

            foreach (var item in itemCustomer)
            {
                playerOder.Score -= item.Money;
                GameManager.instance.OnScoreUpdate?.Invoke(null, playerOder);
            }
                        
            GenerateNewOder();
            
            yield break;
        }
       
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IPickupItems items))
            {
                if (items.manager.pickUpItems.Any())
                {
                    if (items.manager.isChoopingDone)
                    {
                        Debug.Log("food delivered");
                        items.manager.isChoopingDone = false;
                        
                        foreach (var item in items.manager.pickUpItems)
                        {
                            items.player.Score+=item.Money;
                        }
                        
                        GameManager.instance.OnScoreUpdate?.Invoke(null,items.player);
                        GenerateNewOder();

                        items.manager.pickUpItems.Clear();
                        items.manager.ClearPlayerHands();
                    }
                    else
                    {
                        foreach (var item in items.manager.pickUpItems)
                        {
                            if (!item.IsChooped)
                            {
                                Debug.LogError($"{item.ItemFood} is not cooked.");
                                items.player.Score -= item.Money;
                                GameManager.instance.OnScoreUpdate?.Invoke(null, items.player);

                                GenerateNewOder();
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("there is not food to deliver");
                    
                    foreach (var item in items.manager.pickUpItems)
                    {
                        items.player.Score -= item.Money;
                    }

                    GameManager.instance.OnScoreUpdate?.Invoke(null, items.player);

                    GenerateNewOder();

                }
            }
        }
    }
}
