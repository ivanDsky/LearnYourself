using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using AnswerTypes;
using GameModeTypes;
using QuestionTypes;
using UnityEngine;

namespace QASpace
{
    [XmlRoot]
    public class QA : IXmlSerializable
    {
        public IQuestionType question;
        public IAnswerType answer;
        public List<QATag> tags = new List<QATag>{QATag.Default};
        public IGameModeType gameMode;
        public string path;
        public float points;
        public bool isSelected;

        public QA(IQuestionType question, IAnswerType answer, IGameModeType gameMode,string path = "",float points = 1)
        {
            this.question = question;
            this.answer = answer;
            this.gameMode = gameMode;
            this.points = points;
            this.path = path;
            Folders.Folder.DefaultFolder.AddQuestion(this);
        }
        
        
        
        
        

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            Debug.Log("Read");
            string rootName = reader.Name;
            string fullTypeName = string.Empty;
            string shortTypeName = string.Empty;
            FieldInfo interName = null;
            XmlSerializer xml = null;
            FieldInfo[] fieldInfos = GetType().GetFields();
            FieldInfo[] fieldInterfaces = fieldInfos.Where(t => t.FieldType.IsInterface).ToArray();
            FieldInfo[] fieldNormal = fieldInfos.Where(t => !t.FieldType.IsInterface).ToArray();;
            
            while (true)
            {
                bool readNext = true;
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    if(reader.Name == rootName){
                        reader.ReadEndElement();
                        break;
                    }
                }
                else if (reader.NodeType == XmlNodeType.Element)
                {
                    if (fieldInterfaces.Any(t => t.Name == reader.Name))
                    {
                        fullTypeName = reader.GetAttribute("type");
                        xml = new XmlSerializer(Type.GetType(fullTypeName));
                        shortTypeName = Type.GetType(fullTypeName).Name;
                        interName = fieldInterfaces.Where(t => t.Name == reader.Name).ToArray()[0];
                    }
                    else
                    {
                        FieldInfo[] far = fieldNormal.Where(t => t.Name == reader.Name).ToArray();
                        if (far.Length != 0)
                        {
                            FieldInfo f = far[0];
                            xml = new XmlSerializer(f.FieldType, new XmlRootAttribute(f.Name));
                            f.SetValue(this, xml.Deserialize(reader));
                            readNext = false;
                        }
                    }

                    if (fullTypeName != string.Empty)
                    {
                        if (reader.Name == shortTypeName)
                        {
                            interName.SetValue(this,xml.Deserialize(reader));
                            fullTypeName = String.Empty;;
                        }
                    }
                }


                if (readNext) reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            FieldInfo[] fieldInfos = GetType().GetFields();
            foreach (var field in fieldInfos)
            {
                XmlSerializer xml;
                if (field.FieldType.IsInterface)
                {
                    writer.WriteStartElement(field.Name);
                    xml = new XmlSerializer(field.GetValue(this).GetType());
                    writer.WriteAttributeString("type",field.GetValue(this).GetType().ToString());//NOTE
                    xml.Serialize(writer,field.GetValue(this));
                    writer.WriteEndElement();
                }
                else
                {
                    xml = new XmlSerializer(field.FieldType,new XmlRootAttribute(field.Name));
                    xml.Serialize(writer,field.GetValue(this));
                }
            }
        }


        public QA()
        {
        }
    }
}
