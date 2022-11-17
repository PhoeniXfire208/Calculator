namespace Calculator
{
    public partial class Form1 : Form
    {
        private MeasureType GetMeasureType(ComboBox comboBox)
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "Ìכ.":
                    measureType = MeasureType.ml;
                    break;
                case "Ë.":
                    measureType = MeasureType.l;
                    break;
                case "ל3.":
                    measureType = MeasureType.m3;
                    break;
                case "Áאננוכ.":
                    measureType = MeasureType.bar;
                    break;
                default:
                    measureType = MeasureType.ml;
                    break;
            }
            return measureType;
        }

        private void Calculate()
        {
            try
            {
                var firstValue = double.Parse(txtFirst.Text);
                var secondValue = double.Parse(txtSecond.Text);

                MeasureType firstType = GetMeasureType(cmbFirstType);
                MeasureType secondType = GetMeasureType(cmbSecondType);
                MeasureType resultType = GetMeasureType(cmbResultType);

                var firstLength = new Length(firstValue, firstType);
                var secondLength = new Length(secondValue, secondType);

                Length sumLength;

                switch (cmbOperation.Text)
                {
                    case "+":
                        sumLength = firstLength + secondLength;
                        break;
                    case "-":
                        sumLength = firstLength - secondLength;
                        break;
                    case "*":
                        sumLength = firstLength * secondLength;
                        break;
                    case "/":
                        sumLength = firstLength / secondLength;
                        break;
                    default:
                        sumLength = new Length(0, MeasureType.ml);
                        break;
                }
                txtResult.Text = sumLength.To(resultType).Verbose();
            }
            catch (FormatException)
            {

            }

        }

        public Form1()
        {
            InitializeComponent();

            var measureItems = new string[]
            {
            "Ìכ.",
            "Ë.",
            "ל3.",
            "Áאננוכ.",
            };

            cmbFirstType.DataSource = new List<string>(measureItems);
            cmbSecondType.DataSource = new List<string>(measureItems);
            cmbResultType.DataSource = new List<string>(measureItems);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void onValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}