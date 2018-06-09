using Android.App;
using Android.Bluetooth;
using Android.OS;
using Android.Widget;
using Java.Lang;
using Java.Util;
using System.IO;
using System.Runtime.CompilerServices;
using KekaWear.Models.Xhr.Core;

namespace KekaWear
{
    public class BluetoothService
    {
        const string App_Name = "Keka";
        public static UUID uUID { get; set; }
        BluetoothAdapter btAdapter { get; set; }
        Handler handler { get; set; }
        AcceptThread acceptThread { get; set; }
        ConnectThread connectThread { get; set; }
        ConnectedThread connectedThread { get; set; }
        ConnectionState state { get; set; }
        ConnectionState newState { get; set; }

        public BluetoothService(Handler handler)
        {
            btAdapter = BluetoothAdapter.DefaultAdapter;
            state = ConnectionState.None;
            newState = state;
            this.handler = handler;
            uUID = UUID.FromString("fa87c0d0-afac-11de-8a39-0800200c9a66");
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        void UpdateUserInterfaceTitle()
        {
            state = GetState();
            newState = state;
            handler.ObtainMessage((int)BluetoothState.Change, (int)newState, -1).SendToTarget();
        }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public ConnectionState GetState()
        {
            return state;
        }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Start()
        {
            if (connectThread != null)
            {
                connectThread.Cancel();
                connectThread = null;
            }

            if (connectedThread != null)
            {
                connectedThread.Cancel();
                connectedThread = null;
            }

            if (acceptThread == null)
            {
                acceptThread = new AcceptThread(this);
                acceptThread.Start();
            }

            UpdateUserInterfaceTitle();
        }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Connect(BluetoothDevice device)
        {
            if (state == ConnectionState.Connecting)
            {
                if (connectThread != null)
                {
                    connectThread.Cancel();
                    connectThread = null;
                }
            }
            
            if (connectedThread != null)
            {
                connectedThread.Cancel();
                connectedThread = null;
            }
            
            connectThread = new ConnectThread(device, this);
            connectThread.Start();

            UpdateUserInterfaceTitle();
        }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Connected(BluetoothSocket socket, BluetoothDevice device)
        {
            if (connectThread != null)
            {
                connectThread.Cancel();
                connectThread = null;
            }

            if (connectedThread != null)
            {
                connectedThread.Cancel();
                connectedThread = null;
            }


            if (acceptThread != null)
            {
                acceptThread.Cancel();
                acceptThread = null;
            }
            
            connectedThread = new ConnectedThread(socket, this);
            connectedThread.Start();
            
            var msg = handler.ObtainMessage((int)BluetoothState.DeviceName);
            Bundle bundle = new Bundle();
            bundle.PutString("DeviceName", device.Name);
            msg.Data = bundle;
            handler.SendMessage(msg);

            UpdateUserInterfaceTitle();
        }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Stop()
        {
            if (connectThread != null)
            {
                connectThread.Cancel();
                connectThread = null;
            }

            if (connectedThread != null)
            {
                connectedThread.Cancel();
                connectedThread = null;
            }

            if (acceptThread != null)
            {
                acceptThread.Cancel();
                acceptThread = null;
            }

            state = ConnectionState.None;
            UpdateUserInterfaceTitle();
        }
        
        public void Write(byte[] @out)
        {
            ConnectedThread r;
            lock (this)
            {
                if (state != ConnectionState.Connected)
                {
                    return;
                }
                r = connectedThread;
            }
            r.Write(@out);
        }

        void ConnectionFailed()
        {
            state = ConnectionState.Listen;
            Toast.MakeText(Application.Context, "Connection Failed", ToastLength.Long).Show();
        }
        
        public void ConnectionLost()
        {
            Toast.MakeText(Application.Context, "Unable To Connect Device", ToastLength.Long).Show();

            state = ConnectionState.None;
            UpdateUserInterfaceTitle();
            this.Start();
        }
        
        class AcceptThread : Thread
        {
            BluetoothServerSocket serverSocket;
            BluetoothService service;

            public AcceptThread(BluetoothService service)
            {
                BluetoothServerSocket tmp = null;
                this.service = service;

                try
                {
                    tmp = service.btAdapter.ListenUsingRfcommWithServiceRecord(App_Name, uUID);
                }
                catch (Exception e)
                {
                    Toast.MakeText(Application.Context, "Listening Failed due to " + e.Message, ToastLength.Long).Show();
                }
                serverSocket = tmp;
                service.state = ConnectionState.Listen;
            }

            public override void Run()
            {
                BluetoothSocket socket = null;

                while (service.GetState() != ConnectionState.Connected)
                {
                    try
                    {
                        socket = serverSocket.Accept();
                    }
                    catch (Exception e)
                    {
                        Toast.MakeText(Application.Context, "Accept Failed due to " + e.Message, ToastLength.Long).Show();
                        break;
                    }

                    if (socket != null)
                    {
                        lock (this)
                        {
                            switch (service.GetState())
                            {
                                case ConnectionState.Listen:
                                case ConnectionState.Connecting:
                                    service.Connected(socket, socket.RemoteDevice);
                                    break;
                                case ConnectionState.None:
                                case ConnectionState.Connected:
                                    try
                                    {
                                        socket.Close();
                                    }
                                    catch (Exception e)
                                    {
                                        Toast.MakeText(Application.Context, "Could not close socket due to " + e.Message, ToastLength.Long).Show();
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

            public void Cancel()
            {
                try
                {
                    serverSocket.Close();
                }
                catch (Exception e)
                {
                    Toast.MakeText(Application.Context, "Server Close Failed due to " + e.Message, ToastLength.Long).Show();
                }
            }
        }
        
        protected class ConnectThread : Thread
        {
            BluetoothSocket socket;
            BluetoothDevice device;
            BluetoothService service;

            public ConnectThread(BluetoothDevice device, BluetoothService service)
            {
                this.device = device;
                this.service = service;
                BluetoothSocket tmp = null;

                try
                {
                    tmp = device.CreateRfcommSocketToServiceRecord(uUID);

                }
                catch (Exception e)
                {
                    Toast.MakeText(Application.Context, "Create Failed due to " + e.Message, ToastLength.Long).Show();
                }
                socket = tmp;
                service.state = ConnectionState.Connecting;
            }

            public override void Run()
            {
                service.btAdapter.CancelDiscovery();
                try
                {
                    socket.Connect();
                }
                catch (Exception)
                {
                    try
                    {
                        socket.Close();
                    }
                    catch (Exception e2)
                    {
                        Toast.MakeText(Application.Context, "Unable to Close Socket due to " + e2.Message, ToastLength.Long).Show();
                    }
                    
                    service.ConnectionFailed();
                    return;
                }
                
                lock (this)
                {
                    service.connectThread = null;
                }
                
                service.Connected(socket, device);
            }

            public void Cancel()
            {
                try
                {
                    socket.Close();
                }
                catch (Exception e)
                {
                    Toast.MakeText(Application.Context, "Unable to Close Socket due to " + e.Message, ToastLength.Long).Show();
                }
            }
        }
        
        class ConnectedThread : Thread
        {
            BluetoothSocket socket;
            Stream inStream;
            Stream outStream;
            BluetoothService service;

            public ConnectedThread(BluetoothSocket socket, BluetoothService service)
            {
                this.socket = socket;
                this.service = service;
                Stream tmpIn = null;
                Stream tmpOut = null;

                try
                {
                    tmpIn = socket.InputStream;
                    tmpOut = socket.OutputStream;
                }
                catch (Exception e)
                {
                    Toast.MakeText(Application.Context, "temp sockets not created due to " + e.Message, ToastLength.Long).Show();
                }

                inStream = tmpIn;
                outStream = tmpOut;
                service.state = ConnectionState.Connected;
            }

            public override void Run()
            {
                byte[] buffer = new byte[1024];
                int bytes;
                
                while (service.GetState() == ConnectionState.Connected)
                {
                    try
                    {
                        bytes = inStream.Read(buffer, 0, buffer.Length);

                        service.handler
                               .ObtainMessage((int) BluetoothState.Read, bytes, -1, buffer)
                               .SendToTarget();
                    }
                    catch (Exception e)
                    {
                        Toast.MakeText(Application.Context, "Disconnected due to " + e.Message, ToastLength.Long).Show();
                        service.ConnectionLost();
                        break;
                    }
                }
            }
            
            public void Write(byte[] buffer)
            {
                try
                {
                    outStream.Write(buffer, 0, buffer.Length);
                    service.handler
                           .ObtainMessage((int) BluetoothState.Write, -1, -1, buffer)
                           .SendToTarget();
                }
                catch (Exception e)
                {
                    Toast.MakeText(Application.Context, "Unable to Write due to " + e.Message, ToastLength.Long).Show();
                }
            }

            public void Cancel()
            {
                try
                {
                    socket.Close();
                }
                catch (Exception e)
                {
                    Toast.MakeText(Application.Context, "Unable to Close Socket due to " + e.Message, ToastLength.Long).Show();
                }
            }
        }
    }
}