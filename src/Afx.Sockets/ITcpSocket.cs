using Afx.Sockets.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Afx.Sockets
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITcpSocket : IDisposable
    {
        /// <summary>
        /// 用户定义的对象
        /// </summary>
        object UserState { get; set; }

        /// <summary>
        /// 是否连接
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// socket Handle，未调用Connect之前值为IntPtr.Zero
        /// </summary>
        IntPtr Handle { get; }

        /// <summary>
        /// LocalEndPoint
        /// </summary>
        EndPoint LocalEndPoint { get;  }

        /// <summary>
        /// RemoteEndPoint
        /// </summary>
        EndPoint RemoteEndPoint { get;  }

        /// <summary>
        /// SendTimeout（毫秒）
        /// </summary>
        int SendTimeout { get; }

        /// <summary>
        /// ReceiveTimeout（毫秒）
        /// </summary>
        int ReceiveTimeout { get; }

        /// <summary>
        /// Socket
        /// </summary>
        Socket Socket { get; }

        //private bool exclusiveAddressUse = true;

        ///// <summary>
        ///// 指定 Socket 是否仅允许一个进程绑定到端口
        ///// </summary>
        //public bool ExclusiveAddressUse
        //{
        //    get
        //    {
        //        return this.exclusiveAddressUse;
        //    }
        //    set
        //    {
        //        this.exclusiveAddressUse = value;
        //        if (this.socket != null)
        //            this.socket.ExclusiveAddressUse = value;
        //    }
        //}

        /// <summary>
        /// 是否释放
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// SendBufferSize 
        /// </summary>
        int SendBufferSize { get; }

        /// <summary>
        /// ReceiveBufferSize
        /// </summary>
        int ReceiveBufferSize { get; }

        /// <summary>
        /// 连接服务端
        /// </summary>
        /// <param name="host">服务端ip或域名</param>
        /// <param name="port">服务端端口</param>
        /// <param name="millisecondsTimeout">（毫秒）</param>
        bool Connect(string host, int port, int millisecondsTimeout = 0);


        /// <summary>
        /// KeepAlive
        /// </summary>
        /// <param name="keepAliveTime">连接多长时间（毫秒）没有数据就开始发送心跳包，有数据传递的时候不发送心跳包</param>
        /// <param name="keepAliveInterval">每隔多长时间（毫秒）发送一个心跳包，发5次（系统默认值）</param>
        /// <returns>The number of bytes in the optionOutValue parameter.</returns>
        int SetKeepAlive(int keepAliveTime, int keepAliveInterval);

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data">数据</param>
        bool Send(byte[] data);

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <returns></returns>
        byte[] Receive();

        /// <summary>
        /// 关闭连接
        /// </summary>
        void Close();
    }
}
