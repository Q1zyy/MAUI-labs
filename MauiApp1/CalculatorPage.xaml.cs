
using Microsoft.Maui.Controls;

namespace MauiApp1;

public partial class CalculatorPage : ContentPage
{

	private bool first = true;
    private string lastSign = "";
	public CalculatorPage()
	{
		InitializeComponent();
	}

    private void Solve()
    {
        if (buffer.Text.Length == 0)
        {
            return;
        }
        double one = double.Parse(buffer.Text);
        double two = double.Parse(output.Text);
        buffer.Text = "";
        if (lastSign == "+")
        {
            output.Text = (two + one).ToString();
        } 
        if (lastSign == "-")
        {
            output.Text = (two - one).ToString();
        } 
        if (lastSign == "*")
        {
            output.Text = (two * one).ToString();
        } 
        if (lastSign == "/")
        {
            if (one == 0)
            {
                output.Text = "";
                first = true;
                return;
            }
            output.Text = (two / one).ToString();
        }
    }

    private void OnEqualsClicked(object sender, EventArgs e)
    {
        if (output.Text.Length == 0)
        {
            return;
        }
        Solve();
    }

    private void OnPlusClicked(object sender, EventArgs e)
    {

        if (output.Text.Length == 0)
        {
            return;
        }
        Solve();
        buffer.Text = "";
        first = false;
        lastSign = "+";
    }
    private void OnMinusClicked(object sender, EventArgs e)
    {
        if (output.Text.Length == 0)
        {
            return;
        }
        Solve();
        buffer.Text = "";
        first = false;
        lastSign = "-";
    }  
    private void OnProductClicked(object sender, EventArgs e)
    {
        if (output.Text.Length == 0)
        {
            return;
        }
        Solve();
        buffer.Text = "";
        first = false;
        lastSign = "*";
    }
    private void OnDivideClicked(object sender, EventArgs e)
    {
        if (output.Text.Length == 0)
        {
            return;
        }
        Solve();
        buffer.Text = "";
        first = false;
        lastSign = "/";
    }

    private void OnDigitClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        if (first)
		{
			output.Text = output.Text + button.Text;
        }
        else
        {
            buffer.Text = buffer.Text + button.Text;
        }
    }
    
    private void OnDotClicked(object sender, EventArgs e)
    {
		if (first)
		{
            if (output.Text.Length > 0 && !output.Text.Contains(','))
            {
			    output.Text = output.Text + ",";
            }
        }
        else
        {
            if (buffer.Text.Length > 0 && !buffer.Text.Contains(','))
            {
                buffer.Text = buffer.Text + ",";
            }
        }
    }
    private void OnChangeClicked(object sender, EventArgs e)
    {
		if (buffer.Text.Length > 0)
        {
            double one = double.Parse(buffer.Text);
            buffer.Text = (-one).ToString();
        } else if (output.Text.Length > 0)
        {
            double two = double.Parse(output.Text);
            output.Text = (-two).ToString();
        }
    }  
    private void OnReverseClicked(object sender, EventArgs e)
    {
		if (buffer.Text.Length > 0)
        {
            double one = double.Parse(buffer.Text);
            buffer.Text = (1 / one).ToString();
        } else if (output.Text.Length > 0)
        {
            double two = double.Parse(output.Text);
            output.Text = (1 / two).ToString();
        }
    } 
    private void OnSquareClicked(object sender, EventArgs e)
    {
		if (buffer.Text.Length > 0)
        {
            double one = double.Parse(buffer.Text);
            buffer.Text = (one * one).ToString();
        } else if (output.Text.Length > 0)
        {
            double two = double.Parse(output.Text);
            output.Text = (two * two).ToString();
        }
    } 
    private void OnRootClicked(object sender, EventArgs e)
    {
		if (buffer.Text.Length > 0)
        {
            double one = double.Parse(buffer.Text);
            buffer.Text = (Math.Sqrt(one)).ToString();
        } else if (output.Text.Length > 0)
        {
            double two = double.Parse(output.Text);
            output.Text = (Math.Sqrt(two)).ToString();
        }
    }
    private void OnTwoPowClicked(object sender, EventArgs e)
    {
		if (buffer.Text.Length > 0)
        {
            double one = double.Parse(buffer.Text);
            buffer.Text = (Math.Pow(2, one)).ToString();
        } else if (output.Text.Length > 0)
        {
            double two = double.Parse(output.Text);
            output.Text = (Math.Pow(2, two)).ToString();
        }
    }  
    private void OnDelClicked(object sender, EventArgs e)
    {
        if (buffer.Text.Length > 0)
        {
            buffer.Text = buffer.Text.Remove(buffer.Text.Length - 1);
        } else if (output.Text.Length > 0)
        {
            output.Text = output.Text.Remove(output.Text.Length - 1);
            if (output.Text.Length == 0)
            {
                first = true;
            }
        }
    }  
    private void OnCClicked(object sender, EventArgs e)
    {
        first = true;
        output.Text = "";
        buffer.Text = "";
    } 
    private void OnCEClicked(object sender, EventArgs e)
    {
        buffer.Text = "";
    } 
}