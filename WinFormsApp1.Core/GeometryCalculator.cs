namespace WinFormsApp1.Core;

public class GeometryCalculator
{
    public decimal CalculateArea(Dimensions dimensions)
    {
        Validate(dimensions);
        return 2m * ((dimensions.Ancho * dimensions.Largo) + (dimensions.Ancho * dimensions.Alto) + (dimensions.Largo * dimensions.Alto));
    }

    public decimal CalculatePerimeter(Dimensions dimensions)
    {
        Validate(dimensions);
        return 4m * (dimensions.Alto + dimensions.Ancho + dimensions.Largo);
    }

    private static void Validate(Dimensions dimensions)
    {
        if (dimensions is null)
        {
            throw new ArgumentNullException(nameof(dimensions));
        }

        if (dimensions.Alto <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(dimensions.Alto), "Alto debe ser mayor que 0.");
        }

        if (dimensions.Ancho <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(dimensions.Ancho), "Ancho debe ser mayor que 0.");
        }

        if (dimensions.Largo <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(dimensions.Largo), "Largo debe ser mayor que 0.");
        }
    }
}
