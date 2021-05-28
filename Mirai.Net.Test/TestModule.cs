﻿using System.Runtime.InteropServices;
using Mirai.Net.Data;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concrete;
using Mirai.Net.Messengers.Concrete;
using Mirai.Net.Modules;

namespace Mirai.Net.Test
{
    public class TestModule : IModule
    {
        public async void Execute(MessageReceivedArgs args)
        {
            if (args.Type == MessageReceivedArgs.MessageType.GroupMessage)
            {
                var messenger = new GroupMessenger("110838222");

                if (args.Sender.PermissionType == MemberPermissionType.Administrator)
                {
                    await messenger.Send(new PlainMessage($"Hello, {args.Sender.Id}"));
                }
                
            }   
        }
    }
}