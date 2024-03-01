using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggleButton : MonoBehaviour
{
    public enum ButtonType
    {
        BackgroundMusic,
        SoundFx
    }

    public ButtonType type;

    public Sprite onSprite;
    public Sprite offSprite;

    public GameObject button;
    public Vector3 offButtonPosition;
    public Vector3 onButtonPosition;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.sprite = onSprite;
        onButtonPosition = button.GetComponent<RectTransform>().anchoredPosition;
        ToggleButton();
    }

    public void ToggleButton()
    {
        var muted = false;

        if (type == ButtonType.BackgroundMusic)
            muted = SoundManager.Instance.IsBackgroundMusicMuted();
        else
            muted = SoundManager.Instance.IsSoundFXMuted();

        if (muted)
        {
            _image.sprite = offSprite;
            button.GetComponent<RectTransform>().anchoredPosition = offButtonPosition;
        }
        else
        {
            _image.sprite = onSprite;
            button.GetComponent<RectTransform>().anchoredPosition = onButtonPosition;
        }
    }
}
