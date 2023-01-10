namespace Perfect_Pay;

public partial class MainPage : ContentPage
{
	decimal bill;
	int tip;
	int noPersons = 1;
	public MainPage()
	{
        InitializeComponent();
    }

    private void txtBill_Completed(object sender, EventArgs e)
    {
		bill = decimal.Parse(txtBill.Text);
		CalculateTotal();

    }

    private void CalculateTotal()
    {
        var totalTip = (bill * tip) / 100;
        var tipByPerson = (totalTip / noPersons);

        lblTip.Text = $"{tipByPerson:c}";

        var subTotal = (bill / noPersons);
        lblSubtotal.Text = $"{subTotal:c}";

        var totalByPerson = (bill + totalTip) / noPersons;
        lblTotal.Text = $"{totalByPerson:c}";
    }

    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = (int)sldTip.Value;
        porcentTip.Text = $"Tip: {tip}%";
        CalculateTotal();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if(sender is Button)
        {
            var btn = (Button)sender;
            var percentage = int.Parse(btn.Text.Replace("%", ""));
            sldTip.Value = percentage;
        }
    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
        if(noPersons > 1)
        {
            noPersons--;
        }
        lblPerson.Text = noPersons.ToString();
        CalculateTotal();
    }

    private void btnMax_Clicked(object sender, EventArgs e)
    {
        noPersons++;
        lblPerson.Text = noPersons.ToString();
        CalculateTotal();
    }
}

