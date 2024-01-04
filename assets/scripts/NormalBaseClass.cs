// کلاس ماشین با تصمیم گیری عادی
public class NormalCar:MonoBehaviour
{
    // موقعیت فعلی خودرو
    public Vector3 position;

    // جهت فعلی خودرو
    public Vector3 direction;

    // سرعت فعلی خودرو
    public float speed;

    // 
    public NormalCar(Vector3 position, Vector3 direction, float speed)
    {
        // تنظیم موقعیت فعلی خودرو
        this.position = position;

        // تنظیم جهت فعلی خودرو
        this.direction = direction;

        // تنظیم سرعت فعلی خودرو
        this.speed = speed;
    }

    // حرکت خودرو
    public void Move()
    {
        // محاسبه فاصله تا سایر وسایل نقلیه
        float distanceToVehicles = Vector3.Distance(this.position, this.direction);

        // محاسبه فاصله تا کناره های جاده
        float distanceToSides = Vector3.Distance(this.position, Vector3.up);

        // تعیین جهت جدید خودرو
        Vector3 newDirection = Vector3.zero;
        if (distanceToVehicles < 10)
        {
            newDirection = -direction;
        }
        else if (distanceToSides < 10)
        {
            newDirection = direction;
        }

        // اعمال جهت جدید به خودرو
        this.direction = newDirection;
    }
}
