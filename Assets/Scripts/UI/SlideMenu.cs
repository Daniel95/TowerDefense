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
            button.gameObject.GetComponent<Shop>().SetClickable = true;
        }
    }

    public void Slide() {
        //Set Visible
        if (!visible) {
            visible = true;
            Vector3 PositionToGo = new Vector3(startPosX - distanceToMove, selectionMenu.transform.position.y, selectionMenu.transform.position.z);
            StartCoroutine(SlideTo(PositionToGo, true));
            //StartCoroutine(ChangeAlpha(true));
            StartCoroutine(FadeIn());

            foreach (Transform button in selectionMenu.transform)
            {
                button.gameObject.GetComponent<Shop>().SetClickable = true;
            }
        }//Set Invisible
        else {
            visible = false;
            //selectionMenu.SetActive(false);

            Vector3 PositionToGo = new Vector3(startPosX, selectionMenu.transform.position.y, selectionMenu.transform.position.z);
            StartCoroutine(SlideTo(PositionToGo, false));
            //StartCoroutine(ChangeAlpha(false));
            StartCoroutine(FadeOut());

            foreach (Transform button in selectionMenu.transform)
            {
                button.gameObject.GetComponent<Shop>().SetClickable = false;
            }
        }
    }

    IEnumerator SlideTo(Vector3 _positionToGo, bool _visible) {
        while(selectionMenu.transform.position != _positionToGo && visible == _visible) {
            selectionMenu.transform.position = Vector3.MoveTowards(selectionMenu.transform.position, _positionToGo, slideSpeed);
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
    }
    
    IEnumerator ChangeAlpha(bool _visible)
    {
        int IntVisible = System.Convert.ToInt32(_visible);
        float decrement = changeAlphaSpeed;
        if (!_visible) changeAlphaSpeed *= -1; 
        foreach (Transform button in selectionMenu.transform)
        {
            button.gameObject.GetComponent<Shop>().SetClickable = true;
        }

        Color color = selectionMenuImage.color;
        while (selectionMenuImage.color.a != IntVisible && visible == _visible)
        {
            color.a -= decrement;
            selectionMenuImage.color = color;

            foreach (Transform button in selectionMenu.transform)
            {
                button.GetComponent<Image>().color = color;
            }

            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
    }

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
