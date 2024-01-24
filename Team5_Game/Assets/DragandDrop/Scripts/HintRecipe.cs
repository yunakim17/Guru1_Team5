using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintRecipe : MonoBehaviour
{

    public static HintRecipe Instance;

    public Text hintRecipe;

    string[] recipeArray = new string[] { " 1. ºÒ»çÁ¶ÀÇ ±êÅÐ \r\n 2. ²É \r\n 3. »¡°£ ¹ö¼¸  \r\n 4. µµ¸¶¹ìÀÇ ²¿¸®  \r\n 5. »Ñ¸®", " 1. ¿ëÀÇ ºñ´Ã \r\n 2. ºÐÈ«²É \r\n 3. ÆÄ¶õ ¹ö¼¸  \r\n 4. »Ñ¸®  \r\n 5. ºÒ»çÁ¶ÀÇ ±êÅÐ", " 1. µµ¸¶¹ìÀÇ ²¿¸® \r\n 2. »Ñ¸® \r\n 3. ÃÊ·Ï ¹ö¼¸ \r\n 4. ºÒ»çÁ¶ÀÇ ±êÅÐ  \r\n 5. ²É" }; //¼öÁ¤

    string hint;
    private void Awake()
    {
        if (HintRecipe.Instance == null)
        {
            HintRecipe.Instance = this;
        }
    }

    public void SaveHint(int num)
    {
        hint = recipeArray[num];
    }


    public void HintBtnPressedRecipe()
    {
        gameObject.SetActive(true);
        hintRecipe.text = hint;
        Invoke("HintRecipeDisappear", 4f);
    }

    void Start()
    {
        gameObject.SetActive(false);
    }


    void HintRecipeDisappear()
    {
        gameObject.SetActive(false);
    }
}
