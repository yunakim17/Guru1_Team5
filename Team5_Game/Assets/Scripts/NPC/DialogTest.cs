using System.Collections;
using UnityEngine;
using TMPro;

public class DialogTest : MonoBehaviour
{
    [SerializeField]
    private DialogueManager dialogSystem;
    [SerializeField]
    private TextMeshProUGUI textCountDown;
    [SerializeField]
    private DialogueManager dialogSystem2;

    private IEnumerator Start()
    {
        textCountDown.gameObject.SetActive(false);

        yield return new WaitUntil(() => dialogSystem.UpdateDialog());

        textCountDown.gameObject.SetActive(true);
        int count = 5;
        while (count > 0)
        {
            textCountDown.text = count.ToString();
            count--;

            yield return new WaitForSeconds(1);


        }

        textCountDown.gameObject.SetActive(false) ;

        yield return new WaitUntil(()=>dialogSystem2.UpdateDialog());

        textCountDown.gameObject.SetActive(true);
        textCountDown.text = "The end";

        yield return new WaitForSeconds(2);

        UnityEditor.EditorApplication.ExitPlaymode();
    }
}
