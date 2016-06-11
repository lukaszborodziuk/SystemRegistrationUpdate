using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using System.Windows;

namespace SystemRegistration
{
    class SaveData
    {
        public void DataToSave(object obj, string filename)
        {
            XmlSerializer s = new XmlSerializer(obj.GetType());
            using (TextWriter writer = new StreamWriter(filename))
            {
                s.Serialize(writer, obj);
            }
        }

        
        
    }
}
