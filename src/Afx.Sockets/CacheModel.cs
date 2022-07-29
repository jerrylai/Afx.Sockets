using System;
using System.Collections.Generic;
using System.Text;

namespace Afx.Sockets.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CacheModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CacheModel()
        {
            this.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this.Size = 0;
            this.Position = 0;
            this.Data = null;
        }
    }
}
