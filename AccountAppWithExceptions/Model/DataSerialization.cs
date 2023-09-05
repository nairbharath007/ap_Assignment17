using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppWithExceptions.Model
{
    internal class DataSerialization
    {
        public static void BinarySerializer(string filePath, Account account) 
        {
            using (FileStream filestream = new FileStream(filePath, FileMode.OpenOrCreate, 
                FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(filestream, account);
            }
        }

        public static Account BinaryDeserializer(string filePath) 
        {
            Account account = null;
            using(FileStream filestream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                if(filestream.Length > 0)
                {
                    account = (Account) formatter.Deserialize(filestream);
                }
            }
            return account;
        }
    }
}
