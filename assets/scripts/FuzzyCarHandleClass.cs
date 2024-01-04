using unity.core;
using unity.ui;

class FuzzyCarHandelClass : MonoBehaviour
{
             // ایجاد یک شیء GameObject جدید
    public  GameObject car = new GameObject("Car");
    private FuzzyCar fuzzyCar = null;
    void OnEnable()
    {

        if(this.car){
        // اضافه کردن کلاس FuzzyCar به شیء
        car.AddComponent<FuzzyCar>();

        // تنظیم تنظیمات کلاس
        this.fuzzyCar = car.GetComponent<FuzzyCar>();
        this.fuzzyCar.position = new Vector3(0, 0, 0);
        this.fuzzyCar.direction = new Vector3(1, 0, 0);
        this.fuzzyCar.speed = 10;
        }
    }
    

    // حرکت خودرو
    void Update()
    {
        this.fuzzyCar.Move();
    }

}