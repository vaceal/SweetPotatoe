/***********************************************************************************
 * Copyright (C) 2014 Alexandre Fournier
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy 
 * of this software and associated documentation files (the "Software"), to 
 * deal in the Software without restriction, including without limitation the 
 * rights to use, copy, modify, merge, publish, distribute, 
 * sublicense, and/or sell copies of the Software, and to permit persons to 
 * whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
 * OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
 * SOFTWARE.
 * *********************************************************************************/

namespace SweetPotato.MetaInfo.BEncode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class BEncoder
    {
        private MemoryStream encodingContent;

        public BEncoder()
        {
            this.encodingContent = new MemoryStream();
        }

        public Stream Content 
        { 
            get 
            {
                return this.encodingContent;
            }
        }

        public void EncodeString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The value cannot be null or empty");
            }

            var bencodedString = this.BEncodeString(value);
            this.WriteToBuffer(bencodedString);
        }

        public void EncodeInteger(long value)
        {
            var bencodedString = this.BEncodeLong(value);
            this.WriteToBuffer(bencodedString);
        }

        public void EncodeInfoDictionnary(InfoDictionnary info)
        {
            var buffer = new StringBuilder();
            buffer.Append("d");

            buffer.Append(string.Format("{0}{1}",this.BEncodeString("name"), this.BEncodeString(info.Name)));
            buffer.Append(string.Format("{0}{1}",this.BEncodeString("piece length"), this.BEncodeLong(info.PieceLengthInBytes)));

            var pieces = this.GetPieces(info);
            buffer.Append(string.Format("{0}{1}", this.BEncodeString("pieces"), this.BEncodeString(pieces)));

            if (info.Files == null || info.Files.Count == 0)
            {
                throw new InvalidDataException("The list of files must be greater than 0");
            }

            if (info.Files.Count == 1)
            {
                buffer.Append(string.Format("{0}{1}", this.BEncodeString("length"), this.BEncodeLong(info.Files[0].Item2)));
            }
            else 
            {
                buffer.Append(string.Format("{0}l{1}e",this.BEncodeString("files"), this.GetFiles(info)));
            }

            buffer.Append("e");
            this.WriteToBuffer(buffer.ToString());
        }

        private string GetFiles(InfoDictionnary info)
        {
            var buffer = new StringBuilder();

            foreach (var file in info.Files)
            {
                if (file.Item1 == null || string.IsNullOrWhiteSpace(file.Item1))
                {
                    throw new InvalidDataException("A file cannot be null or empty");
                }

                buffer.Append(string.Format("d{0}{1}{2}{3}e", this.BEncodeString("length"), this.BEncodeLong(file.Item2),
                    this.BEncodeString("path"), this.BEncodeString(file.Item1)));
            }

            return buffer.ToString();
        }

        private string GetPieces(InfoDictionnary info)
        {
            var pieces = new StringBuilder();
            
            foreach (var piece in info.Pieces)
            {
                if (piece == null || piece.Length != 20)
                {
                    throw new InvalidDataException("The piece must be a lenght of 20");
                }

                pieces.Append(piece);
            }

            return pieces.ToString();
        }

        private void WriteToBuffer(string value)
        {
            var bytesString = System.Text.Encoding.UTF8.GetBytes(value);
            this.encodingContent.Write(bytesString, 0, bytesString.Length);
        }

        private string BEncodeString(string value)
        {
            return string.Format("{0}:{1}", value.Length, value);
        }

        private string BEncodeLong(long value)
        {
            return string.Format("i{0}e", value);
        }
    }
}
