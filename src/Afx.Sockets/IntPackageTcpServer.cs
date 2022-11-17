using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;

namespace Afx.Sockets
{
    /// <summary>
    /// IntPackageTcpServer
    /// </summary>
    public sealed class IntPackageTcpServer : TcpServer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="sendBufferSize"></param>
        /// <param name="receiveBufferSize"></param>
        /// <returns></returns>
        protected override AsyncTcpSocket Accept(Socket client, int sendBufferSize, int receiveBufferSize)
        {
            return new IntPackageAsyncTcpSocket(client, sendBufferSize, receiveBufferSize);
        }
    }
}
