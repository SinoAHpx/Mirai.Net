﻿using System;
using Mirai.Net.Data.Messages.Enums;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class ImageMessage : MessageBase
    {
        public override string Type { get; set; } = "Image";
        
        [JsonProperty("imageId")]
        public string ImageId {get; set;}
        
        [JsonProperty("url")]
        public string Url {get; set;}
        
        [JsonProperty("path")]
        public string Path {get; set;}

        public ImageMessage(string param, ImageMessageType type = ImageMessageType.Url)
        {
            _ = type switch
            {
                ImageMessageType.Id => ImageId = param,
                ImageMessageType.Url => Url = param,
                ImageMessageType.Path => Path = param,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}