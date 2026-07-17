using System.ComponentModel;

namespace Controls.Customs
{
    public enum TextBoxDataType
    {
        String,
        Integer
    }

    public class UniPlanTextBox : TextBox
    {
        [Category("Behavior")]
        public TextBoxDataType DataType { get; set; } = TextBoxDataType.String;

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (DataType == TextBoxDataType.Integer)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        public bool TryGetInt(out int num)
        {
            return int.TryParse(Text, out num);
        }
    }
}
