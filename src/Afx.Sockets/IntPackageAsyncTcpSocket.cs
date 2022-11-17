using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Afx.Sockets.Models;
using Afx.Sockets.Utils;

namespace Afx.Sockets
{
    /// <summary>
    /// IntPackageAsyncTcpSocket
    /// </summary>
    public sealed class IntPackageAsyncTcpSocket : AsyncTcpSocket
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendBufferSize"></param>
        /// <param name="receiveBufferSize"></param>
        public IntPackageAsyncTcpSocket(int sendBufferSize = 8 * 1024, int receiveBufferSize = 8 * 1024)
            : base(sendBufferSize, receiveBufferSize)
        {

        }

        internal IntPackageAsyncTcpSocket(Socket socket, int sendBufferSize = 8 * 1024, int receiveBufferSize = 8 * 1024)
            : base(socket, sendBufferSize, receiveBufferSize)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="cache"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected override bool ReceiveData(ReadBuffer buffer, PackageModel cache, out List<byte[]> data)
        {
            data = null;
            if (cache.Size == 0 && buffer.ReadCount < SocketUtils.PREFIX_LENGTH)
            {
                return true;
            }
            else
            {
                int start = 0;
                while (start < cache.Position + buffer.ReadCount)
                {
                    int len = 0;
                    if (cache.Position > 0) len = cache.Size;
                    else
                    {
                        byte[] arrlen = new byte[SocketUtils.PREFIX_LENGTH];
                        Array.Copy(buffer.Data, start, arrlen, 0, arrlen.Length);
                        len = SocketUtils.ToPrefixLength(arrlen);
                    }

                    if (len <= 0 || len > SocketUtils.MAX_PREFIX_LENGTH) return false;

                    if (start + len <= cache.Position + buffer.ReadCount)
                    {
                        if (cache.Position > 0)
                        {
                            Array.Copy(buffer.Data, start, cache.Data, cache.Position, len - cache.Position);
                            if (data == null) data = new List<byte[]>(3);
                            data.Add(cache.Data);
                            start = len - cache.Position;
                            cache.Clear();
                        }
                        else
                        {
                            var temp = new byte[len];
                            Array.Copy(buffer.Data, start, temp, 0, temp.Length);
                            if (data == null) data = new List<byte[]>(3);
                            data.Add(temp);
                            start += len;
                        }

                        if (start == buffer.ReadCount)
                        {
                            buffer.Clear();
                        }
                    }
                    else
                    {
                        if (cache.Position == 0)
                        {
                            cache.Data = new byte[len];
                            cache.Size = len;
                        }
                        Array.Copy(buffer.Data, start, cache.Data, cache.Position, buffer.ReadCount - start);
                        cache.Position = cache.Position + buffer.ReadCount - start;
                        start = cache.Position;
                        buffer.Clear();
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override bool Send(byte[] data)
        {
            return base.Send(SocketUtils.ToSendData(data));
        }
    }
}
