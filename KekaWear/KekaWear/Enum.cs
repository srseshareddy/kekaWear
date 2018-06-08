namespace Keka_Sample
{
    public enum ConnectionState
    {
        None,
        Listen,
        Connecting,
        Connected
    }

    public enum BluetoothState
    {
        Change,
        Read,
        Write,
        DeviceName
    }
}