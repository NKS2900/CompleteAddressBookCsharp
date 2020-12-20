using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AddressBookApp
{
    class FileWriter
    {
        public static string path = @"C:\Users\NKS\Desktop\CSharp Git problems\CompleteAddressBookCsharp\AddressBookFile.txt";
        public static string csvPath= @"C:\Users\NKS\Desktop\CSharp Git problems\CompleteAddressBookCsharp\CSV_AddressBook.csv";

        /// <summary>
        /// write Contacts in TextFile.
        /// </summary>
        /// <param name="data"></param>
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
                    Console.WriteLine("Contacts Stored in TextFile.");
                }
            }
            else
            {
                Console.WriteLine("File not avilable..");
            }
        }

        /// <summary>
        /// ReadContacts From Text File.
        /// </summary>
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

        /// <summary>
        /// Write Conatacts in CSV File
        /// </summary>
        /// <param name="data"></param>
        public static void csvFileWriter(List<ContactPerson> dataa)
        {

            if (File.Exists(csvPath))
            {
                File.WriteAllText(csvPath, String.Empty);
                using (StreamWriter streamWriter = File.AppendText(csvPath))
                {
                    streamWriter.WriteLine("FName,LName,City,State,Contact,Zip");
                    foreach (ContactPerson contacts in dataa)
                    {
                        streamWriter.WriteLine(contacts.firstName + "," + contacts.lastName + "," + contacts.address + "," + contacts.state + "," + contacts.contact + "," + contacts.zip);
                    }
                    streamWriter.Close();
                    Console.WriteLine("Contacts Stored in Csv_File.");
                }
            }
            else
            {
                Console.WriteLine("File not avilable..");
            }
        }

        /// <summary>
        /// Read Contacts From CSV file.
        /// </summary>
        public static void readFromCSVFile()
        {
            if (File.Exists(csvPath))
            {
                using (StreamReader streamReader = File.OpenText(csvPath))
                {
                    string data = "";
                    while ((data = streamReader.ReadLine()) != null)
                    {
                        string[] csv = data.Split(",");
                        foreach (string dataCsv in csv)
                        {
                            Console.Write(dataCsv + " ");
                        }
                        Console.WriteLine();
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
