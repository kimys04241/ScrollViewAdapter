using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapter : MonoBehaviour
{

    public Texture2D[] availableIcons;
    public RectTransform prefab;
    //public Text countText;
    public ScrollRect scrollView;
    public RectTransform content;

    string[] trainingKind;

    List<ExampleItemView> views = new List<ExampleItemView>();

    // Use this for initialization
    void Start()
    {
        //int.TryParse(countText.text, out newCount);
        //Debug.Log(newCount);
        StartCoroutine(FetchItemModelsFromServer(availableIcons.Length, results => OnReceivedNewModels(results), transform.name));

    }

    public void UpdateItems()
    {
        int newCount = 0;
        //int.TryParse(countText.text, out newCount);
        //Debug.Log(newCount);
        StartCoroutine(FetchItemModelsFromServer(newCount, results => OnReceivedNewModels(results), transform.name));

    }

    void OnReceivedNewModels(ExampleItemModel[] models)
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        views.Clear();

        int i = 0;

        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject);
            instance.transform.SetParent(content, false);
            var view = InitializeItemView(instance, model);
            views.Add(view);

            i++;
        }
    }

    ExampleItemView InitializeItemView(GameObject viewGameObject, ExampleItemModel model)
    {

        ExampleItemView view = new ExampleItemView(viewGameObject.transform);

        view.titleText.text = model.title;
        view.icon1Image.texture = availableIcons[model.icon1Index];

        return view;
    }

    IEnumerator FetchItemModelsFromServer(int count, Action<ExampleItemModel[]> onDone, string transformNm)
    {

        yield return null;

        
        var results = new ExampleItemModel[count];
        for (int i = 0; i < count; i++)
        {
            results[i] = new ExampleItemModel();
            switch (transformNm)
            {
                case "RightScrollView":
                    results[i].title = "";
                    break;

                case "LeftScrollView":
                    results[i].title = trainingKind[i];
                    break;
            }
            
            results[i].icon1Index = i;
        }

        onDone(results);
    }

    public class ExampleItemView
    {
        public Text titleText;
        public RawImage icon1Image, icon2Image, icon3Image;

        public ExampleItemView(Transform rootView)
        {
            titleText = rootView.Find("BackgroundName").GetComponent<Text>();
            icon1Image = rootView.Find("TrainingBackground").GetComponent<RawImage>();
        }
    }

    public class ExampleItemModel
    {
        public string title;
        public int icon1Index;
    }
}
