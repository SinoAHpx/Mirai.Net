﻿using System;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Apply;
using Mirai.Net.Data.Events.Bot;
using Mirai.Net.Data.Events.Friend;
using Mirai.Net.Data.Events.Group;
using Websocket.Client;

namespace Mirai.Net.Utils.Extensions
{
    /// <summary>
    /// 消息相关拓展封装
    /// </summary>
    public static class MessageExtensions
    {
        /// <summary>
        /// 判断websocket收到的消息是不是事件消息
        /// </summary>
        /// <returns></returns>
        public static bool IsEvent(this ResponseMessage message)
        {
            var json = message.Text.ToJObject();

            if (json.Fetch("data").ToJObject().ContainsKey("session"))
            {
                return false;
            }
            
            var type = json["data"].Fetch("type");

            return type.ToLower().Contains("event");
        }
        
        /// <summary>
        /// 根据传进来json，解析为EventArgsBase的type，再转换成具体的EventArgs
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static EventArgsBase ConvertToConcrete(this string data)
        {
            var args = data.ToEntity<EventArgsBase>();
            return args.Type switch
            {
                EventType.BotOnlineEvent => data.ToEntity<BotEventArgs>(),
                EventType.BotOfflineEventActive => data.ToEntity<BotEventArgs>(),
                EventType.BotOfflineEventForce => data.ToEntity<BotEventArgs>(),
                EventType.BotOfflineEventDropped => data.ToEntity<BotEventArgs>(),
                EventType.BotReloginEvent => data.ToEntity<BotEventArgs>(),
                EventType.FriendInputStatusChangedEvent => data.ToEntity<FriendInputStatusChangedEventArgs>(),
                EventType.FriendNickChangedEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.BotGroupPermissionChangeEvent => data.ToEntity<BotGroupPermissionChangeEventArgs>(),
                EventType.BotMuteEvent => data.ToEntity<BotMuteEventArgs>(),
                EventType.BotUnmuteEvent => data.ToEntity<BotUnmuteEventArgs>(),
                EventType.BotJoinGroupEvent => data.ToEntity<BotJoinGroupEventArgs>(),
                EventType.BotLeaveEventActive => data.ToEntity<BotLeaveGroupEventArgs>(),
                EventType.BotLeaveEventKick => data.ToEntity<BotLeaveGroupKickEventArgs>(),
                EventType.GroupRecallEvent => data.ToEntity<GroupRecallEventArgs>(),
                EventType.FriendRecallEvent => data.ToEntity<FriendRecallEventArgs>(),
                EventType.GroupNameChangeEvent => data.ToEntity<GroupNameChangeEventArgs>(),
                EventType.GroupEntranceAnnouncementChangeEvent => data.ToEntity<GroupEntranceAnnouncementChangeEventArgs>(),
                EventType.GroupMuteAllEvent => data.ToEntity<GroupMuteAllEventArgs>(),
                EventType.GroupAllowAnonymousChatEvent => data.ToEntity<GroupAllowAnonymousChatEventArgs>(),
                EventType.GroupAllowConfessTalkEvent => data.ToEntity<GroupAllowConfessTalkEventArgs>(),
                EventType.GroupAllowMemberInviteEvent => data.ToEntity<GroupAllowMemberInviteEventArgs>(),
                EventType.MemberJoinEvent => data.ToEntity<MemberJoinEventArgs>(),
                EventType.MemberLeaveEventKick => data.ToEntity<MemberLeaveEventKickArgs>(),
                EventType.MemberLeaveEventQuit => data.ToEntity<MemberLeaveEventQuitArgs>(),
                EventType.MemberCardChangeEvent => data.ToEntity<MemberCardChangeEventArgs>(),
                EventType.MemberSpecialTitleChangeEvent => data.ToEntity<MemberSpecialTitleChangeEventArgs>(),
                EventType.MemberPermissionChangeEvent => data.ToEntity<MemberPermissionChangeEventArgs>(),
                EventType.MemberMuteEvent => data.ToEntity<MemberMuteEventArgs>(),
                EventType.MemberUnmuteEvent => data.ToEntity<BotUnmuteEventArgs>(),
                EventType.MemberHonorChangeEvent => data.ToEntity<MemberHonorChangeEventArgs>(),
                EventType.NewFriendRequestEvent => data.ToEntity<NewFriendRequestEventArgs>(),
                EventType.MemberJoinRequestEvent => data.ToEntity<MemberJoinEventArgs>(),
                EventType.BotInvitedJoinGroupRequestEvent => data.ToEntity<BotInvitedJoinGroupRequestEvent>(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}