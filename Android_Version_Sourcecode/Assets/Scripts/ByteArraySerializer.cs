using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Networking.Transport;

public class ByteArraySerializer : INetworkSerializable
{
    public byte[] ByteArray = ImageData.serializedRenderTexture;

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        if (serializer.IsReader)
        {
            // Read the length of the byte array
            int length = 0;
            serializer.SerializeValue(ref length);

            // Allocate the byte array
            ByteArray = new byte[length];

            // Read the byte array data
            for (int i = 0; i < length; i++)
            {
                serializer.SerializeValue(ref ByteArray[i]);
                Debug.Log("IsReader");
            }
        }
        else if (serializer.IsWriter)
        {
            // Write the length of the byte array
            int length = ByteArray != null ? ByteArray.Length : 0;
            serializer.SerializeValue(ref length);

            // Write the byte array data
            for (int i = 0; i < length; i++)
            {
                serializer.SerializeValue(ref ByteArray[i]);
                Debug.Log("IsWriter");
            }
        }
     //   ImageData.serializedRenderTexture = 
    }
}

