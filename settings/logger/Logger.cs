using System;
using System.Collections.Generic;
using System.IO;

namespace logger
{
    public static class Logger
    {
        public static string FilePath = Directory.GetCurrentDirectory() + "\\" + "settings\\log.txt";

        public static List<Message> Messages = new List<Message>();



        public static void Add(Message message)
        {
            Messages.Add(message);
            AddToFile(message);
        }

        public static void Add(eMessageType type, string text)
        {
            Message message = new Message(type, text);
            Messages.Add(message);
            AddToFile(message);
        }



        public static void Remove(Message message)
        {
            Messages.Remove(message);
            RefreshFile();
        }

        public static void Remove(eMessageType type, string text)
        {
            Messages.Remove(new Message(type, text));
            RefreshFile();
        }



        private static void AddToFile(Message message)
        {
            using (StreamWriter outputFile = new StreamWriter(FilePath, true))
            {
                outputFile.WriteLine(message.ToString());
            }
        }



        public static void RefreshFile()
        {
            using (StreamWriter outputFile = new StreamWriter(FilePath))
            {
                if (Messages.Count == 0)
                {
                    foreach (Message message in Messages)
                        outputFile.WriteLine(message.ToString());
                }
                else
                {
                    outputFile.Write("");
                }
                
            }
        }
    }
}
