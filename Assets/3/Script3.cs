
/*Exercise made by Diego Salamanca for Jam City, on January 2 of 2023
Email: Diegocolmayor@gmial.com
Phone: +57 3508232690 Bogotá Colombia*/

using LiteNetLib.Utils;
using UnityEngine;

public class Script3 : MonoBehaviour
{
    
    [SerializeField] private Transform transformDataToSend;
    [SerializeField] private Transform playerTransform;

    NetDataWriter dataWriter = new NetDataWriter();
    NetDataReader dataReader = new NetDataReader();

    private void Update()
    {
        // *** Don't modify this method. ***

        // First, we serialize transformDataToSend in the data writer.
        dataWriter.Reset();
        SerializeTransform(transformDataToSend, dataWriter);

        byte[] data = dataWriter.CopyData();
        Debug.Log($"Serialized data. Total bytes: {data.Length}");

        // Now, we deserialize the data back, and use it to set the playerTransform. They should match.
        dataReader.SetSource(data);
        DeserializeTransform(playerTransform, dataReader);
    }

    private void SerializeTransform(Transform transform, NetDataWriter dataWriter)
    {

        sbyte px = System.Convert.ToSByte(transform.position.x);
        sbyte py = System.Convert.ToSByte(transform.position.y);     
        sbyte rz = System.Convert.ToSByte(transform.eulerAngles.z);   
        sbyte[] data = {px,py,rz};

        dataWriter.PutSBytesWithLength(data);

    }

    private void DeserializeTransform(Transform transform, NetDataReader dataReader)
    {
        
        Vector3 newPosition = new Vector3(); 
        Vector3 newRotation = new Vector3();   
        var data =   dataReader.GetSBytesWithLength();   
        newPosition.x = data[0];
        newPosition.y = data[1];              
        newRotation.z = data[2];

        transform.position = newPosition;
        transform.eulerAngles = newRotation;
    }
    
}





