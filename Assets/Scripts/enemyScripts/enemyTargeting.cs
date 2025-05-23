using UnityEngine;
using System.Collections;

namespace Pathfinding
{
    /// <summary>
    /// Sets the destination of an AI to the position of a specified object.
    /// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
    /// This component will then make the AI move towards the <see cref="targetPlayer"/> set on this component.
    ///
    /// See: <see cref="Pathfinding.IAstarAI.destination"/>
    ///
    /// [Open online documentation to see images]
    /// </summary>
    [UniqueComponent(tag = "ai.destination")]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
    public class enemyTargeting : VersionedMonoBehaviour
    {
        /// <summary>The object that the AI should move to</summary>
        public Transform targetB;
        private GameObject player;
        IAstarAI ai;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        void OnEnable()
        {
            ai = GetComponent<IAstarAI>();
            // Update the destination right before searching for a path as well.
            // This is enough in theory, but this script will also update the destination every
            // frame as the destination is used for debugging and may be used for other things by other
            // scripts as well. So it makes sense that it is up to date every frame.
            if (ai != null) ai.onSearchPath += Update;
        }

        void OnDisable()
        {
            if (ai != null) ai.onSearchPath -= Update;
        }

        /// <summary>Updates the AI's destination every frame</summary>
        void Update()
        {
            float distanceToTargetA = Vector2.Distance(transform.position, player.transform.position);
            float distanceToTargetB = Vector2.Distance(transform.position, targetB.transform.position);
            if(distanceToTargetA>distanceToTargetB)
            {
                StartCoroutine(targetLockTimeB());
            }
            else
            {
                StartCoroutine(targetLockTimeA());
            }
            
        }

        //Path towards objective to destroy for a time
        private IEnumerator targetLockTimeB()
        {
            float disance = Vector2.Distance(transform.position, player.transform.position);
            if (targetB != null && ai != null && disance >= 3) ai.destination = targetB.position;
            else ai.destination = transform.position;
            yield return new WaitForSeconds(3);
            StopCoroutine(targetLockTimeB());
        }
        //Path to the player for a time
        private IEnumerator targetLockTimeA()
        {
            if (player.transform != null && ai != null) ai.destination = player.transform.position;
            yield return new WaitForSeconds(3);
            StopCoroutine(targetLockTimeA());
        }
    }
}
