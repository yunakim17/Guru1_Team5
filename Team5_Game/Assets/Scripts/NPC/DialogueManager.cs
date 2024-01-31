using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private Speaker[] speakers;
    [SerializeField]
    private DialogData[] dialogs;
    [SerializeField]
    private bool isAutoStart = true;
    private bool isFirt = true;
    private int currentDialogIndex = -1;
    private int currentSpeakerIndex = 0;
    private float typingSpeed = 0.1f;
    private bool isTypingEffect = false;

    public GameObject SceneChangeButton;
    public GameObject ClickObj;
    Text ClickText;

    private void Awake()
    {
        SetUp();
        ClickObj = GameObject.Find("Click");
    }

    void Start()
    {
        //GameObject SceneChangeButton = GameObject.Find("SceneChangeButton");
       // SceneChangeButton = GetComponent<GameObject>();
       SceneChangeButton.SetActive(false);
        ClickText = ClickObj.GetComponent<Text>();
        ClickObj.SetActive(false);

    }

    private void SetUp()
    {
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialog()
    {
            if(isFirt == true)
            {
                SetUp();

                if (isAutoStart) SetNextDialog();

                isFirt = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
            if(isTypingEffect == true)
             {
                isTypingEffect = false;

                StopCoroutine("OnTypingText");
                speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;

                speakers[currentSpeakerIndex].objectArrow.SetActive(true);

                return false;
              }

                if (dialogs.Length > currentDialogIndex + 1)
                {
                    SetNextDialog();
                }
                else
                {
                    for (int i = 0; i < speakers.Length; ++i)
                    {
                        //SetActiveObjects(speakers[i], false);
                        speakers[i].spriteRenderer.gameObject.SetActive(false);
                    }
                ClickObj.SetActive(true);
                SceneChangeButton.SetActive(true);
                return true;
                }
            }

            return false;
    }

    //IEnumerator TypeTextEffect(string text)
    //{
       // Text.text = string.Empty;

       // StringBuilder stringBuilder = new StringBuilder();

       // for(int i = 0; i < text.Length; i++)
       // {
       //     stringBuilder.Append(text[i]);
        //    Text.text = stringBuilder.ToString();
       //     yield return new WaitForSeconds(0.01f);
      //  }
   // }

    private void SetNextDialog()
    {
        SetActiveObjects(speakers[currentSpeakerIndex], false);

        currentDialogIndex++;

        currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

        SetActiveObjects(speakers[currentSpeakerIndex], true);

        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;

        //speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
        StartCoroutine("OnTypingText");
    }  

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);

        speaker.objectArrow.SetActive(false);

        Color color = speaker.spriteRenderer.color;
        color.a = visible == true ? 1 : 0.2f;
        speaker.spriteRenderer.color = color;
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;

        isTypingEffect = true;

        while(index < dialogs[currentDialogIndex].dialogue.Length)
        {
            speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue.Substring(0, index);

            index++;

            yield return new WaitForSeconds(typingSpeed);
        }
        isTypingEffect = false;

        speakers[currentSpeakerIndex].objectArrow.SetActive(true);
    }
    
}


    [System.Serializable]
    public struct Speaker
    {
        public SpriteRenderer spriteRenderer;
        public Image imageDialog;
        public TextMeshProUGUI textName;
        public TextMeshProUGUI textDialogue;
        public GameObject objectArrow;
    }
    [System.Serializable]
    public struct DialogData
    {
        public int speakerIndex;
        public string name;
        [TextArea(3, 5)]
        public string dialogue;
    }
   