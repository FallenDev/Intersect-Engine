﻿
using System;

using Intersect.Network.Packets.Client;
using Intersect.Network.Packets.Server;
using Intersect.Time;

using MessagePack;

namespace Intersect.Network.Packets
{
    [MessagePackObject]
    [Union(0, typeof(AttackPacket))]
    [Union(1, typeof(MovePacket))]
    [Union(2, typeof(Client.PingPacket))]
    [Union(3, typeof(EntityAttackPacket))]
    [Union(4, typeof(EntityPositionPacket))]
    [Union(5, typeof(JoinGamePacket))]
    [Union(6, typeof(Server.PingPacket))]
    public abstract class AbstractTimedPacket : IntersectPacket
    {
        protected AbstractTimedPacket()
        {
            UpdateTiming();
        }

        public void UpdateTiming()
        {
            Adjusted = Timing.Global.Ticks;
            Offset = Timing.Global.TicksOffset;
            UTC = Timing.Global.TicksUtc;
        }

        [Key(0)]
        public long Adjusted { get; set; }

        [Key(1)]
        public long UTC { get; set; }

        [Key(2)]
        public long Offset { get; set; }
    }
}
