using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to Pan.
// Moves Pan.

public class PanMovement : MonoBehaviour
{

   // [SerializeField]
  // GameObject _menuPuckText;

    [SerializeField]
    Transform panTrans;

    [SerializeField]
    SpriteRenderer panSR;
    
    public Vector3 originalPos;
    Vector3 gamePos;
    Vector3 gamePosLeft;

    Vector2 large;
    Vector2 small;

    [SerializeField] GameObject _circleBackground;
    [SerializeField] GameObject _menuReturnButton;
    GameObject prefabHolder;
    GameObject prefabReturnMenu;

    [SerializeField] GameObject _menuRingFill;

    Color _ringFillAlpha;

    public bool _prefabHolder;
       
    Vector3 offScreenCB;
    Vector3 centerScreenCB;

    Vector3 centerStart;
    Vector3 centerEnd;
    Vector3 centerEndLeft;
    Vector3 endPos;
    Vector3 endPosLeft;
    Vector3 center;
    Vector3 centerLeft;
    Vector3 endPosLeftOffScreen;
    Vector3 centerStartLeft;
    Vector3 centerOffScreen;

    public MenuScript _menuScript;

    [SerializeField] Text01Score _text01Score;
    [SerializeField] TextTwoScore _textTwoScore;
    [SerializeField] StartFireWorks01 _startFireWorks01;
    [SerializeField] StartFireWorks02 _startFireWorks02;
    [SerializeField] CountDown _countDown;
    [SerializeField] GameObject _puck;
    void Start()
    {
        _puck.SetActive(false);

        prefabHolder = Instantiate(_circleBackground) as GameObject;
        // prefabReturnMenu = Instantiate(_menuReturnButton) as GameObject;
        
       prefabHolder.transform.position = centerScreenCB;
        _menuRingFill.SetActive(false);
        panTrans = GetComponent<Transform>();

        centerScreenCB = new Vector3(0, 0, 0);
        offScreenCB = new Vector3(0, 20f, 0);

        originalPos = panTrans.position;
         gamePosLeft = new Vector3(-13f, 4f, 0);

        large = panTrans.localScale;
        small = new Vector3(1f, .8f, 0 );

        endPosLeft = new Vector3(-13f, 4f, 0);
        endPosLeftOffScreen = new Vector3(-20f, 4f, 0);
        center = originalPos * 0.5f;   // Originally - center = (originalPos + gamePos)* 0.5f;
        centerLeft = (endPosLeftOffScreen + originalPos) * .2f;
        
        centerStart = panTrans.position - center;

        centerStartLeft = originalPos - centerLeft;
        centerEnd = endPos - center;
        centerEndLeft = endPosLeft - center;
        centerOffScreen = endPosLeftOffScreen - centerLeft;   //  centerOffScreen = endPosLeft - centerLeft;
    }

        

        public void MovePan()
        {
            _countDown.StartCount();
            PreFabMenu();
            StartCoroutine(SlerpingIn());
            StartCoroutine(PanMoving());
        }

    
         public void PreFabMenu()
        {
            prefabReturnMenu = Instantiate(_menuReturnButton) as GameObject;
            prefabReturnMenu.SetActive(true);
        }


        IEnumerator SlerpingIn()
        {
            float time = 0f;
            float duration = .8f;
            
             yield return new WaitForSeconds(.6f);
            
                    while(time < duration)
                    {
                        panTrans.position = Vector3.Slerp(centerStart, centerEndLeft, time / duration);
                        panTrans.localScale = Vector2.Lerp(large, small, time / duration );
                        time += Time.deltaTime;
                        transform.position += center;
                        yield return null;
                    }

            yield return new WaitForSeconds(.3f);

            Destroy(prefabHolder, 1);

            yield return null;     

            _startFireWorks01.FireWorks01();
            _startFireWorks02.FireWorks02();
             _text01Score.StartText01();
            _textTwoScore.StartText02();
        }


        IEnumerator PanMoving()
        {
            float time = 0f;
            float duration = 1f;

             yield return new WaitForSeconds(6.3f);

                    while(time < duration)
                    {
                        panTrans.position = Vector2.Lerp(gamePosLeft, endPosLeftOffScreen, time / duration );
                        time += Time.deltaTime;
                        yield return null;
                    }

             _menuRingFill.SetActive(true);
             yield return null;
        }


        IEnumerator SlerpingOut()
        {
            float time = 0f;
            float duration = 1f;
            
             endPosLeftOffScreen = panTrans.position;

            while(time < duration)
            {
                panTrans.position = Vector3.Slerp(  centerOffScreen, centerStartLeft, time / duration);
                panTrans.localScale = Vector2.Lerp( small, large, time / duration );
                time += Time.deltaTime;
                transform.position += centerLeft;
                yield return null;
            }

             _menuRingFill.SetActive(false);
             yield return null;
        }



   public void restoreMenu()
                {
                    StartCoroutine(SlerpingOut());
                prefabHolder = Instantiate(_circleBackground) as GameObject;
                prefabHolder.transform.position = offScreenCB;
                
                    StartCoroutine(lowerTheScreen());
                }


    IEnumerator lowerTheScreen()
        {
                float time = 0f;
                float duration = 1.5f;

               _text01Score.FadeTextScore01();
               _textTwoScore.FadeTextScore02();

                while(time < duration)
                {
                    prefabHolder.transform.position = Vector2.Lerp(offScreenCB, centerScreenCB, time / duration );
                    time += Time.deltaTime;
                    yield return null;
                }
                _menuScript.FreezeCircles();
                Destroy(prefabReturnMenu, 1);
                _puck.SetActive(false);
        }

     

}


