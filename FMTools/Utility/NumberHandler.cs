﻿using System;
using System.Collections.Generic;
using System.IO;

namespace FMTools.Utility
{
    /// <summary>
    /// Helper class for Number Operations
    /// </summary>
    public static class NumberHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static byte[] TextToArray(this string s, Dictionary<char, byte> dic)
        {
            List<byte> list = new List<byte>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (dic.ContainsKey(c))
                {
                    list.Add(dic[c]);
                }
                else if (c == '\n')
                {
                    list.Add(254);
                }
            }
            list.Add(255);
            return list.ToArray();
        }

        /// <summary>
        /// Extract as Integer32
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static int ExtractInt32(this byte[] bytes, int index = 0)
        {
            return bytes[index + 3] << 24 | bytes[index + 2] << 16 | bytes[index + 1] << 8 | bytes[index + 0];
        }

        /// <summary>
        /// Extract a piece from the FileStream
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="changeOffset"></param>
        /// <returns>Buffer</returns>
        public static byte[] ExtractPiece(this FileStream ms, int offset, int length, int changeOffset = -1)
        {
            if (changeOffset > -1)
            {
                ms.Position = changeOffset;
            }

            byte[] buffer = new byte[length];
            ms.Read(buffer, offset, length);
            return buffer;
        }

        /// <summary>
        /// Extract a piece from the MemoryStream
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="changeOffset"></param>
        /// <returns></returns>
        public static byte[] ExtractPiece(this MemoryStream ms, int offset, int length, int changeOffset = -1)
        {
            if (changeOffset > -1)
            {
                ms.Position = changeOffset;
            }

            byte[] buffer = new byte[length];
            ms.Read(buffer, 0, length);
            return buffer;
        }

        public static byte ReadNextByte(this MemoryStream ms)
        {
            var read = ms.ReadByte();
            if (read == -1) throw new EndOfStreamException();
            return (byte)read;
        }

        /// <summary>
        /// Save to File
        /// </summary>
        /// <param name="data"></param>
        /// <param name="path"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        public static void Save(this byte[] data, string path, int offset = -1, int length = -1)
        {
            int offset1 = offset > -1 ? offset : 0;
            int count = length > -1 ? length : data.Length;
            using (FileStream fileStream = File.Create(path))
            {
                fileStream.Write(data, offset1, count);
            }
        }

        /// <summary>
        /// Integer32 to Byte Array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Int32ToByteArray(this int value)
        {
            byte[] numArray = new byte[4];
            for (int index = 0; index < 4; ++index)
            {
                numArray[index] = (byte)(value >> index * 8 & byte.MaxValue);
            }

            return numArray;
        }

        /// <summary>
        /// Extract Unsigned Integer16
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static ushort ExtractUInt16(this byte[] bytes, int index = 0)
        {
            return (ushort)((uint)bytes[index + 1] << 8 | bytes[index + 0]);
        }

        /// <summary>
        /// Integer16 to Byte Array
        /// </summary>
        /// <param name="value">As unsigned short</param>
        /// <returns></returns>
        public static byte[] Int16ToByteArray(this ushort value)
        {
            return ((short)value).Int16ToByteArray();
        }

        /// <summary>
        /// Convert string to byte array, must have Length % 2 = 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(this string str)
        {
            var bytes_amt = str.Length / 2;
            var byte_arr = new byte[bytes_amt];
            var byte_ind = 0;
            for(var i = 0; i < str.Length; i += 2)
            {
                byte.TryParse(str.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out byte res);
                byte_arr[byte_ind++] = res;
            }
            return byte_arr;
        }

        /// <summary>
        /// Integer16 to Byte Array
        /// </summary>
        /// <param name="value">As short</param>
        /// <returns></returns>
        public static byte[] Int16ToByteArray(this short value)
        {
            byte[] numArray = new byte[2];
            for (int index = 0; index < 2; ++index)
            {
                numArray[index] = (byte)(value >> index * 8 & byte.MaxValue);
            }

            return numArray;
        }

        /// <summary>
        /// Copy Data from specific offset to specific offset
        /// </summary>
        /// <param name="self"></param>
        /// <param name="data"></param>
        /// <param name="copyOffset"></param>
        /// <param name="length"></param>
        /// <param name="destinyOffset"></param>
        /// <returns></returns>
        public static byte[] CopyFrom(this byte[] self, byte[] data, int copyOffset, int length, int destinyOffset = 0)
        {
            for (int index = copyOffset; index < length; ++index)
            {
                self[destinyOffset + (index - copyOffset)] = data[index];
            }

            return self;

        }

        /// <summary>
        /// Read integer from memory stream
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="changePos"></param>
        /// <param name="newPos"></param>
        /// <returns></returns>
        public static int ReadInt32(this MemoryStream ms, bool changePos = false, int newPos = 0)
        {
            if (changePos) ms.Position = newPos;

            byte[] bytes = new byte[4];
            bytes[3] = (byte)ms.ReadByte();
            bytes[2] = (byte)ms.ReadByte();
            bytes[1] = (byte)ms.ReadByte();
            bytes[0] = (byte)ms.ReadByte();
            return bytes.ExtractInt32();
        }

        /// <summary>
        /// Extract Text from the Data and translate it to human readable text using the Character Dictionary
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static String GetText(this MemoryStream ms, Dictionary<byte, char> dic)
        {
            string text = string.Empty;

            while (true)
            {
                byte b = ms.ExtractPiece(0, 1)[0];

                if (dic.ContainsKey(b))
                {
                    text += dic[b].ToString();
                }
                else if (b == 254)
                {
                    text += "\r\n";
                }
                else
                {
                    if (b == 255)
                    {
                        break;
                    }

                    text = text + "[" + b.ToString("X2") + "]";
                }
            }
            return text;
        }       
    }
}