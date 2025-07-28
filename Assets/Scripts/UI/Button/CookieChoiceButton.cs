using UnityEngine;

public class CookieChoiceButton : ParentButton
{
    private int _key;
    private bool _isSet;
    public int Key
    { get { return _key; } 
      set { _key = value; }
    }

    public void SetButton()
    {
        _isSet = false;
        ChangeImage();
    }
    protected override void OnButtonClick()
    {
        //��ġ �����ϰ� �ѱ��� + ȭ�鿡 ����
        SettingManager();

    }
    private void SettingManager()
    {
        if (!_isSet)
        {
            CharacterManager.Instance.SetCharacter(_key, 1); //���̰� ��ߵǴµ� �����鼭 �������ұ�? 
            _isSet = true;
        }
        else
        {
            _isSet = false;
            CharacterManager.Instance.SetOffCharacter(_key);
        }
    }
    private void ChangeImage()
    {
        _image.sprite = Resources.Load<Sprite>("Textures/CharacterCard/cookie"+Key+"_card");
    }
}
