using UnityEngine;

public class CookieChoiceButton : ParentButton
{
    private int _key;
    private bool _isSet;

    public bool IsSet
    {
        get { return _isSet; }
        set { _isSet = value; }
    }
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
        CharacterSetting();

    }
    private void CharacterSetting()
    {
        if (!_isSet)
        {
            _isSet = CharacterManager.Instance.SetCharacter(_key); //���̰� ��ߵǴµ� �����鼭 �������ұ�? 
        }
        else
        {
            _isSet = false;
            CharacterManager.Instance.SetOffCharacter(_key);
        }
    }
    private void ChangeImage()
    {
        _image.sprite = Resources.Load<Sprite>("Textures/CharacterCard/cookie"+1001+"_card");
    }
}
