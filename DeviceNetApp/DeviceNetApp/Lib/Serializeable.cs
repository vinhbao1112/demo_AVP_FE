using System.Xml.Serialization;
using System.IO;
using System;

namespace DeviceNetApp.Lib
{
    /**<author>
       *  <name> Pham Trung Tin </name>
       *  <date> 2012-08-17</date>
       * </author>
       * <summary>
       *  This class implement the serialize functions to load/save from xml
       * </summary>*/
    public class Serializeable
    {
        public static String strMessageError = String.Empty;
        /**<author>
         *  <name> Pham Trung Tin </name>
         *  <date> 2012-08-17</date>
         * </author>
         * <summary>
         *  Construtor
         * </summary>
         * <remarks></remarks>*/
        public Serializeable()
        { }

        /**<author>
         *  <name> Pham Trung Tin </name>
         *  <date> 2012-08-17</date>
         * </author>
         * <summary>
         *  This function is used to store the data to file from an object Gui
         * </summary>
         * <remarks></remarks>*/
        public Boolean Serialize(string strFullFilePath)
        {
            Boolean bResult = true;
            try
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                Stream stream = File.Open(strFullFilePath, FileMode.Create);
                try
                {
                    serializer.Serialize(stream, this);
                }
                catch (Exception ex)
                {
                    Logger.LogHandler.Error(ex.ToString());
                    bResult = false;
                }
                stream.Close();
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.ToString());
                bResult = false;
            }
            return bResult;
        }

        /**<author>
         *  <name> Pham Trung Tin </name>
         *  <date> 2012-08-17</date>
         * </author>
         * <summary>
         *  This function is used to restore the data that saved to file to an object
         * </summary>
         * <remarks></remarks>*/
        public static Object DeSerialize(String strFullFilePath, Type type)
        {
            Object dataObject = null;
            strMessageError = String.Empty;
            try
            {
                XmlSerializer serializer = new XmlSerializer(type);
                serializer.UnknownNode += UnknownNode;
                FileStream fileStream = new FileStream(strFullFilePath, FileMode.Open);
                try
                {
                    dataObject = serializer.Deserialize(fileStream);
                }
                catch (Exception ex)
                {
                    Logger.LogHandler.Error(ex.ToString());
                }
                serializer.UnknownNode -= UnknownNode;
                fileStream.Close();
            }
            catch (Exception ex)
            {
                dataObject = null;
                Logger.LogHandler.Error(ex.ToString());
            }
            return dataObject;
        }

        /**<author>
         *  <name> Pham Trung Tin </name>
         *  <date> 2013-07-29</date>
         * </author>
         * <summary>
         *  This event is raised for any attribute or element that does not match the class of the object being created
         * </summary>
         * <remarks></remarks>*/
        private static void UnknownNode(object sender, XmlNodeEventArgs e)
        {
            strMessageError = String.Format("Unexpected node: {0} as line {1}", e.LocalName, e.LineNumber - 1);
        }
    }
}