// کلاس ماشین با تصمیم گیری فازی
public class FuzzyCar: MonoBehaviour
{
    // مجموعه های فازی
    private FuzzySet<float> distanceToVehicles;
    private FuzzySet<float> distanceToSides;

    // قواعد فازی
    private List<FuzzyRule> rules;

    // موتور استنتاج فازی
    private FuzzyInferenceEngine engine;

    // موقعیت فعلی خودرو
    public Vector3 position;

    // جهت فعلی خودرو
    public Vector3 direction;

    // سرعت فعلی خودرو
    public float speed;

    // 
    public FuzzyCar(Vector3 position, Vector3 direction, float speed)
    {
        // ایجاد مجموعه های فازی
        this.distanceToVehicles = new FuzzySet<float>();
        this.distanceToVehicles.AddPoint(0, 0);
        this.distanceToVehicles.AddPoint(10, 1);
        this.distanceToVehicles.AddPoint(20, 0);

        this.distanceToSides = new FuzzySet<float>();
        this.distanceToSides.AddPoint(0, 0);
        this.distanceToSides.AddPoint(10, 1);
        this.distanceToSides.AddPoint(20, 0);

        // تعریف قواعد فازی
        this.rules = new List<FuzzyRule>();
        this.rules.Add(new FuzzyRule()
        {
            Antecedent = new FuzzyExpression(this.distanceToVehicles, "isLow")
                .And(new FuzzyExpression(this.distanceToSides, "isHigh")),
            Consequent = new FuzzyExpression(this.direction, "isLeft")
        });

        // ایجاد موتور استنتاج فازی
        this.engine = new FuzzyInferenceEngine();
        this.engine.AddRules(this.rules);

        // تنظیم موقعیت فعلی خودرو
        this.position = position;

        // تنظیم جهت فعلی خودرو
        this.direction = direction;

        // تنظیم سرعت فعلی خودرو
        this.speed = speed;
    }

    // محاسبه خروجی موتور استنتاج فازی
    private float CalculateOutput()
    {
        // محاسبه تابع تعلق خروجی برای هر قاعده
        List<float> outputValues = new List<float>();
        foreach (FuzzyRule rule in this.rules)
        {
            outputValues.Add(this.engine.Evaluate(rule));
        }

        // محاسبه خروجی کلی
        float output = 0;
        for (int i = 0; i < outputValues.Count; i++)
        {
            output += outputValues[i];
        }

        return output / outputValues.Count;
    }

    // حرکت خودرو
    public void Move()
    {
        // محاسبه فاصله تا سایر وسایل نقلیه
        float distanceToVehicles = Vector3.Distance(this.position, this.direction);

        // محاسبه فاصله تا کناره های جاده
        float distanceToSides = Vector3.Distance(this.position, Vector3.up);

        // محاسبه جهت جدید خودرو
        float direction = this.CalculateOutput();

        // اعمال جهت جدید به خودرو
        this.direction = direction * Quaternion.identity;
    }
}
