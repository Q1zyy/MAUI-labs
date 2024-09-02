
using System.Diagnostics;

namespace MauiApp1;

public partial class ProgressBarPage : ContentPage
{
	private CancellationTokenSource cancellation;
	private CancellationToken token;
	public ProgressBarPage()
	{
		cancellation = new CancellationTokenSource();
		token = cancellation.Token;
		InitializeComponent();
		
	}

	private async Task<double> CalculateIntegral(CancellationToken token)
	{
        Debug.WriteLine($"---------> Enter calc: {Thread.CurrentThread.ManagedThreadId}");

        double x = 0;
        double step = 0.001;
        double sum = 0;
        while (x < 1)
        {
            Debug.WriteLine($"---------> Inside while: {Thread.CurrentThread.ManagedThreadId}");
			MainThread.BeginInvokeOnMainThread(() =>
			{
                StartLabel.Text = "Calculating";
            });
            if (token.IsCancellationRequested)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    StartLabel.Text = "Calculation was cancelled";
                });
				throw new Exception();
            }
            sum += Math.Sin(x) * step;
            x += step;
            await Progress.ProgressTo(x, 1, Easing.Linear);
            int percent = (int)(x * 100);
            if (percent.ToString() != Persents.Text)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Persents.Text = percent.ToString();
                });
      
			}
        }
        MainThread.BeginInvokeOnMainThread(() =>
        {
			if (Persents.Text == "100")
			{
				StartLabel.Text = "Complete";
			}
        });
		return sum;
    }

	private async void OnStartClicked(object o, EventArgs e)
	{
		Debug.WriteLine($"---------> Start: {Thread.CurrentThread.ManagedThreadId}");
		Persents.Text = "0";
		Progress.Progress = 0;
		cancellation = new CancellationTokenSource();
		try
		{
			await Task.Run(()=> CalculateIntegral(cancellation.Token));
		}
		catch
		{
            StartLabel.Text = "Calculation was cancelled";
        }
		finally
		{
            cancellation.Dispose();
        }
    }
	
	private void OnCancelClicked(object o, EventArgs e)
	{
		cancellation.Cancel();
	}

}