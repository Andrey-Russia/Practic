using UnityEngine;
using UnityEngine.UI;
public class cpritesChange : MonoBehaviour
{
    public Sprite NewSprite;
    private Sprite _initialSprite;
    private Image _buttonImage;

    void Start()
    {
        _buttonImage = GetComponent<Image>();
        _initialSprite = _buttonImage.sprite;
    }

    public void OnClick()
    {
        _buttonImage.sprite = NewSprite;
        Invoke("RestoreInitialSprite", 0.5f);
    }

    void RestoreInitialSprite()
    {
        _buttonImage.sprite = _initialSprite;
    }
}
