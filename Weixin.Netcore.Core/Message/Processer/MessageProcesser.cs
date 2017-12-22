﻿using Weixin.Netcore.Core.Exceptions;
using Weixin.Netcore.Core.Message.Handler;
using Weixin.Netcore.Core.MessageRepet;
using Weixin.Netcore.Model.WeixinMessage;

namespace Weixin.Netcore.Core.Message.Processer
{
    /// <summary>
    /// 消息处理器
    /// </summary>
    public class MessageProcesser : IMessageProcesser
    {
        private readonly IMessageRepetHandler _messageRepetHandler;
        private readonly IMessageRepetValidUsage _messageRepetValidUsage;
        private readonly TextMessageHandlerBase _textMessageHandler;
        private readonly ImageMessageHandlerBase _imageMessageHandler;
        private readonly VoiceMessageHandlerBase _voiceMessageHandlder;
        private readonly VideoMessageHandlerBase _videoMessageHandler;
        private readonly ShortVideoMessageHandlerBase _shortVideoMeessageHandler;
        private readonly LocationMessageHandlerBase _locationMessageHandler;
        private readonly LinkMessageHandlerBase _linkMessageHandlder;
        private readonly SubscribeEvtMessageHandlerBase _subscribeEventHandler;
        private readonly UnsubscribeEvtMessageHandlerBase _unsubscribeEventHandler;
        private readonly ScanEvtMessageHandlerBase _scanEventHandler;
        private readonly LocationEvtMessageHandlerBase _locationEventHandler;
        private readonly ClickEvtMessageHandlerBase _clickEventHandler;

        public MessageProcesser(IMessageRepetHandler messageRepetHandler,
            IMessageRepetValidUsage messageRepetValidUsage,
            TextMessageHandlerBase textMessageHandler, ImageMessageHandlerBase imageMessageHandler,
            VoiceMessageHandlerBase voiceMessageHandler, VideoMessageHandlerBase videoMessageHandler,
            ShortVideoMessageHandlerBase shortVideoMessageHandler, LocationMessageHandlerBase locationMessageHandler,
            LinkMessageHandlerBase linkMessageHandler, SubscribeEvtMessageHandlerBase subscribeEventHandler,
            UnsubscribeEvtMessageHandlerBase unsubscribeEventHandler, ScanEvtMessageHandlerBase scanEventHandler,
            LocationEvtMessageHandlerBase locationEventHandler, ClickEvtMessageHandlerBase clickEventHandler)
        {
            _messageRepetHandler = messageRepetHandler;
            _messageRepetValidUsage = messageRepetValidUsage;
            _textMessageHandler = textMessageHandler;
            _imageMessageHandler = imageMessageHandler;
            _voiceMessageHandlder = voiceMessageHandler;
            _videoMessageHandler = videoMessageHandler;
            _shortVideoMeessageHandler = shortVideoMessageHandler;
            _locationMessageHandler = locationMessageHandler;
            _linkMessageHandlder = linkMessageHandler;
            _subscribeEventHandler = subscribeEventHandler;
            _unsubscribeEventHandler = unsubscribeEventHandler;
            _scanEventHandler = scanEventHandler;
            _locationEventHandler = locationEventHandler;
            _clickEventHandler = clickEventHandler;
        }

        public string ProcessMessage(IMessage message)
        {
            if(message is TextMessage)//文本消息
            {
                if (_messageRepetValidUsage.IsRepetValidUse && !_messageRepetHandler.MessageRepetValid((message as TextMessage).MsgId.ToString()))
                    return "success";
                return _textMessageHandler.TextMessageHandler(message as TextMessage);
            }
            else if(message is ImageMessage)//图片消息
            {
                if (_messageRepetValidUsage.IsRepetValidUse && !_messageRepetHandler.MessageRepetValid((message as ImageMessage).MsgId.ToString()))
                    return "success";
                return _imageMessageHandler.ImageMessageHandler(message as ImageMessage);
            }
            else if(message is VoiceMessage)//语音消息
            {
                if (_messageRepetValidUsage.IsRepetValidUse && !_messageRepetHandler.MessageRepetValid((message as VoiceMessage).MsgId.ToString()))
                    return "success";
                return _voiceMessageHandlder.VoiceMessageHandler(message as VoiceMessage);
            }
            else if(message is VideoMessage)//视频消息
            {
                if (_messageRepetValidUsage.IsRepetValidUse && !_messageRepetHandler.MessageRepetValid((message as VideoMessage).MsgId.ToString()))
                    return "success";
                return _videoMessageHandler.VideoMessageHandler(message as VideoMessage);
            }
            else if(message is ShortVideoMessage)//小视频消息
            {
                if (_messageRepetValidUsage.IsRepetValidUse && !_messageRepetHandler.MessageRepetValid((message as ShortVideoMessage).MsgId.ToString()))
                    return "success";
                return _shortVideoMeessageHandler.ShortVideoMessageHandler(message as ShortVideoMessage);
            }
            else if(message is LocationMessage)//位置消息
            {
                if (_messageRepetValidUsage.IsRepetValidUse && !_messageRepetHandler.MessageRepetValid((message as LocationMessage).MsgId.ToString()))
                    return "success";
                return _locationMessageHandler.LocationMessageHandler(message as LocationMessage);
            }
            else if(message is LinkMessage)//链接消息
            {
                if (_messageRepetValidUsage.IsRepetValidUse && !_messageRepetHandler.MessageRepetValid((message as LinkMessage).MsgId.ToString()))
                    return "success";
                return _linkMessageHandlder.LinkMessageHandler(message as LinkMessage);
            }
            else if(message is SubscribeEvtMessage)//订阅事件消息
            {
                if (_messageRepetValidUsage.IsRepetValidUse && !_messageRepetHandler.MessageRepetValid((message as SubscribeEvtMessage).FromUserName + (message as SubscribeEvtMessage).CreateTime))
                    return "success";
                return _subscribeEventHandler.SubscribeEventHandler(message as SubscribeEvtMessage);
            }
            else if(message is UnSubscribeEvtMessage)//取消订阅事件消息
            {
                if (_messageRepetValidUsage.IsRepetValidUse && !_messageRepetHandler.MessageRepetValid((message as UnSubscribeEvtMessage).FromUserName + (message as UnSubscribeEvtMessage).CreateTime))
                    return "success";
                return _unsubscribeEventHandler.UnsubscribeEventHandler(message as UnSubscribeEvtMessage);
            }
            else if(message is ScanEvtMessage)//扫码事件消息
            {
                if (_messageRepetValidUsage.IsRepetValidUse && !_messageRepetHandler.MessageRepetValid((message as ScanEvtMessage).FromUserName + (message as ScanEvtMessage).CreateTime))
                    return "success";
                return _scanEventHandler.ScanEventHandler(message as ScanEvtMessage);
            }
            else if(message is LocationEvtMessage)//位置上报事件消息
            {
                if (_messageRepetValidUsage.IsRepetValidUse && !_messageRepetHandler.MessageRepetValid((message as LocationEvtMessage).FromUserName + (message as LocationEvtMessage).CreateTime))
                    return "success";
                return _locationEventHandler.LocationEventHandler(message as LocationEvtMessage);
            }
            else if(message is ClickEvtMessage)//点击事件消息
            {
                if (_messageRepetValidUsage.IsRepetValidUse && !_messageRepetHandler.MessageRepetValid((message as ClickEvtMessage).FromUserName + (message as ClickEvtMessage).CreateTime))
                    return "success";
                return _clickEventHandler.ClickEventHandler(message as ClickEvtMessage);
            }
            else
            {
                throw new MessageNotSupportException("不支持的消息类型");
            }
        }
    }
}
