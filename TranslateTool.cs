using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslateTool {

    public Dictionary<string, string> TranslateDic(List<Text> key, List<Text> values)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        for(int i=0; i<values.Count; i++)
        {
            dic.Add(key[i].text, values[i].text);
        }

        return dic;
    }

    public List<string> TranslateList(Dictionary<string, string> dic)
    {
        return new List<string>(dic.Values); 
    }

    public List<Text> TranslateTextToList(Text[] texts, string placeholderName)
    {
        List<Text> list = new List<Text>();

        foreach(Text t in texts)
        {
            if (!(t.name.Equals(placeholderName)))
            {
                list.Add(t);
            }
        }

        return list;
    }


    //public void DeletePlaceholder(Text[] texts, string placeholderName)
    //{
    //    Text[] a = new Text[0];
    //    for (int i = 0; i < texts.Length; i++)
    //    {
    //        if (!(texts[i].name.Equals(placeholderName)))
    //        {
    //            inputs.Add(texts[i].text);
    //        }
    //    }
    //}
}
