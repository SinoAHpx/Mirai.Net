﻿using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class PlainMessage : MessageBase
    {
        [JsonProperty("text")]
        public string Text {get; set;}
        
        public override Messages Type { get; set; } = Messages.Plain;

        public PlainMessage(string text = null)
        {
            Text = text;
        }
    }
}