﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace AppUtil.Common
{
    public class XMLSerilize
    {
        #region 获取XML的序列化和反序列化

        /// <summary>
        /// 对象进行序列化生成XML
        /// </summary>
        /// <typeparam name="T">需要序列化的对象类型</typeparam>
        /// <param name="obj">需要序列化的对象</param>
        /// <returns>序列化后的XML</returns>
        public static string SerilizeObject<T>(T obj)
        {
            if (obj == null)
            {
                return "";
            }

            string ret = "";

            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    ret = "";
                    System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(T));

                    XmlWriterSettings s = new XmlWriterSettings();
                    s.Encoding = Encoding.UTF8;
                    s.OmitXmlDeclaration = true;
                    //s.NamespaceHandling = NamespaceHandling.OmitDuplicates;
                    //s.Indent = true;

                    using (XmlWriter binaryWriter = XmlWriter.Create(stream, s))
                    {
                        System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
                        ns.Add("", "");
                        serializer.Serialize(binaryWriter, obj, ns);

                        binaryWriter.Flush();
                    }
                    ret = Encoding.UTF8.GetString(stream.ToArray());

                }
                catch (Exception ex)
                {
                    Console.WriteLine("SerilizeAnObject Exception: {0}", ex.Message);
                }
                finally
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
            return ret;
        }

        /// <summary>
        /// XML反序列化生成对象
        /// </summary>
        /// <typeparam name="T">反序列化生成对象类型</typeparam>
        /// <param name="xml">XML内容</param>
        /// <returns>反序列化生成对象</returns>
        public static T DeserilizeObject<T>(string xml)
        {
            Type type = typeof(T);
            T obj = default(T);
            if (string.IsNullOrEmpty(xml))
            {
                return obj;
            }
            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(xml);
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Position = 0L;
                    System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(type);
                    using (System.Xml.XmlReader reader = new XmlTextReader(stream))
                    {
                        obj = (T)serializer.Deserialize(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("DeserilizeAnObject Exception: {0}", ex.Message);
                }
                finally
                {
                    stream.Close();
                    stream.Dispose();
                }
            }

            return obj;
        }
        #endregion


    }
}
