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

namespace SweetPotato.MetaInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The info dictionnary of the Bit Torrent protocol.
    /// </summary>
    public class InfoDictionnary
    {
        /// <summary>
        /// Create a new instance of the InfoDictionnary.
        /// </summary>
        public InfoDictionnary()
        {
            this.Pieces = new List<string>();
            this.Files = new List<Tuple<string, long>>();
        }

        /// <summary>
        /// The name of the suggested file or folder to use.
        /// </summary>
        public string Name { get; set;}

        /// <summary>
        /// The piece length in bytes.
        /// </summary>
        public long PieceLengthInBytes { get; set; }

        /// <summary>
        /// The list of piece (a 20 char string)
        /// It should be sha1 hash.
        /// </summary>
        public List<string> Pieces { get; private set; }

        /// <summary>
        /// The list of files and their size in bytes.
        /// </summary>
        public List<Tuple<string, long>> Files { get; private set; }
    }
}
