using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AddressBookApp
{
    class FileWriter
    {
        public static string path = @"C:\Users\NKS\Desktop\CSharp Git problems\CompleteAddressBookCsharp\AddressBookFile.txt";
        public static void WriteUsingStreamWriter(List<ContactPerson> data)
        {
            
            if (File.Exists(path))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    foreach (ContactPerson contacts in data)
                    {
                        streamWriter.WriteLine(contacts.firstName+"\t"+contacts.lastName+"\t"+contacts.address+"\t"+contacts.state+"\t"+contacts.contact+"\t"+contacts.zip);
                    }
                    streamWriter.Close();
                }      
            }
            else
            {
                Console.WriteLine("No file");
            }
        }
    }
}
