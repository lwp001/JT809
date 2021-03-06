﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using JT809.Protocol.SubMessageBody;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1200_0x1201Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = new JT809_0x1200_0x1201
            {
                 PlateformId= "1111111111",
                 ProducerId= "1111111111",
                 TerminalId= "11111AA",
                 TerminalModelType= "11111111",
                 TerminalSimCode= "222222222222"
            };
            var hex = JT809Serializer.Serialize(jT809_0X1200_0X1201).ToHexString();
            //"00 00 00 00 00 00 00 42 3A 35 C7 00 00 00 00 00 00 00 42 3A 35 C7 31 31 31 31 31 31 31 31 00 00 00 00 00 00 00 00 00 00 00 00 31 31 31 31 31 41 41 32 32 32 32 32 32 32 32 32 32 32 32"
            Assert.Equal("00000000000000423A35C700000000000000423A35C7313131313131313100000000000000000000000031313131314141323232323232323232323232",hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 00 00 00 00 00 42 3A 35 C7 00 00 00 00 00 00 00 42 3A 35 C7 31 31 31 31 31 31 31 31 00 00 00 00 00 00 00 00 00 00 00 00 31 31 31 31 31 41 41 32 32 32 32 32 32 32 32 32 32 32 32".ToHexBytes();
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = JT809Serializer.Deserialize<JT809_0x1200_0x1201>(bytes);
            Assert.Equal("1111111111", jT809_0X1200_0X1201.PlateformId);
            Assert.Equal("1111111111", jT809_0X1200_0X1201.ProducerId);
            Assert.Equal("11111AA", jT809_0X1200_0X1201.TerminalId);
            Assert.Equal("11111111", jT809_0X1200_0X1201.TerminalModelType);
            Assert.Equal("222222222222", jT809_0X1200_0X1201.TerminalSimCode);
        }
    }
}
