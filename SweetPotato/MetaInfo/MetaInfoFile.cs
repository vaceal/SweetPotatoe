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

    /// <summary>
    /// This Class represent the MetaInfo file from
    /// the bit Torrent Protocol Specification.
    /// </summary>
    public class MetaInfoFile
    {
        /// <summary>
        /// The filename
        /// </summary>
        private string filename;

        /// <summary>
        /// The tracker Url
        /// </summary>
        private List<string> trackersUrl;

        /// <summary>
        /// The info dictionnary from the Bit Torrent
        /// protocol.
        /// </summary>
        private InfoDictionnary info;

        public MetaInfoFile(string filename, List<string> trackersUrl) : this(filename)
        {
            if (trackersUrl == null || trackersUrl.Count == 0)
            {
                throw new ArgumentException("The list of tracker must not be null or emtpy");
            }

            this.trackersUrl = trackersUrl;
        }

        /// <summary>
        /// Create a new instance of a metainfo file.
        /// </summary>
        /// <param name="filename">The filename</param>
        public MetaInfoFile(string filename)
        { 
            if(string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentException("The filename cannot be null or empty");
            }

            this.filename = filename;
            this.info = new InfoDictionnary();
        }

        /// <summary>
        /// Gets the filename.
        /// </summary>
        public string Filename 
        {
            get
            {
                return this.filename;
            }
        }

        /// <summary>
        /// Create the metainfoFile with the content of 
        /// the path specified.  This will actuall write the 
        /// file on disk.
        /// 
        /// If specified a file, only the file will be encode.
        /// If specified a folder, the entire folder and its subfolder
        /// will be encode.
        /// </summary>
        /// <param name="pathToEncode">The path or filename to encode.</param>
        public void Encode(string pathToEncode)
        { 
        }

        /// <summary>
        /// Decode (read) the metainfofile to retrieve
        /// its data.
        /// </summary>
        public void Decode()
        {
        }
    }
}
