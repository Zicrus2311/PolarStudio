namespace PolarStudio;

public partial class PolarStudio : Form {
    public static RichTextBox[] TextBoxes { get; private set; } = Array.Empty<RichTextBox>();
    public static RichTextBox? TempBox { get; private set; }

    public PolarStudio(string? path) {
        InitializeComponent();
        TextBoxes = new RichTextBox[] { textBox1, textBox2 };
        TempBox = tempBox;
        if (path != null) {
            FileManager.OpenPath(path);
        }
        else {
            FileManager.New();
        }
    }

    private void Menu_New(object sender, EventArgs e) {
        FileManager.New();
    }

    private void Menu_Open(object sender, EventArgs e) {
        FileManager.Open();
    }

    private void Menu_Save(object sender, EventArgs e) {
        FileManager.Save();
    }

    private void Menu_SaveAs(object sender, EventArgs e) {
        FileManager.SaveAs();
    }

    private void Menu_Exit(object sender, EventArgs e) {
        Application.Exit();
    }

    private void Menu_Undo(object sender, EventArgs e) {
        EditHistory.Undo();
    }

    private void Menu_Redo(object sender, EventArgs e) {
        EditHistory.Redo();
    }

    private void Menu_Cut(object sender, EventArgs e) {
        Clipboard.Cut();
    }

    private void Menu_Copy(object sender, EventArgs e) {
        Clipboard.Copy();
    }

    private void Menu_Paste(object sender, EventArgs e) {
        Clipboard.Paste();
    }

    private void Menu_Duplicate(object sender, EventArgs e) {
        Clipboard.Duplicate();
    }

    private void Menu_SelectAll(object sender, EventArgs e) {
        TextSelection.SelectAll();
    }

    private void Menu_Documentation(object sender, EventArgs e) {
        WebUtilities.OpenWebsite("https://docs.google.com/document/d/1C0zamLt11Bn22bQfW1uBZbZ-W0TqkU_GBfiYHNjLufE/edit?usp=sharing");
    }

    private void Menu_Discord(object sender, EventArgs e) {
        WebUtilities.OpenWebsite("https://discord.gg/ra2Y7TQM");
    }

    private void TextBox_KeyPress(object sender, KeyPressEventArgs e) {
        RichTextBox textBox = (RichTextBox)sender;
        e.Handled = InputHandler.HandleCharInput(textBox, e);
    }

    private void TextBox_KeyDown(object sender, KeyEventArgs e) {
        RichTextBox textBox = (RichTextBox)sender;
        e.Handled = InputHandler.HandleKeyInput(textBox, e);
    }

    private void TextBox_MouseUp(object sender, MouseEventArgs e) {
        RichTextBox textBox = (RichTextBox)sender;
        TextSelection.CorrectSelection(textBox);
    }

    private void TextBox_ContentsResized(object sender, ContentsResizedEventArgs e) {
        RichTextBox textBox = (RichTextBox)sender;
        TextBoxView.SyncZoom(textBox);
    }

    private void TextBox_Scroll(object sender, EventArgs e) {
        RichTextBox textBox = (RichTextBox)sender;
        TextBoxView.SyncScroll(textBox);
    }

    private void TextBox1_TextChanged(object sender, EventArgs e) {
        BottomInfo.UpdateInfo(infoLabel);
    }
}