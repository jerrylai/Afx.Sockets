using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Afx.Sockets.Models
{
    /// <summary>
    /// Receive ReadBuffer
    /// </summary>
    public class ReadBuffer
    {
        /// <summary>
        /// 缓存大小
        /// </summary>
        public int MaxSize { get; private set; }
        /// <summary>
        /// 成功读取数量
        /// </summary>
        public int ReadCount { get; private set; }
        /// <summary>
        /// 缓存
        /// </summary>
        public byte[] Data { get; private set; }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="max_size">缓存大小</param>
        public ReadBuffer(int max_size = 8 * 1024)
        {
            if (max_size <= 0) throw new ArgumentException("size is error!");
            this.ReadCount = 0;
            this.MaxSize = max_size < 16 ? 16 : (max_size > 8 * 1024 ? 8 * 1024 : max_size);
            this.Data = new byte[this.MaxSize];
        }

        /// <summary>
        /// 清除读取数据
        /// </summary>
        public void Clear()
        {
            this.ReadCount = 0;
        }

        public int AddRead(int count)
        {
            var len = this.ReadCount + count;
            if (len > this.MaxSize) throw new InvalidOperationException("count + ReadCount > Size!");

            this.ReadCount = len;

            return this.ReadCount;
        }
    }
}
