using ShopingCart;

namespace shoppingCart
{
    public partial class Form1 : Form
    {


        MenuItem itemCoffee = new MenuItem();
        MenuItem itemGreentea = new MenuItem();
        MenuItem itemNoodle = new MenuItem();
        MenuItem itemPizza = new MenuItem();

        public Form1()
        {
            InitializeComponent();
            itemCoffee.name = "Coffee";
            itemCoffee.Price = 100;
            itemCoffee.Quantity = 0;

            itemGreentea.name = "Greentea";
            itemGreentea.Price = 80;
            itemGreentea.Quantity = 0;

            itemNoodle.name = "Noodle";
            itemNoodle.Price = 60;
            itemNoodle.Quantity = 0;

            itemPizza.name = "Pizza";
            itemPizza.Price = 40;
            itemPizza.Quantity = 0;

            tbCoffePrice.Text = itemCoffee.Price.ToString();
            tbCoffeQuantity.Text = itemCoffee.Quantity.ToString();

            tbGreenTeaPrice.Text = itemGreentea.Price.ToString();
            tbGreenTeaQuantity.Text = itemGreentea.Quantity.ToString();

            tbNoodlePrice.Text = itemNoodle.Price.ToString();
            tbNoodleQuantity.Text = itemNoodle.Quantity.ToString();

            tbPizzaPrice.Text = itemPizza.Price.ToString();
            tbPizzaQuantity.Text = itemPizza.Quantity.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double dCash = double.Parse(tbCash.Text);
                double dBeverageTotal = 0;
                double dFoodTotal = 0;

                if (chbCoffe.Checked)
                {
                    dBeverageTotal += GetItemTotal(tbCoffePrice.Text, tbCoffeQuantity.Text);
                }
                if (chbGreenTea.Checked)
                {
                    dBeverageTotal += GetItemTotal(tbGreenTeaPrice.Text, tbGreenTeaQuantity.Text);
                }

                if (chbnoodle.Checked)
                {
                    dFoodTotal += GetItemTotal(tbNoodlePrice.Text, tbNoodleQuantity.Text);
                }
                if (chbpizza.Checked)
                {
                    dFoodTotal += GetItemTotal(tbPizzaPrice.Text, tbPizzaQuantity.Text);
                }

                double dGrandTotal = dBeverageTotal + dFoodTotal;

                double dTotalDiscount = CalculateTotalDiscount(dBeverageTotal, dFoodTotal, dGrandTotal);

                dGrandTotal -= dTotalDiscount;

                if (dCash < dGrandTotal)
                {
                    MessageBox.Show("เงินสดไม่เพียงพอ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double dChange = dCash - dGrandTotal;

                tbTotal.Text = dGrandTotal.ToString("F2");
                tbChange.Text = dChange.ToString("F2");

                CalculateChangeDenominations(dChange);
             }
            catch (FormatException)
            { 
                MessageBox.Show("กรุณากรอกข้อมูลตัวเลขให้ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double GetItemTotal(string priceText, string quantityText)
        {
            double price = 0, quantity = 0;
            try
            {
                price = double.Parse(priceText);
                quantity = double.Parse(quantityText);
            }
            catch (Exception)
            {
                price = 0;
                quantity = 0;
            }
            return price * quantity;
        }
        private double CalculateTotalDiscount(double dBeverageTotal, double dFoodTotal, double dGrandTotal)
        {
            double dDiscountBev = chbbeverage.Checked ? double.Parse(tbBeverageDiscount.Text) : 0;
            double dDiscountFood = chbfood.Checked ? double.Parse(tbFoodDiscount.Text) : 0;
            double dDiscountAll = chball.Checked ? double.Parse(tbtotalDiscount.Text) : 0;

            double dTotalDiscount = (dBeverageTotal * dDiscountBev / 100) + (dFoodTotal * dDiscountFood / 100) + (dGrandTotal * dDiscountAll / 100);

            return dTotalDiscount;
        }

        private void CalculateChangeDenominations(double change)
        {
            double[] denominations = { 1000, 500, 100, 50, 20, 10, 5, 1, 0.50, 0.25 };
            int[] changeCount = new int[denominations.Length];
            double remainChange = change;

            for (int i = 0; i < denominations.Length; i++)
            {
                changeCount[i] = (int)(remainChange / denominations[i]);
                remainChange %= denominations[i];
            }

            tb1000.Text = changeCount[0].ToString();
            tb500.Text = changeCount[1].ToString();
            tb100.Text = changeCount[2].ToString();
            tb50.Text = changeCount[3].ToString();
            tb20.Text = changeCount[4].ToString();
            tb10.Text = changeCount[5].ToString();
            tb5.Text = changeCount[6].ToString();
            tb1.Text = changeCount[7].ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tb1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
