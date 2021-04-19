using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public int life = 3;
        [SerializeField]
        private Transform lifeParent;
        [SerializeField]
        private GameObject lifePrefab;
        private Stack<GameObject> lives = new Stack<GameObject>();

        public void LifeAmount()
        {
                
                        for (int i = 0; i < life; i++)
                        {
                                lives.Push(Instantiate(lifePrefab, lifeParent));
                        }
                
                
        }

        public void RemoveLife()
      {
                Destroy(lives.Pop());
                
        }
        void Start() 
        {
                LifeAmount();
        }

   private void OnCollisionEnter2D(Collision2D collision)
   {
       if(collision.gameObject.CompareTag("Enemy"))
       {
                        Destroy(gameObject);
                        LevelManager.instance.Respawn();
                        RemoveLife();
                }
   }
}
