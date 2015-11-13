using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlideMenu : MonoBehaviour {

    [SerializeField]
    private GameObject selectionMenu;

    [SerializeField]
    private float slideSpeed;

    [SerializeField]
    private float changeAlphaSpeed;

    private float distanceToMove;
    private float startPosX;

    private Image selectionMenuImage;

    //slidestate is false if selectionMenu is not visible
    private bool visible;

    void Awake()
    {
        selectionMenuImage = selectionMenu.GetComponent<Image>();
        distanceToMove = selectionMenuImage.rectTransform.rect.width;
        startPosX = 772;//selectionMenu.transform.position.x;

        
        Color color = selectionMenuImage.color;
        color.a = 0;
        selectionMenuImage.color = color;
        
        foreach (Transform button in selectionMenu.transform)
        {
            button.GetComponent<Image>().color = color;
        }

        selectionMenu.SetActive(false);
    }

    public void Slide() {

        if (!visible) {
            visible = true;
            selectionMenu.SetActive(true);

            Vector3 PositionToGo = new Vector3(startPosX - distanceToMove, selectionMenu.transform.position.y, selectionMenu.transform.position.z);
            StartCoroutine(SlideTo(PositionToGo, false));
            //StartCoroutine(ChangeAlpha(true));
            StartCoroutine(FadeIn());
        }
        else {
            visible = false;
            //selectionMenu.SetActive(false);

            Vector3 PositionToGo = new Vector3(startPosX, selectionMenu.transform.position.y, selectionMenu.transform.position.z);
            StartCoroutine(SlideTo(PositionToGo, true));
            //StartCoroutine(ChangeAlpha(false));
            StartCoroutine(FadeOut());

            selectionMenu.SetActive(false);
        }
    }

    IEnumerator SlideTo(Vector3 _positionToGo, bool _visible) {
        while(selectionMenu.transform.position != _positionToGo && visible != _visible) {
            selectionMenu.transform.position = Vector3.MoveTowards(selectionMenu.transform.position, _positionToGo, slideSpeed);
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
    }
    /*
    IEnumerator ChangeAlpha(bool _visible)
    {
        int a = 0;
        float decrement = changeAlphaSpeed;
        if (_visible) {
            a = 1;
            decrement *= -1;
        }
        while (selectionMenu.color.a != a && visible == _visible)
        {
            print(_visible);
            Color color = selectionMenu.color;
            color.a -= decrement;
            selectionMenu.color = color;

            foreach (Transform button in selectionMenu.transform)
            {
                button.GetComponent<Image>().color = color;
            }

            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
    }*/

    IEnumerator FadeOut()
    {
        while (selectionMenuImage.color.a >= 0 && !visible)
        {
            Color color = selectionMenuImage.color;
            color.a -= changeAlphaSpeed;
            selectionMenuImage.color = color;

            foreach (Transform button in selectionMenu.transform)
            {
                button.GetComponent<Image>().color = color;
            }

            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
    }

    IEnumerator FadeIn()
    {
        while (selectionMenuImage.color.a <= 1 && visible)
        {
            Color color = selectionMenuImage.color;
            color.a += changeAlphaSpeed;
            selectionMenuImage.color = color;

            foreach (Transform button in selectionMenu.transform)
            {
                button.GetComponent<Image>().color = color;
            }

            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
    }
}
