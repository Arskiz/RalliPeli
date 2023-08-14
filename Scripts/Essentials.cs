using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Essentials : MonoBehaviour
{

    public GameObject _player;

    public void OpenMenu(GameObject target)
    {
        target.SetActive(true);
    }


    public void CloseMenu(GameObject target)
    {
        target.SetActive(false);
    }

    public void ToggleButtonInteractionStatus(Button button)
    {
        button.interactable = !button.interactable;
    }

    public void SetButtonInteractable(Button button)
    {
        button.interactable = true;
    }

    public void SetButtonNotInteractable(Button button)
    {
        button.interactable = false;
    }

    public IEnumerator FadeText(int inOrOut, TextMeshProUGUI textObject, float fadeMultiplier)
    {
        Color originalColor = textObject.color;
        Color targetColor;

        if (inOrOut == 0)
        {
            targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1);
        }
        else
        {
            targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        }

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * fadeMultiplier;
            textObject.color = Color.Lerp(originalColor, targetColor, t);
            yield return null;
        }
    }

    public IEnumerator FadeTextInOut(TextMeshProUGUI textToFade)
    {
        yield return FadeText(0, textToFade, 1.0f); // Fade in
        yield return new WaitForSeconds(2.0f); // Wait for 2 seconds
        yield return FadeText(1, textToFade, 1.0f); // Fade out
    }



    public void SwitchMenu(GameObject old, GameObject target)
    {
        old.SetActive(false);
        target.SetActive(true);
    }

    public void SwitchMenu(GameObject old, GameObject old2, GameObject target)
    {
        old.SetActive(false);
        old2.SetActive(false);
        target.SetActive(true);
    }
    public void SwitchMenu(GameObject old, GameObject old2, GameObject old3, GameObject target)
    {
        old.SetActive(false);
        old2.SetActive(false);
        old3.SetActive(false);
        target.SetActive(true);
    }
    public void SwitchMenu(GameObject old, GameObject old2, GameObject old3, GameObject old4, GameObject target)
    {
        old.SetActive(false);
        old2.SetActive(false);
        old3.SetActive(false);
        old4.SetActive(false);
        target.SetActive(true);
    }
    public void SwitchMenu(GameObject old, GameObject old2, GameObject old3, GameObject old4, GameObject old5, GameObject target)
    {
        old.SetActive(false);
        old2.SetActive(false);
        old3.SetActive(false);
        old4.SetActive(false);
        old5.SetActive(false);
        target.SetActive(true);
    }

    public void SetGameObjectStatusFALSE(GameObject target)
    {
        if (target != null)
            target.SetActive(false);
    }

    public void SetGameObjectStatusTRUE(GameObject target)
    {
        if (target != null)
            target.SetActive(true);
    }

    public bool CheckCheckBoxActiveStatus(Toggle checkbox)
    {
        return checkbox.isOn;
    }

    public void SetSliderINT(Slider slider, int targetAmount)
    {
        slider.value = targetAmount;
    }

    public void SetSliderINT(Slider slider, out int sliderINTVar, int targetAmount)
    {
        slider.value = targetAmount;
        sliderINTVar = targetAmount;
    }

    public void SetSliderFLOAT(Slider slider, int targetAmount)
    {
        slider.value = targetAmount;
    }

    public void SetSliderFLOAT(Slider slider, out float sliderFLOATVar, float targetAmount)
    {
        slider.value = targetAmount;
        sliderFLOATVar = targetAmount;
    }

    public void UpdateText(TextMeshProUGUI textObject, string targetText)
    {
        textObject.text = targetText;
    }


    public Sprite SetValue(Sprite sourceImage)
    {
        return sourceImage;
    }


    public void SetValue(out int intObject, int targetInt)
    {
        intObject = targetInt;
    }

    public void SetValue(out float floatObject, float targetFloat)
    {
        floatObject = targetFloat;
    }

    public void SetValue(out string stringObject, string targetString)
    {
        stringObject = targetString;
    }

    public void SetVolume(AudioSource source, float target)
    {
        source.volume = target;
    }

    public void SetValue(TextMeshProUGUI textObject, string targetString)
    {
        textObject.text = targetString;
    }

    public void SetValue(out bool boolObject, bool targetBool)
    {
        boolObject = targetBool;
    }

    public void SetValue(out bool boolObject, Toggle boolStatus, bool targetBool)
    {
        boolObject = targetBool;
        boolStatus.isOn = targetBool;
    }

    public void SetValue(List<string> listObject, List<GameObject> targetList)
    {
        if (listObject != null || targetList != null)
        {
            foreach (GameObject obj in targetList)
            {
                listObject.Add(obj.name);
            }
        }

    }

    public void SetValue(List<GameObject> listObject, List<string> targetList)
    {
        if (listObject != null || targetList != null)
        {
            GameObject[] findItemsInScene = Resources.FindObjectsOfTypeAll<GameObject>();

            foreach (GameObject obj in findItemsInScene)
            {
                foreach (string stringObj in targetList)
                {
                    if (obj.name == stringObj)
                    {
                        listObject.Add(obj);
                    }
                }
            }
        }

    }

    public GameObject FindObjectByName(string item)
    {
        GameObject[] findItemsInScene = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in findItemsInScene)
        {
            if (obj.transform.gameObject.name == item)
            {
                return obj;
            }
        }

        // If the loop doesn't find any matching object, return null.
        return null;
    }

    public GameObject FindObjectByTag(string tag)
    {
        GameObject[] findObjectsByTag = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in findObjectsByTag)
        {
            if (obj.transform.tag == tag)
            {
                return obj;
            }
        }
        return null;
    }

    public TextMeshProUGUI FindTextObjectByTag(string tag)
    {
        TextMeshProUGUI[] findObjectsByTag = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textObj in findObjectsByTag)
        {
            if (textObj.tag == tag)
            {
                return textObj;
            }
        }
        return null;
    }

    public TextMeshProUGUI FindTextObjectByName(string name)
    {
        TextMeshProUGUI[] findObjectsByName = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textObj in findObjectsByName)
        {
            if (textObj.name == name)
            {
                return textObj;
            }
        }
        return null;
    }

    public GameObject FindGameObjectFromListWithName(List<GameObject> list, string stringToFind)
    {
        foreach (GameObject obj in list)
        {
            if (obj.name == stringToFind)
            {
                return obj;
            }
        }
        return null;
    }

    public GameObject FindGameObjectFromListWithGameObject(List<GameObject> list, GameObject gameObjectToFind)
    {
        foreach (GameObject obj in list)
        {
            if (obj == gameObjectToFind)
            {
                return obj;
            }
        }
        return null;
    }
    public GameObject FindGameObjectFromListWithID(List<GameObject> list, int id)
    {
        foreach (GameObject obj in list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i == id)
                {
                    return list[i];
                }
            }
        }
        return null;
    }

    public bool GetGameObjectVisibility(GameObject gameObjecti)
    {
        if (gameObjecti.activeSelf)
            return true;
        else
            return false;
    }

    public bool KeyPressed(KeyCode targetKey)
    {
        return Input.GetKeyDown(targetKey);
    }

    public bool KeyHeldDown(KeyCode targetKey)
    {
        return Input.GetKey(targetKey);
    }

    public Resolution ParseResolution(string resolutionString)
    {
        // Remove the refresh rate information from the resolution string
        string[] parts = resolutionString.Split('@');
        resolutionString = parts[0].Trim();

        parts = resolutionString.Split('x');

        if (parts.Length != 2)
        {
            Debug.LogError("Invalid resolution format: " + resolutionString);
            return new Resolution { width = 1920, height = 1080 }; // Provide a default resolution if parsing fails
        }

        if (!int.TryParse(parts[0], out int width) || !int.TryParse(parts[1], out int height))
        {
            Debug.LogError("Failed to parse resolution: " + resolutionString);
            return new Resolution { width = 1920, height = 1080 }; // Provide a default resolution if parsing fails
        }

        return new Resolution { width = width, height = height };
    }




}
