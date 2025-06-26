using UnityEngine;

public class SnakeBodySpawner : MonoBehaviour
{
    //public GameObject bodyPartPrefab;
    //public int bodyCount = 5;

    //private void Start()
    //{
    //    for (int i = 1; i <= bodyCount; i++)
    //    {
    //        GameObject part = Instantiate(bodyPartPrefab);
    //        part.GetComponent<SnakeBodyPart>().Init(transform.GetComponent<SnakeHead>(), i * 10);
    //        //part.GetComponent<SnakeBodyPart>().head = this.transform;
    //        //part.GetComponent<SnakeBodyPart>().index = i * 10; // 10 steps apart
    //        //part.GetComponent<SnakeBodyPart>().headScript = transform.GetComponent<SnakeHead>();
    //    }
    //}

    public GameObject headPrefab;
    public GameObject bodySegmentPrefab;
    public int bodyCount = 10;
    public float segmentSpacing = 0.5f;

    void Start()
    {
        //GameObject head = Instantiate(headPrefab, transform.position, transform.rotation);
        GameObject head = headPrefab;
        Rigidbody previousBody = head.GetComponent<Rigidbody>();

        for (int i = 0; i < bodyCount; i++)
        {
            Vector3 pos = head.transform.position - (i + 1) * segmentSpacing * head.transform.forward;
            GameObject segment = Instantiate(bodySegmentPrefab, pos, head.transform.rotation);
            ConfigurableJoint joint = segment.GetComponent<ConfigurableJoint>();
            ConfigureJoint(joint, previousBody);
            previousBody = segment.GetComponent<Rigidbody>();
        }
    }

    void ConfigureJoint(ConfigurableJoint joint, Rigidbody connectedBody)
    {
        joint.connectedBody = connectedBody;
        joint.autoConfigureConnectedAnchor = false;
        joint.anchor = Vector3.zero;
        joint.connectedAnchor = new Vector3(0, 0, -0.5f);
        //joint.connectedAnchor = new Vector3(-0.5f, 0, 0);

        joint.xMotion = ConfigurableJointMotion.Limited;
        joint.yMotion = ConfigurableJointMotion.Limited;
        joint.zMotion = ConfigurableJointMotion.Limited;

        SoftJointLimit limit = new SoftJointLimit();
        limit.limit = 0.5f;
        joint.linearLimit = limit;

        JointDrive drive = new JointDrive
        {
            positionSpring = 100f,
            positionDamper = 5f,
            maximumForce = Mathf.Infinity
        };

        joint.xDrive = drive;
        joint.yDrive = drive;
        joint.zDrive = drive;
    }
}
