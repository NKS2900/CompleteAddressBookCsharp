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
                File.WriteAllText(path, String.Empty);
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine("FName\tLName\tCity\tState\tContact\tZip");
                    foreach (ContactPerson contacts in data)
                    {
                        streamWriter.WriteLine(contacts.firstName + "\t" + contacts.lastName + "\t" + contacts.address + "\t" + contacts.state + "\t" + contacts.contact + "\t" + contacts.zip);
                    }
                    streamWriter.Close();
                }
            }
            else
            {
                Console.WriteLine("File not avilable..");
            }
        }

        public static void readFile()
        {
            if (File.Exists(path))
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    string data = "";
                    while ((data = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(data);
                    }                   
                }
            }
            else
            {
                Console.WriteLine("File not avilable..");
            }
        }
    }
}
