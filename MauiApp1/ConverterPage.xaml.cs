using MauiApp1.LR4.Services;

namespace MauiApp1;

public partial class ConverterPage : ContentPage
{
	private readonly IRateService rateService;
    private bool ONE = false, TWO = false;
	public ConverterPage(IRateService rs)
	{
		InitializeComponent();
        rateService = rs;
		DateSelection.MaximumDate = DateTime.Today;
        LabelBYN.Text = "";
        LabelForeign.Text = "";
	}

    private async void DateSelected(object sender, DateChangedEventArgs e)
    {
        ONE = true;
        if (LabelBYN.Text.Length == 0)
        {
            LabelForeign.Text = "";
            ONE = false;
            return;
        }
        decimal val1 = 0, val2 = 0;
        if (decimal.TryParse(LabelBYN.Text, out val1) && RatePicker.SelectedItem != null)
        {
            var rates = await rateService.GetRates(DateSelection.Date);
            foreach (var rate in rates)
            {
                if (rate.Cur_Abbreviation == RatePicker.SelectedItem.ToString())
                {
                    LabelForeign.Text = Math.Round(val1 / rate.Cur_OfficialRate.Value * rate.Cur_Scale, 3).ToString();
                }
            }
        }
        ONE = false;
    }

    private async void ChangedBYN(object sender, TextChangedEventArgs e)
    {
        if (TWO) return;
        ONE = true;
        if (e.OldTextValue is null)
        {
            return;
        }
        if (e.OldTextValue.Equals(e.NewTextValue))
        {
            return;
        }
        if (LabelBYN.Text.Length == 0)
		{
			LabelForeign.Text = "";
			return;
		}
		decimal val1 = 0, val2 = 0;
		if (decimal.TryParse(LabelBYN.Text,out val1) && RatePicker.SelectedItem != null)
		{
			var rates = await rateService.GetRates(DateSelection.Date);
			foreach (var rate in rates)
			{
				if (rate.Cur_Abbreviation == RatePicker.SelectedItem.ToString())
				{
                    //string OLD = LabelBYN.Text;
					LabelForeign.Text = Math.Round(val1 / rate.Cur_OfficialRate.Value * rate.Cur_Scale, 3).ToString();
				    //LabelBYN.Text = OLD;
                }
			}
		}
        ONE = false;
    }

    private async void ChangedForeign(object sender, TextChangedEventArgs e)
    {
        if (ONE) return;
        TWO = true;
        if (e.OldTextValue is null)
        {
            return;
        }
        if (e.OldTextValue.Equals(e.NewTextValue))
        {
            return;
        }
        if (LabelForeign.Text.Length == 0)
        {
            LabelForeign.Text = "";
            return;
        }
        decimal val1 = 0;
        if (decimal.TryParse(LabelForeign.Text, out val1) && RatePicker.SelectedItem != null)
        {
            var rates = await rateService.GetRates(DateSelection.Date);
            foreach (var rate in rates)
            {
                if (rate.Cur_Abbreviation == RatePicker.SelectedItem.ToString())
                {
                    LabelBYN.Text = Math.Round(val1 * rate.Cur_OfficialRate.Value / rate.Cur_Scale, 3).ToString();
                }
            }
        }
        TWO = false;
    }
}