namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly WinFormsApp1.Core.GeometryCalculator _geometryCalculator = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            CalculateAndShowResult(_geometryCalculator.CalculateArea, "Área total");
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            CalculateAndShowResult(_geometryCalculator.CalculatePerimeter, "Perímetro total");
        }

        private void CalculateAndShowResult(Func<WinFormsApp1.Core.Dimensions, decimal> operation, string label)
        {
            try
            {
                var dimensions = new WinFormsApp1.Core.Dimensions
                {
                    Alto = nudAlto.Value,
                    Ancho = nudAncho.Value,
                    Largo = nudLargo.Value
                };

                var result = operation(dimensions);
                lblResultado.Text = $"{label}: {result:F2}";
            }
            catch (ArgumentOutOfRangeException)
            {
                lblResultado.Text = "Valores inválidos";
            }
            catch (ArgumentNullException)
            {
                lblResultado.Text = "Valores inválidos";
            }
        }
    }
}
