using UnityEngine;

public class TankAI : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    public Transform turret; // Ссылка на башню танка
    public GameObject projectilePrefab; // Префаб снаряда для стрельбы
    public Transform shootingPoint; // Точка, откуда должен быть выпущен снаряд
    public float shootingRange = 10f; // Дистанция обнаружения игрока
    public float rotationSpeed = 3f; // Скорость поворота башни
    public float moveSpeed = 5f; // Скорость движения танка
    public Transform[] waypoints; // Путь, по которому двигается танк
    private int currentWaypointIndex = 0; // Индекс текущей точки пути

    private void Start()
    {
        if (waypoints.Length > 0)
            transform.position = waypoints[0].position; // Начинаем с первой точки пути
    }

    private void Update()
    {
        if (player == null)
            return;

        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        turret.rotation = Quaternion.Slerp(turret.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (directionToPlayer.magnitude <= shootingRange)
        {
            Shoot();
        }

        // Перемещение к следующей точке пути
        if (waypoints.Length > 0 && Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        // Движение к текущей точке пути
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        direction.y = 0f;

        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, shootingPoint.position, turret.rotation);
    }
}
