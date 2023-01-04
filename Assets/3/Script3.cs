
/*Exercise made by Diego Salamanca for Jam City, on January 3 of 2023
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

        var x = (float) System.Math.Floor(transform.position.x*10);
        var y = (float) System.Math.Floor(transform.position.y*10);

        float angle = transform.eulerAngles.z;
        angle = (angle > 180) ? angle - 360 : angle;
        var z = (float) System.Math.Floor(angle);
        
        sbyte px = System.Convert.ToSByte(x);

        sbyte py = System.Convert.ToSByte(y);  

        sbyte rz = System.Convert.ToSByte(z);   
        sbyte[] data = {px,py,rz};

        dataWriter.PutSBytesWithLength(data);

    }

    private void DeserializeTransform(Transform transform, NetDataReader dataReader)
    {
        
        Vector3 newPosition = new Vector3(); 
        Vector3 newRotation = new Vector3();   
        var data =   dataReader.GetSBytesWithLength();   

        float x = data[0]/10f;
        float y = data[1]/10f;
        float z = data[2];      

        newPosition.x = x;
        newPosition.y = y;              
        newRotation.z = z;

        transform.position = newPosition;
        transform.eulerAngles = newRotation;
    }
    
}





