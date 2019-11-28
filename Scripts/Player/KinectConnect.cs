/************************
 * 프로그램명 : KinectConnect.cs
 * 작성자 : 이한주 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 6일
 * 프로그램 설명 : 키넥트로부터 몸 정보를 인식받고 손에 관련된 정보를 Hand 객체에 저장
 ************************/

using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using Windows.Kinect;

public class KinectConnect : MonoBehaviour
{
    KinectSensor m_Sensor;
    Body[] m_Body = null;
    BodyFrameReader m_bfReader;

    [SerializeField]
    private Hand LeftHand, RightHand;

    private float CursorSpeed;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // 키넥트 센서, 리더 가져온다
        m_Sensor = KinectSensor.GetDefault();
        if (m_Sensor != null)
        {
            m_bfReader = m_Sensor.BodyFrameSource.OpenReader();
            if (!m_Sensor.IsOpen) m_Sensor.Open();
        }
        CursorSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bfReader == null) return;

        // 한 프레임 얻는다
        BodyFrame frame = m_bfReader.AcquireLatestFrame();

        if (frame == null) return;

        if (m_Body == null) m_Body = new Body[m_Sensor.BodyFrameSource.BodyCount];

        // 몸 데이터 갱신
        frame.GetAndRefreshBodyData(m_Body);

        //프레임 해제
        frame.Dispose();
        frame = null;

        foreach (Body body in m_Body)
        {
            if (!body.IsTracked) continue;

            // 왼손이 닫혀 있을 때
            if (body.HandLeftState == HandState.Closed) LeftHand.grap = true;
            else LeftHand.grap = false;
            
            // 오른손이 닫혀 있을 때
            if (body.HandRightState == HandState.Closed) RightHand.grap = true;
            else RightHand.grap = false;
            
            // 왼손을 머리 위로 들 때
            if (body.Joints[JointType.HandLeft].Position.Y >= body.Joints[JointType.Head].Position.Y) LeftHand.high = true;
            // 오른손을 머리 위로 들 때
            else if (body.Joints[JointType.HandRight].Position.Y >= body.Joints[JointType.Head].Position.Y) RightHand.high = true;
            else
            {
                LeftHand.high = false;
                RightHand.high = false;
            }

            RightHand.transform.position = PointToVector3(body.Joints[JointType.HandRight].Position);
            LeftHand.transform.position = PointToVector3(body.Joints[JointType.HandLeft].Position);
        }
    }


    Vector3 PointToVector3(CameraSpacePoint p)
    {
        Vector3 v = new Vector3();
        v.x = p.X * CursorSpeed;
        v.y = p.Y * CursorSpeed;
        v.z = p.Z * CursorSpeed;

        return v;
    }

    void OnApplicationQuit()
    {
        //모든 인스턴스 해제
        if (m_bfReader != null)
        {
            m_bfReader.Dispose();
            m_bfReader = null;
        }
        if (m_Sensor != null)
        {
            if (m_Sensor.IsOpen) m_Sensor.Close();
            m_Sensor = null;
        }
    }
}
