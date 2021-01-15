/*****************************************************************
 * Copyright (C) Knights Warrior Corporation. All rights reserved.
 * 
 * Author:    •µÓ∆Ô ø£®Knights Warrior£© 
 * Email:    KnightsWarrior@msn.com
 * Website:  http://www.cnblogs.com/KnightsWarrior/       http://knightswarrior.blog.51cto.com/
 * Create Date:  5/8/2010 
 * Usage:
 *
 * RevisionHistory
 * Date         Author               Description
 * 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace KnightsWarriorAutoupdater
{
    public class Config
    {
        #region The private fields
        private bool enabled = true;
        private string serverUrl = string.Empty;
        private UpdateFileList updateFileList = new UpdateFileList();
        #endregion

        #region The public property
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        public string ServerUrl
        {
            get { return serverUrl; }
            set { serverUrl = value; }
        }
        public UpdateFileList UpdateFileList
        {
            get { return updateFileList; }
            set { updateFileList = value; }
        }
        #endregion

        #region The public method
        public static Config LoadConfig(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            StreamReader sr = new StreamReader(file);
            Config config = xs.Deserialize(sr) as Config;
            sr.Close();

            return config;
        }

        public void SaveConfig(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            StreamWriter sw = new StreamWriter(file);
            xs.Serialize(sw, this);
            sw.Close();

            
            //XmlDocument xml = new XmlDocument();
            //xml.Load(System.AppDomain.CurrentDomain.BaseDirectory + '\\' + "AutoUpdater.config");
           
            //XmlElement UpdateFileListEle = xml.GetElementById("UpdateFileList");
            //XmlElement LocalFileEle = xml.CreateElement("LocalFile");
            //LocalFileEle.SetAttribute("path", "Query.exe");
            //LocalFileEle.SetAttribute("lastver", "1.0.0.0");
            //LocalFileEle.SetAttribute("size", "100");
            //UpdateFileListEle.AppendChild(LocalFileEle);
            //xml.Save(System.AppDomain.CurrentDomain.BaseDirectory + '\\' + "AutoUpdater.config");
        }
        #endregion
    }

}
