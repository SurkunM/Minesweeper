namespace Minesweeper.Gui.FieldComponents;

internal class NeighboringMinesCountLabels
{
    public Label One { get; private set; }

    //public Label Two { get; set; }

    //public Label Three { get; set; }

    //public Label Four { get; set; }

    //public Label Five { get; set; }

    //public Label Six { get; set; }

    //public Label Seven { get; set; }

    //public Label Eight { get; set; }

    public NeighboringMinesCountLabels()
    {
        One = new Label();

        One.AutoSize = true;
        One.Dock = DockStyle.Fill;
        One.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
        One.ForeColor = Color.Blue;
        One.Margin = new Padding(0);
        One.Padding = new Padding(0);
        One.Name = "one";
        One.Text = "1";
        One.TextAlign = ContentAlignment.MiddleCenter;
        //Two = new Label();
        //Three = new Label();
        //Four = new Label();
        //Five = new Label();
        //Six = new Label();
        //Seven = new Label();
        //Eight = new Label();
    }
}
