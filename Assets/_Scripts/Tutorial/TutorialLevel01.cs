
using System.Collections;
using UnityEngine;

namespace _Scripts.Tutorial
{
    public class TutorialLevel01 : BaseTutorial
    {
        public GameObject panels;


        public GameObject moveMessage;
        
        
        public GameObject collectMessage;



        private bool isShowMoveMessage = false;
        private bool isShowCollectMessage = false;
        private void Start()
        {
            // ShowPanel
            StartCoroutine(ShowMoveMessage());
            StartCoroutine(ShowCollectMessage());
        }

        private IEnumerator ShowCollectMessage()
        {
            while (!isShowMoveMessage)
            {
                yield return null;
            }
            collectMessage.transform.SetParent(this.holeController.transform.Find("Canvas"));
            yield return new WaitForSeconds(1f);
            collectMessage.SetActive(true);
            
            //yield return new WaitForSeconds(7f);
            
            //Debug.Log("?????");
            //collectMessage.SetActive(false);
        }


        public IEnumerator  ShowMoveMessage()
        {
            moveMessage.SetActive(true);
            //moveMessage.transform.SetParent(this.HoleController.transform);
            
            while (this.holeController.HoleMovement.GetDirectionMovement() == Vector2.zero)
            {
                yield return null;
                
                
            }

            isShowMoveMessage = true;
            moveMessage.transform.SetParent(holeController.transform.Find("Canvas"));
            
            yield return new WaitForSeconds(3f);
            
            //Debug.Log("?????");
            Destroy(moveMessage);


            //Debug.Log(moveMessage.transform.position);
        }
    }
}