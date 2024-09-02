using MauiApp1.LR3.Services;

namespace MauiApp1;

public partial class Laba3 : ContentPage
{

	private IDbService service = new SQLiteService();

	public Laba3(IDbService serv)
	{
		InitializeComponent();
		service = serv;
		//service.Init();
	}

    private void InitAuthors(object sender, EventArgs e)
    {
		var authors = service.GetAuthors();
		foreach (var auth in authors)
		{
			AuthorList.Items.Add(auth.Name);
		}
    }

    private void SelectAuthor(object sender, EventArgs e)
    {
		string name = AuthorList.SelectedItem.ToString();
		BooksList.ItemTemplate = new DataTemplate(() =>
		{
			var lbl = new Label { FontSize=20} ;
            lbl.SetBinding(Label.TextProperty, new Binding("BindingContext", source: RelativeBindingSource.Self));
            return lbl;
		});
		var books = service.GetAuthorsBooks(name);
		BooksList.ItemsSource = from b in books select b.Title + $" ({b.Year})";
	}
}