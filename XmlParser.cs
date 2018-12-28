using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class XmlParser {

    public Dictionary<string, string> SelectXml(string loadXmlName, string selectNodeName)
    {
        Dictionary<string, string> selectedData = new Dictionary<string, string>();
        TextAsset textAsset = (TextAsset)Resources.Load(loadXmlName);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);


        XmlNodeList nodes = xmlDoc.SelectNodes(selectNodeName);

        nodes = nodes[0].ChildNodes;

        for(int i=0; i<nodes.Count; i++)
        {
            selectedData.Add(nodes[i].Name, nodes[i].InnerText);
            //Debug.Log("딕셔너리키:"+nodes[i].Name+"딕셔너리밸류"+nodes[i].InnerText);
        }



        return selectedData;

    }

    public Dictionary<string, string> SelectXml(string loadXmlName, string selectNodeName, List<string> dissConnNm)
    {
        Dictionary<string, string> selectedData = new Dictionary<string, string>();
        TextAsset textAsset = (TextAsset)Resources.Load(loadXmlName);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes(selectNodeName);

        nodes = nodes[0].ChildNodes;

        for (int i = 0; i < nodes.Count; i++)
        {
            for(int j=0; i<dissConnNm.Count; j++)
            {
                if (nodes[i].Name.Equals("aa"))
                {
                    selectedData.Add(nodes[i].Name, nodes[i].InnerText);
                }
            }
        }
        return selectedData;
    }

    public void UpdateXml(string loadXmlName, string selectNodeName ,Dictionary<string, string> ports)
    {
        TextAsset textAsset = (TextAsset)Resources.Load(loadXmlName);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes(selectNodeName);
        XmlNode sensorPort = nodes[0];
        

        List<string> keyList = new List<string>(ports.Keys);

        for(int i=0; i<ports.Count; i++)
        {
            string value;
            ports.TryGetValue(keyList[i], out value);
            if (value.Equals("")) continue;

            
            sensorPort.SelectSingleNode(keyList[i]).InnerText = value;
        }

        xmlDoc.Save("./Assets/Resources/"+loadXmlName+".xml");

    }
}
