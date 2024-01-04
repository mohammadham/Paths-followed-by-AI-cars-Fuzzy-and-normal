using unity.core;
using unity.ui;

class NormalCarHandelClass : MonoBehaviour
{
             // ایجاد یک شیء GameObject جدید
    public  GameObject car = new GameObject("CarNormal");
    private NormalCar normalCar = null;
    void OnEnable()
    {

        if(this.car){
        // اضافه کردن کلاس NormalCar به شیء
        car.AddComponent<NormalCar>();

        // تنظیم تنظیمات کلاس
        this.normalCar = car.GetComponent<NormalCar>();
        this.normalCar.position = new Vector3(0, 0, 0);
        this.normalCar.direction = new Vector3(1, 0, 0);
        this.normalCar.speed = 10;
        }
    }
    

    // حرکت خودرو
    void Update()
    {
        this.normalCar.Move();
    }

}