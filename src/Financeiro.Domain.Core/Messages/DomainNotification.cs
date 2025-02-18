﻿using MediatR;
using System;

namespace Financeiro.Domain.Core.Messages
{
    public class DomainNotification : Message, INotification
    {
        public DateTime Timestamp { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {
            Timestamp = DateTime.Now;
            Key = key;
            Value = value;
        }
    }
}
