    using UnityEngine;

    public class EnemyAI : CharacterMovement
    {
        public Transform player;
        [SerializeField] private float detectionRange = 10f;
        [SerializeField] private float shootingRange = 8f;
        public GunController gun;
        private float fallThreshold = -10f;

        protected override void Start()
        {
            base.Start();
            moveSpeed = 1f;
        }
        private void Update()
        {
            if (transform.position.y < fallThreshold)
            {
                Destroy(gameObject); 
                return; 
            }
            
            float distance = Vector2.Distance(transform.position, player.position);
            Vector2 dir = player.position.x < transform.position.x ? Vector2.left : Vector2.right;
            transform.localScale = new Vector3(Mathf.Sign(dir.x), 1, 1);
            
            if (distance < shootingRange)
            {
                animator.SetBool("isShooting", true);
                gun.Shoot();
                animator.SetFloat("xVelocity", 0f);
            }
            else if (distance < detectionRange)
            {
                Move(dir);
                animator.SetBool("isShooting", false);
            }
            else
            {
                animator.SetBool("isShooting", false);
                animator.SetFloat("xVelocity", 0f);
            }
        }
    }