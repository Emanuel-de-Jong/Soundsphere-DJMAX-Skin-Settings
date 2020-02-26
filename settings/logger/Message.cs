using System;
using System.Collections.Generic;
using System.Text;

namespace logger
{
    public class Message
    {
        public DateTime Time { get; set; }
        public eMessageType Type { get; set; }
        public string Text { get; set; }

        public Message()
        {
            Time = DateTime.UtcNow;
        }

        public Message(eMessageType type)
        {
            Type = type;
            Time = DateTime.UtcNow;
        }

        public Message(string text)
        {
            Text = text;
            Time = DateTime.UtcNow;
        }

        public Message(eMessageType type, string text)
        {
            Type = type;
            Text = text;
            Time = DateTime.UtcNow;
        }

        public override string ToString()
        {
            string typeAsText = "<<" + Type.ToString().ToUpper() + ">>";
            return Time.ToString("HH:mm:ss") + " - " + typeAsText + ": " + Text;
        }
    }
}
